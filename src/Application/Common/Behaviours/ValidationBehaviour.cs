using MassTransit;
using ValidationException = CleanArchitecture.Application.Common.Exceptions.ValidationException;

namespace CleanArchitecture.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Any())
                throw new ValidationException(failures);
        }
        return await next();
    }
}


public class ValidationFilter<TMessage> : IFilter<ConsumeContext<TMessage>> where TMessage : class
{
    public async Task Send(ConsumeContext<TMessage> context, IPipe<ConsumeContext<TMessage>> next)
    {
        var serviceProvider = context.GetPayload<IServiceProvider>();

        IEnumerable<IValidator<TMessage>> validators = serviceProvider.GetService<IEnumerable<IValidator<TMessage>>>()!;

        if (validators.Any())
        {
            var validationContext = new ValidationContext<TMessage>(context.Message);

            var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(validationContext, context.CancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (failures.Count != 0)
            {
                await context.RespondAsync(CustomResult.Failure(failures.Select(f => f.ErrorMessage)));
            }
        }

        await next.Send(context);
    }

    public void Probe(ProbeContext context)
    {
        context.CreateFilterScope("validationFilter");
    }
}

public class ValidationConsumerConfigurationObserver :
    IConsumerConfigurationObserver
{
    public void ConsumerConfigured<TConsumer>(IConsumerConfigurator<TConsumer> configurator)
        where TConsumer : class
    {
    }

    public void ConsumerMessageConfigured<TConsumer, TMessage>(IConsumerMessageConfigurator<TConsumer, TMessage> configurator)
        where TConsumer : class
        where TMessage : class
    {
        configurator.Message(x => x.UseFilter(new ValidationFilter<TMessage>()));
    }
}
