using CleanArchitecture.Application.Common.Interfaces;
using MassTransit;

namespace CleanArchitecture.Application.FeatureName.Queries.CleanArchitectureUseCase;

public record CleanArchitectureUseCaseQuery
{
}

public class CleanArchitectureUseCaseResponse
{
}

public class CleanArchitectureUseCaseQueryValidator : AbstractValidator<CleanArchitectureUseCaseQuery>
{
    public CleanArchitectureUseCaseQueryValidator()
    {
    }
}

public class CleanArchitectureUseCaseQueryConsumer : IConsumer<CleanArchitectureUseCaseQuery>
{
    private readonly IApplicationDbContext _context;

    public CleanArchitectureUseCaseQueryConsumer(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task Consume(ConsumeContext<CleanArchitectureUseCaseQuery> context)
    {
        var command = context.Message;

        return context.RespondAsync(new CleanArchitectureUseCaseResponse());
    }
}
