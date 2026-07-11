using System.Runtime.CompilerServices;

namespace RobloxCloudApi.RobloxCloudApi.Helpers;

internal static class ObjectExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static T ThrowIfNull<T>(this T? value)
    {
        return value ?? throw new ArgumentNullException(null);
    }
}