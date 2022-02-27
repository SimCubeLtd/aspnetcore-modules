namespace Simcube.AspNetCore.Modules.Sample.Modules.InfoModule.Endpoints;

public static class GetInfo
{
    public static Task<IResult> Handle(int infoId)
    {
        return Task.FromResult(Results.Ok(infoId));
    }
}