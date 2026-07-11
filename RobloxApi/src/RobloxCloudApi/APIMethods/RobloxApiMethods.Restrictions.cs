using JetBrains.Annotations;
using RobloxCloudApi.RobloxCloudApi.APIRequests.UsersApi.Requests;
using RobloxCloudApi.RobloxCloudApi.APITypes;
using RobloxCloudApi.RobloxCloudApi.APITypes.ListTypes;
using RobloxCloudApi.RobloxCloudApi.Helpers;

namespace RobloxCloudApi.RobloxCloudApi.APIMethods;

[PublicAPI]
public static partial class RobloxApiMethods
{
    /// <summary>
    ///     Use this method to get one page of Restrictions
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="universeId">A roblox universe id</param>
    /// <param name="maxPageSize">
    ///     Maximum size of a page, see
    ///     <see href="https://create.roblox.com/docs/cloud/reference/features/users#Cloud_ListUserRestrictions" />
    /// </param>
    /// <param name="pageToken">
    ///     A page token, can be null. see
    ///     <see href="https://create.roblox.com/docs/cloud/reference/features/users#Cloud_ListUserRestrictions" />
    /// </param>
    /// <returns>The array of <see cref="RestrictionList" /></returns>
    public static async Task<RestrictionList> ListRestrictedUsersInUniverse(
        this IRobloxApiClient client,
        long universeId,
        int maxPageSize = 10,
        string pageToken = null!)
    {
        var result = (await client.ThrowIfNull().SendRequest(new ListUserRestrictionsRequest
        {
            UniverseId = universeId,
            MaxPageSize = maxPageSize,
            PageToken = pageToken
        }))!;
        return result;
    }

    /// <summary>
    ///     Use this method to get specific player restrictions
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="userId">A Roblox user id</param>
    /// <param name="universeId">A roblox universe id</param>
    /// <returns>A instance of <see cref="RestrictionData" /></returns>
    public static async Task<RestrictionData> GetUserRestrictionsInUniverse(
        this IRobloxApiClient client,
        long userId,
        long universeId
    )
    {
        return (await client.ThrowIfNull().SendRequest(new GetUserRestrictionsRequest
        {
            UniverseId = universeId,
            UserId = userId
        }))!;
    }

    /// <summary>
    ///     Use this method to change User restriction
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="userId">A roblox player ID</param>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="active">Is restriction active</param>
    /// <param name="startTime">Start time of a restriction</param>
    /// <param name="duration">Duration of a restriction</param>
    /// <param name="displayReason">Public reason of a restriction</param>
    /// <param name="privateReason">Reason that only developers can see</param>
    /// <param name="excludeAlts">Should this restriction also apply to alt accounts</param>
    /// <param name="inherited">Should this restriction be inherited by other users</param>
    /// <returns>An Instance of <see cref="RestrictionData" /></returns>
    public static async Task<RestrictionData> SetUserRestrictionsInUniverse(
        this IRobloxApiClient client,
        long userId,
        long universeId,
        bool active,
        DateTime startTime,
        string? duration,
        string displayReason,
        string privateReason,
        bool? excludeAlts = false,
        bool? inherited = true)
    {
        return (await client.ThrowIfNull().SendRequest(new RestrictionRequest(
            universeId, userId, new GameJoinRestriction
            {
                Active = active,
                StartTime = startTime,
                Duration = duration,
                DisplayReason = displayReason,
                PrivateReason = privateReason,
                ExcludeAltAccounts = excludeAlts,
                Inherited = inherited
            })))!;
    }

    /// <summary>
    ///     Use this method to ban specific player from roblox universe
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="userId">A Roblox user ID</param>
    /// <param name="universeId">A Roblox universe ID</param>
    /// <param name="duration">Duration of a ban in seconds</param>
    /// <param name="displayReason">Public reason of a ban</param>
    /// <param name="privateReason">A reason only for developers to see</param>
    /// <param name="excludeAlts">Should it ban alt accounts too or not</param>
    /// <returns>An Instance of <see cref="RestrictionData" /></returns>
    public static async Task<RestrictionData> BanUserFromUniverse(
        this IRobloxApiClient client,
        long userId,
        long universeId,
        long? duration = null,
        string displayReason = "You have been banned!",
        string? privateReason = null,
        bool? excludeAlts = false)
    {
        return await client.SetUserRestrictionsInUniverse(userId, universeId, true, DateTime.UtcNow, duration != null ? duration + "s" : null,
            displayReason, privateReason ?? displayReason, excludeAlts);
    }

    /// <summary>
    ///     Use this method to unban specific player of roblox universe
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="userId">A Roblox user ID</param>
    /// <param name="universeId">A Roblox universe ID</param>
    /// <returns>An Instance of <see cref="RestrictionData" /></returns>
    public static async Task<RestrictionData> UnbanUserFromUniverse(
        this IRobloxApiClient client,
        long userId,
        long universeId)
    {
        return await client.SetUserRestrictionsInUniverse(userId, universeId, false, DateTime.UtcNow, null, string.Empty,
            string.Empty, null);
    }
}