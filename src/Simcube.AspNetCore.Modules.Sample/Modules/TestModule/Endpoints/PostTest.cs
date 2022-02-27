using Simcube.AspNetCore.Modules.Sample.Modules.TestModule.Models;

namespace Simcube.AspNetCore.Modules.Sample.Modules.TestModule.Endpoints;

public static class PostTest
{
    public static Task<IResult> Handle(TestRequest request)
    {
        return Task.FromResult(Results.Ok(request.testId));
    }
}