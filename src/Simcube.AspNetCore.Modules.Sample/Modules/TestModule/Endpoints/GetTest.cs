namespace Simcube.AspNetCore.Modules.Sample.Modules.TestModule.Endpoints;

public static class GetTest
{
    public static Task<IResult> Handle(int testId)
    {
        return Task.FromResult(Results.Ok(testId));
    }
}