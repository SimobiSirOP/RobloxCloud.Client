using JetBrains.Annotations;
using Microsoft.VisualBasic.CompilerServices;
using RobloxApi.Helpers;
using RobloxApi.Requests;
using RobloxApi.Requests.Restrictions;

namespace RobloxApi;

[PublicAPI]
public static partial class RobloxApiMethods
{
    /// <summary>
    /// <remarks>NOT IMPLEMENTED</remarks>
    /// Use this method to get one page of Restrictions
    /// </summary>
    /// <param name="client">An instance of <see cref="RobloxApiClient"/></param>
    /// <param name="universeId">A roblox universe id</param>
    /// <param name="maxPageSize">Maximum size of a page, see <see href="https://create.roblox.com/docs/cloud/reference/features/users#Cloud_ListUserRestrictions"/></param>
    /// <param name="pageToken">A page token, see <see href="https://create.roblox.com/docs/cloud/reference/features/users#Cloud_ListUserRestrictions"/></param>
    /// <returns>The instance of resulting request <see cref="ListUserRestrictionsRequest"/></returns>
    /// <
    public static async Task<ListUserRestrictionsRequest> ListRestrictedUsersInUniverse(
        this RobloxApiClient client,
        long universeId,
        int maxPageSize = 10,
        string pageToken = null!)
    {
        throw new NotImplementedException();
        return (await client.ThrowIfNull().SendRequest(new ListUserRestrictionsRequest()
        {
            UniverseId = universeId,
            MaxPageSize =  maxPageSize,
            PageToken = pageToken
        }))!;
    }
    
    
    
    public static async Task<RestrictionRequest> SetUserRestrictionsInUniverse(
        this RobloxApiClient client,
        long userId,
        long universeId,
        bool active,
        DateTime startTime,
        long? duration,
        string displayReason,
        string privateReason,
        bool excludeAlts = true)
    {
        return (await client.ThrowIfNull().SendRequest(new RestrictionRequest(
            universeId, userId, new GameJoinRestriction()
            {
                Active = active,
                StartTime = startTime,
                Duration = duration,
                DisplayReason = displayReason,
                PrivateReason = privateReason,
                ExcludeAltAccounts =  excludeAlts
            })))!;
    }
        
    public static async Task<RestrictionRequest> BanUserFromUniverse(
        this RobloxApiClient client,
        long userId,
        long universeId,
        long? duration = null,
        string displayReason = "You have been banned!",
        string? privateReason = null,
        bool excludeAlts = true)
    {
        return await client.SetUserRestrictionsInUniverse(userId, universeId, true, DateTime.UtcNow, duration, displayReason, privateReason ?? displayReason, excludeAlts);
    }

    public static async Task<RestrictionRequest> UnbanUserFromUniverse(
        this RobloxApiClient client,
        long userId,
        long universeId)
    {
        return await client.SetUserRestrictionsInUniverse(userId, universeId, false, DateTime.UtcNow, 0, string.Empty, string.Empty);
    }
}