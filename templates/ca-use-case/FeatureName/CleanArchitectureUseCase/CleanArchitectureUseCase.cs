using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Products.Queries.GetProductById;

namespace CleanArchitecture.Web.FeatureName.CleanArchitectureUseCase;

public class CleanArchitectureUseCase : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetCleanArchitectureUseCase);
    }

    public async Task<CustomResult> GetCleanArchitectureUseCase(MassTransit.Mediator.IMediator mediator, [AsParameters] CleanArchitectureUseCaseQuery query)
    {
        var response = await mediator.CreateRequestClient<CleanArchitectureUseCaseQuery>()
            .GetResponse<CustomResult>(query);

        return response.Message;
    }
}



