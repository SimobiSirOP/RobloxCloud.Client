using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace RobloxCloudApi.Helpers;

internal static class ObjectExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: System.Diagnostics.CodeAnalysis.NotNull]
    internal static T ThrowIfNull<T>([NotNull] this T? value)
    {
        return value ?? throw new ArgumentNullException(null);
    }
}