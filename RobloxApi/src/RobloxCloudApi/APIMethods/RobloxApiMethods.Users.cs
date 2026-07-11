using RobloxCloudApi.RobloxCloudApi.APIRequests.UsersApi.Requests;
using RobloxCloudApi.RobloxCloudApi.APITypes;
using RobloxCloudApi.RobloxCloudApi.APITypes.ListTypes;
using RobloxCloudApi.RobloxCloudApi.APITypes.Operations;
using RobloxCloudApi.RobloxCloudApi.Helpers;

namespace RobloxCloudApi.RobloxCloudApi.APIMethods;

public static partial class RobloxApiMethods
{
    /// <summary>
    ///     Use this method to get a list of RobloxUsers from a list of Usernames
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="usernames">An array of roblox user usernames</param>
    /// <param name="excludeBannedUsers">Should it include banned users in search or not</param>
    /// <returns>An array of <see cref="RobloxUser" /></returns>
    public static async Task<RobloxUserList> GetUsersFromUsernames(
        this IRobloxApiClient client,
        string[] usernames,
        bool excludeBannedUsers = true
    )
    {
        return (await client.ThrowIfNull().SendRequest(new GetUsersFromUsernamesRequest
        {
            Usernames = usernames,
            ExcludeBannedUsers = excludeBannedUsers
        }))!;
    }

    /// <summary>
    ///     Use this method to get a user from Roblox username
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="username">A Roblox user Username</param>
    /// <returns>A instance of <see cref="RobloxUser" /></returns>
    public static async Task<RobloxUser?> GetUserFromUsername(
        this IRobloxApiClient client,
        string username)
    {
        var robloxUsers = (await client.GetUsersFromUsernames([username])).List;
        if (robloxUsers!.Length == 0)
            return null;
        // Validating, because it also checks for previous usernames
        foreach (var robloxUser in robloxUsers)
            if (robloxUser.Username!.ToLower() == username.ToLower())
                return robloxUser;
        return null;
    }

    /// <summary>
    ///     Use this method to get a Roblox Users from array of userIds
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="userIds">An array of Roblox user IDs</param>
    /// <param name="excludeBannedUsers">Should it include banned users in search or not</param>
    /// <returns>An array of <see cref="RobloxUser" /></returns>
    public static async Task<RobloxUser[]> GetUsersFromIds(
        this IRobloxApiClient client,
        long[] userIds,
        bool excludeBannedUsers = true)
    {
        return (await client.ThrowIfNull().SendRequest(new GetUsersFromIdsRequest
        {
            UserIds = userIds,
            ExcludeBannedUsers = excludeBannedUsers
        }))!;
    }

    /// <summary>
    ///     Use this method to get full info of a User
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="userId">A Roblox user id</param>
    /// <returns>An instance of <see cref="RobloxFullUser" /></returns>
    public static async Task<RobloxFullUser> GetFullUserFromId(
        this IRobloxApiClient client,
        long userId)
    {
        return (await client.ThrowIfNull().SendRequest(new GetUserFromIdRequest
        {
            UserId = userId
        }))!;
    }

    public static async Task<RobloxOperation> GenerateUserThumbnail(
        this IRobloxApiClient client,
        long userId,
        RobloxThumbnailSize size = RobloxThumbnailSize.Size420,
        RobloxThumbnailFormat format = RobloxThumbnailFormat.PNG,
        RobloxThumbnailShape shape = RobloxThumbnailShape.ROUND)
    {
        var uncompletedOperation = (await client.ThrowIfNull().SendRequest(new GenerateUserThumbnailRequest
        {
            UserId = userId,
            Size = size,
            Format = format,
            Shape = shape
        }))!;
        return await uncompletedOperation.WaitForCompletionAsync<RobloxOperation>(client)!;
    }
}