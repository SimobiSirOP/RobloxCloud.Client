using RobloxCloudApi.RobloxCloudApi.APIRequests.LuauExecution;
using RobloxCloudApi.RobloxCloudApi.APIRequests.RequestHelpers;
using RobloxCloudApi.RobloxCloudApi.APIRequests.UniverseData.PlacesApi;
using RobloxCloudApi.RobloxCloudApi.APIRequests.UniverseData.UniverseApi;
using RobloxCloudApi.RobloxCloudApi.APITypes;
using RobloxCloudApi.RobloxCloudApi.APITypes.ListTypes;
using RobloxCloudApi.RobloxCloudApi.APITypes.Operations;
using RobloxCloudApi.RobloxCloudApi.APITypes.RobloxGeneralTypes;
using RobloxCloudApi.RobloxCloudApi.ErrorHandling.Exceptions;
using RobloxCloudApi.RobloxCloudApi.Helpers;

namespace RobloxCloudApi.RobloxCloudApi.APIMethods;

public static partial class RobloxApiMethods
{
    /// <summary>
    /// Get a list of places in a universe.
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="universeId">A Roblox Universe ID</param>
    /// <param name="isUniverseCreation">Is universe being created</param>
    /// <param name="maxPageSize">Maximum size of page list</param>
    /// <param name="cursor">Cursor to next page  of places list</param>
    /// <param name="sortOrder">Sort order of list of places</param>
    /// <returns>A instance of <see cref="PlaceInfoList"/></returns>
    public static async Task<PlaceInfoList> GetUniversePlaces(
        this IRobloxApiClient client,
        long universeId,
        bool? isUniverseCreation = false,
        int maxPageSize = 10,
        string? cursor = null,
        SortOrder sortOrder = SortOrder.Asc)
    {
        return (await client.ThrowIfNull().SendRequest(new GetUniversePlacesRequest
        {
            UniverseId = universeId,
            IsUniverseCreation = isUniverseCreation,
            MaxPageSize = maxPageSize,
            Cursor = cursor,
            SortOrder = sortOrder
        }))!;
    }

    
    /// <summary>
    /// Get a universe
    /// </summary>
    /// <param name="client">A instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="universeId">A Roblox Universe ID</param>
    /// <returns>A instance of <see cref="RobloxUniverse" /></returns>
    public static async Task<RobloxUniverse> GetUniverse(this IRobloxApiClient client, long universeId)
    {
        return (await client.ThrowIfNull().SendRequest(
            new GetUniverseRequest()
            {
                UniverseId = universeId
            }))!;
    }
    
    
    /// <summary>
    /// Publishes a message to a universe
    /// </summary>
    /// <param name="client">A instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="universeId">A roblox universe id</param>
    /// <param name="message">A message to send</param>
    /// <param name="topic">Topic of the sent message</param>
    public static async Task PublishUniverseMessage(this IRobloxApiClient client, long universeId, string message, string topic = "Unknown")
    {
        await client.ThrowIfNull().SendRequest(
            new PublishUniverseMessageRequest()
            {
                UniverseId = universeId,
                Message = message,
                Topic = topic
            });
    }

    /// <summary>
    /// Restarts the universe's servers
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="universeId">The ID of the universe</param>
    /// <param name="placeIds">Optional array of place IDs</param>
    /// <param name="closeAllVersions">Flag that specifies if all versions should be closed</param>
    /// <param name="bleedOffServer">Flag to bleed off servers.</param>
    /// <param name="bleedOffDurationMinutes">Duration in minutes for bleeding-off servers</param>
    /// <exception cref="RobloxApiException">Error that occurs during a request to Roblox API</exception>
    public static async Task RestartUniverseServers(
        this IRobloxApiClient client,
        long universeId,
        long[]? placeIds = null,
        bool? closeAllVersions = null,
        bool? bleedOffServer = null,
        long? bleedOffDurationMinutes = null)
    {
        if (bleedOffServer != null && bleedOffDurationMinutes == null)
            throw new RobloxApiException("bleedOffDurationMinutes must be provided when bleedOffServer is true");

        await client.ThrowIfNull().SendRequest(
            new RestartUniverseServersRequest()
            {
                BleedOffDurationMinutes = bleedOffDurationMinutes,
                BleedOffServers = bleedOffServer,
                CloseAllVersions = closeAllVersions,
                PlaceIds = placeIds,
                UniverseId = universeId
            });
    }

