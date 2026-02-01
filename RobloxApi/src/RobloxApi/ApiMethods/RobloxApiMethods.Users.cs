using RobloxApi.ApiTypes.UsersApi;
using RobloxApi.ApiTypes.UsersApi.ResponseData;
using RobloxApi.Helpers;
using RobloxApi.Types;

namespace RobloxApi;

public static partial class RobloxApiMethods
{
    /// <summary>
    /// Use this method to get a list of RobloxUsers from a list of Usernames
    /// </summary>
    /// <param name="client">An instance of <see cref="RobloxApiClient"/></param>
    /// <param name="usernames">An array of roblox user usernames</param>
    /// <param name="excludeBannedUsers">Should it include banned users in search or not</param>
    /// <returns>An array of <see cref="RobloxUser"/></returns>
    public static async Task<RobloxUser[]> GetUsersFromUsernames(
        this RobloxApiClient client, 
        string[] usernames,
        bool excludeBannedUsers = true
    )
    {
        return (await client.ThrowIfNull().SendRequest(new GetUsersFromUsernamesRequest()
        {
            Usernames = usernames,
            ExcludeBannedUsers = excludeBannedUsers
        }))!;
    }
        
    /// <summary>
    /// Use this method to get a user from Roblox username
    /// </summary>
    /// <param name="client">An instance of <see cref="RobloxApiClient"/></param>
    /// <param name="username">A Roblox user Username</param>
    /// <returns>A instance of <see cref="RobloxUser"/></returns>
    public static async Task<RobloxUser?> GetUserFromUsername(
        this RobloxApiClient client,
        string username)
    {
        RobloxUser[] robloxUsers = await client.GetUsersFromUsernames([username]);
        if (robloxUsers.Length == 0) 
            return null;
        // Validating, because it also checks for previous usernames
        foreach (RobloxUser robloxUser in robloxUsers)
            if (robloxUser.Username == username) return robloxUser;
        return null;
    }
    
    /// <summary>
    /// Use this method to get a Roblox Users from array of userIds
    /// </summary>
    /// <param name="client">An instance of <see cref="RobloxApiClient"/></param>
    /// <param name="userIds">An array of Roblox user IDs</param>
    /// <param name="excludeBannedUsers">Should it include banned users in search or not</param>
    /// <returns>An array of <see cref="RobloxUser"/></returns>
    public static async Task<RobloxUser[]> GetUsersFromIds(
        this RobloxApiClient client,
        long[] userIds,
        bool excludeBannedUsers = true)
    {
        return (await client.ThrowIfNull().SendRequest(new GetUsersFromIdsRequest()
        {
            UserIds = userIds,
            ExcludeBannedUsers = excludeBannedUsers
        }))!;
    }
    
    /// <summary>
    /// Use this method to get full info of a User
    /// </summary>
    /// <param name="client">An instance of <see cref="RobloxApiClient"/></param>
    /// <param name="userId">A Roblox user id</param>
    /// <returns>An instance of <see cref="RobloxFullUser"/></returns>
    public static async Task<RobloxFullUser> GetFullUserFromId(
        this RobloxApiClient client,
        long userId)
    {
        return (await client.ThrowIfNull().SendRequest(new GetUserFromIdRequest(){
            UserId = userId
        }))!;
    }

    public static async Task<ThumbnailData> GenerateUserThumbnail(
        this RobloxApiClient client,
        long userId,
        int size = 420,
        ThumbnailData.ThumbnailFormat format = ThumbnailData.ThumbnailFormat.PNG,
        ThumbnailData.ThumbnailShape shape = ThumbnailData.ThumbnailShape.ROUND)
    {
        return (await client.ThrowIfNull().SendRequest(new GenerateUserThumbnailRequest()
        {
            UserId = userId,
            Size = size,
            Format = format,
            Shape = shape
        }))!;
    }
}