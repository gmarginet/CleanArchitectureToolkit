using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using ServiceName.Contracts.Models;
using ServiceName.Contracts.ServiceRequests;
using ServiceName.CoreService.Queries;

namespace ServiceName.CoreService.ServiceRequestHandlers;

public class ExampleGetRequestHandler(ICatQueryProcessor queryProcessor) : ICatServiceRequestHandler<ExampleGetRequest, ExampleModel>
{
    public async Task<ICatResponse<ExampleModel>> HandleAsync(ExampleGetRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var response = await queryProcessor.ProcessAsync(new ExampleGetQuery(serviceRequest.ExampleId), cancellationToken);
        return response.Cast<ExampleModel>(x => new ExampleModel { Id = x.Id, Name = x.Name });
    }
}
