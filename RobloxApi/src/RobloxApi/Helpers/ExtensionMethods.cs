using System.Runtime.CompilerServices;

namespace RobloxApi.Helpers;

internal static class ObjectExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static T ThrowIfNull<T>(this T? value) => value ?? throw new ArgumentNullException(null);
}