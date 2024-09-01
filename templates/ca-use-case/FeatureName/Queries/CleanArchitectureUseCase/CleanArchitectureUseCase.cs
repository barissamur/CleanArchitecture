using CleanArchitecture.Application.Common.Interfaces;
using MassTransit;

namespace CleanArchitecture.Application.FeatureName.Queries.CleanArchitectureUseCase;

public record CleanArchitectureUseCaseQuery
{
    public int? Id { get; set; }
    public string? Title { get; set; }

}

public class CleanArchitectureUseCaseResponse
{
    public string? Title { get; set; }

}

public class CleanArchitectureUseCaseQueryValidator : AbstractValidator<CleanArchitectureUseCaseQuery>
{
    public CleanArchitectureUseCaseQueryValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(5)
            .NotEmpty();
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
