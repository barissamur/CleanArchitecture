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
    private readonly IApplicationDbContext _dbcontext;

    public CleanArchitectureUseCaseQueryConsumer(IApplicationDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task Consume(ConsumeContext<CleanArchitectureUseCaseQuery> context)
    {
        var query = context.Message;

        await context.RespondAsync(new CleanArchitectureUseCaseResponse());
    }
}
