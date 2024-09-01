using YourProjectName.Application.CleanArchitectureUseCase.Queries.CleanArchitectureUseCase;


namespace CleanArchitecture.Web.FeatureName.Endpoints.CleanArchitectureUseCase;

public class CleanArchitectureUseCase : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetCleanArchitectureUseCase);
    }

    public async Task<CleanArchitectureUseCaseResponse> GetCleanArchitectureUseCase(IMediator mediator, [AsParameters] CleanArchitectureUseCaseQuery query)
    {
        var response = await mediator.CreateRequestClient<CleanArchitectureUseCaseQuery>()
            .GetResponse<CleanArchitectureUseCaseResponse>(new());

        return response.Message;
    }
}



