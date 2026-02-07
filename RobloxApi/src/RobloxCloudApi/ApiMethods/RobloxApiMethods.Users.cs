using RobloxCloudApi.ApiTypes.UsersApi;
using RobloxCloudApi.ApiTypes.UsersApi.ResponseData;
using RobloxCloudApi.Helpers;
using RobloxCloudApi.Types;

namespace RobloxCloudApi;

public static partial class RobloxApiMethods
{
    /// <summary>
    /// Use this method to get a list of RobloxUsers from a list of Usernames
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="usernames">An array of roblox user usernames</param>
    /// <param name="excludeBannedUsers">Should it include banned users in search or not</param>
    /// <returns>An array of <see cref="RobloxUser"/></returns>
    public static async Task<RobloxUser[]> GetUsersFromUsernames(
        this IRobloxApiClient client, 
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
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="username">A Roblox user Username</param>
    /// <returns>A instance of <see cref="RobloxUser"/></returns>
    public static async Task<RobloxUser?> GetUserFromUsername(
        this IRobloxApiClient client,
        string username)
    {
        RobloxUser[] robloxUsers = await client.GetUsersFromUsernames([username]);
        if (robloxUsers.Length == 0) 
            return null;
        // Validating, because it also checks for previous usernames
        foreach (RobloxUser robloxUser in robloxUsers)
            if (robloxUser.Username.ToLower() == username.ToLower()) return robloxUser;
        return null;
    }
    
    /// <summary>
    /// Use this method to get a Roblox Users from array of userIds
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="userIds">An array of Roblox user IDs</param>
    /// <param name="excludeBannedUsers">Should it include banned users in search or not</param>
    /// <returns>An array of <see cref="RobloxUser"/></returns>
    public static async Task<RobloxUser[]> GetUsersFromIds(
        this IRobloxApiClient client,
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
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="userId">A Roblox user id</param>
    /// <returns>An instance of <see cref="RobloxFullUser"/></returns>
    public static async Task<RobloxFullUser> GetFullUserFromId(
        this IRobloxApiClient client,
        long userId)
    {
        return (await client.ThrowIfNull().SendRequest(new GetUserFromIdRequest(){
            UserId = userId
        }))!;
    }

    public static async Task<ThumbnailData> GenerateUserThumbnail(
        this IRobloxApiClient client,
        long userId,
        ThumbnailData.ThumbnailSize size = ThumbnailData.ThumbnailSize.Size420,
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