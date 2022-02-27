using Simcube.AspNetCore.Modules.Sample.Modules.InfoModule.Models;

namespace Simcube.AspNetCore.Modules.Sample.Modules.InfoModule.Endpoints;

public static class PostInfo
{
    public static Task<IResult> Handle(InfoRequest request)
    {
        return Task.FromResult(Results.Ok(request.infoId));
    }
}