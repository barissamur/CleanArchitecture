using CleanArchitecture.Application.Common.Interfaces;
using MassTransit;

namespace CleanArchitecture.Application.FeatureName.Commands.CleanArchitectureUseCase;

public record CleanArchitectureUseCaseCommand
{
}

public class CleanArchitectureUseCaseCommandValidator : AbstractValidator<CleanArchitectureUseCaseCommand>
{
    public CleanArchitectureUseCaseCommandValidator()
    {
    }
}

public class CleanArchitectureUseCaseCommandConsumer : IConsumer<CleanArchitectureUseCaseCommand>
{
    private readonly IApplicationDbContext _context;

    public CleanArchitectureUseCaseCommandConsumer(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task Consume(ConsumeContext<CleanArchitectureUseCaseCommand> context)
    {
        var command = context.Message;

        return Task.CompletedTask;
    }
}
