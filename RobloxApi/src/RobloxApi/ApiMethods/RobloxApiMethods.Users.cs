using RobloxApi.ApiTypes.UsersApi;
using RobloxApi.Helpers;
using RobloxApi.Types;

namespace RobloxApi;

public static partial class RobloxApiMethods
{
    public static async Task<RobloxUser[]> GetUsersFromUsernames(
        this RobloxApiClient client, 
        string[ ] usernames,
        bool excludeBannedUsers = true
    )
    {
        return (await client.ThrowIfNull().SendRequest(new GetUsersFromUsernamesRequest()
        {
            Usernames = usernames,
            ExcludeBannedUsers = excludeBannedUsers
        }))!;
    }
        
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

    public static async Task<RobloxUser?> GetUserFromId(
        this RobloxApiClient client,
        long userId)
    {
        return await client.ThrowIfNull().SendRequest(new GetUserFromIdRequest(){
            UserId = userId
        });
    }
}