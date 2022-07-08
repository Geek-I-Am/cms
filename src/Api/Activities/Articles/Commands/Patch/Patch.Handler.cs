using Dtos;
using MediatR;
using Threenine;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;
using Dtos.Articles.Patch;

namespace Geekiam.Api.Activities.Articles.Commands.Patch;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IDataService _services;

    public Handler(IDataService services)
    {
        _services = services;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        return await _services.Patch<Models.Cms.Article, Article, Response>(x => x.Id == request.Id,
            request.Article);
    }
}
