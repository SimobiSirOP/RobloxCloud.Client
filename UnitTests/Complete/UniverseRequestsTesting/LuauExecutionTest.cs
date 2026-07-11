using RobloxCloudApi.RobloxCloudApi.APIMethods;
using RobloxCloudApi.RobloxCloudApi.APITypes.Operations;
using RobloxCloudApi.RobloxCloudApi.APITypes.RobloxGeneralTypes;

namespace UnitTests.Complete;

[Category("Basic")]
[Category("Complete")]
[TestFixture]
public class LuauExecutionTest
{
    [Test]
    [Order(0)]
    public async Task TestLuauExecution()
    {
        var placeIdList = await Globals.Client.GetUniversePlaces(Globals.TestUniverseId);
        long testingPlaceId = placeIdList.List!.First().Id!.Value;
        
        var operation = await Globals.Client.RunLuauExecution(
            Globals.TestUniverseId, 
            testingPlaceId,
            "assert(workspace.Gravity > 0, \"gravity smaller than 0\")",
            new RobloxDuration(5),
            true);
        
        Assert.That(operation, Is.Not.Null);
        Assert.That(operation.State, Is.EqualTo(LuauExecutionState.COMPLETE), operation.GetErrorString());
        Assert.Pass();
    }
}