    /// <summary>
    /// Updates a universe
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="universe">An instance of <see cref="RobloxUniverse"/></param>
    /// <returns>A updated instance of <see cref="RobloxUniverse"/></returns>
    /// <exception cref="RobloxApiException">Error that occures because of invalid API request</exception>
    public static async Task<RobloxUniverse> UpdateUniverse(this IRobloxApiClient client, RobloxUniverse universe)
    {
        if (universe.UniverseId == 0)
            throw new RobloxApiException("Universe ID must be provided");

        return (await client.ThrowIfNull().SendRequest(new UpdateUniverseRequest()
        {
            UniverseId = universe.UniverseId,
            DisplayName = universe.DisplayName,
            Description = universe.Description,
            User = universe.User,
            Group = universe.Group,
            Visibility = universe.Visibility,
            FacebookSocialLink = universe.FacebookSocialLink,
            TwitterSocialLink = universe.TwitterSocialLink,
            YoutubeSocialLink = universe.YoutubeSocialLink,
            TwitchSocialLink = universe.TwitchSocialLink,
            DiscordSocialLink = universe.DiscordSocialLink,
            GuildedSocialLink = universe.GuildedSocialLink,
            RobloxGroupSocialLink = universe.RobloxGroupSocialLink,
            AgeRating = universe.AgeRating,
            ConsoleEnabled = universe.ConsoleEnabled,
            DesktopEnabled = universe.DesktopEnabled,
            MobileEnabled = universe.MobileEnabled,
            TabletEnabled = universe.TabletEnabled,
            VoiceChatEnabled = universe.VoiceChatEnabled,
            VrEnabled = universe.VrEnabled,
            PrivateServerPriceRobux = universe.PrivateServerPriceRobux,
            TemplateRootPlace = universe.RootPlace
        }))!;
    }

    /// <summary>
    /// Executes a Luau script in a specific place within a Roblox universe.
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient"/></param>
    /// <param name="universeId">The ID of the Roblox universe</param>
    /// <param name="placeId">The ID of the place within the universe</param>
    /// <param name="script">The Luau script to execute. This should be null if binary input is provided.</param>
    /// <param name="timeout">The timeout duration for the script execution process.</param>
    /// <param name="returnErrorsInstead">Indicates whether to return errors instead of throwing exceptions.</param>
    /// <param name="enableBinaryOutput">Specifies whether the execution should produce binary output.</param>
    /// <param name="binaryInput">Optional binary input for the execution in place of a script.</param>
    /// <returns>An instance of <see cref="LuauExecutionOperation"/></returns>
    public static async Task<LuauExecutionOperation> RunLuauExecution(
        this IRobloxApiClient client,
        long universeId,
        long placeId,
        string? script,
        RobloxDuration timeout,
        bool returnErrorsInstead = false,
        bool enableBinaryOutput = false,
        RobloxBinary? binaryInput = null)
    {
        var output = new object();
        object? error = null;
        if (returnErrorsInstead)
        {
            output = null;
            error = new object();
        }

        var startOperation = await client.ThrowIfNull().SendRequest(
            new CreateLuauExecutionRequest
            {
                UniverseId = universeId,
                PlaceId = placeId,
                Timeout = timeout,
                Script = script,
                Output = output,
                Error = error,
                BinaryInput = binaryInput,
                EnableBinaryOutput = enableBinaryOutput
            })!;
        return await startOperation!.WaitForCompletionAsync<LuauExecutionOperation>(client);
    }

    /// <summary>
    /// Retrieves a list of Luau execution logs for a specific operation in a Roblox Universe.
    /// </summary>
    /// <param name="client">An instance of <see cref="IRobloxApiClient" /></param>
    /// <param name="operation">The Luau execution operation</param>
    /// <param name="pageToken">An optional token to fetch a specific page of logs. Can be null to fetch the first page.</param>
    /// <param name="maxPageSize">The maximum number of log entries to include in a single page.</param>
    /// <param name="view">The view format of logs (e.g., flat or structured).</param>
    /// <returns>An instance of <see cref="LuauExecutionLogList" /></returns>
    public static async Task<LuauExecutionLogList> GetLuauExecutionLog(
        this IRobloxApiClient client,
        LuauExecutionOperation operation,
        string? pageToken = null,
        int maxPageSize = 10,
        LuauLogView view = LuauLogView.FLAT
    )
    {
        const string domain = "https://apis.roblox.com/cloud/v2/";

        var requestUrl = domain + operation.RequestPath;

        var request = new GetLuauExecutionLogsRequest(requestUrl)
        {
            MaxPageSize = maxPageSize,
            PageToken = pageToken,
            View = view
        };
        return (await client.ThrowIfNull().SendRequest(request))!;
    }
}