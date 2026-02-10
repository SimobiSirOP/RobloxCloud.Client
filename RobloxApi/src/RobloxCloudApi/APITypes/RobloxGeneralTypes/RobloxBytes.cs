using RobloxCloudApi.Helpers;

namespace RobloxCloudApi.APITypes.RobloxGeneralTypes;

public struct RobloxBytes
{
    public string Bytes { get; set; }

    public RobloxBytes(object obj)
    {
        Bytes = Convert.ToBase64String(Serializer.ConvertObjectToBytes(obj));
    }

    public RobloxBytes(string bytes)
    {
        Span<Byte> span = new Byte[bytes.Length];
        if (Convert.TryFromBase64String(bytes, span, out _))
            throw new ArgumentException("Invalid Base64 string provided.");
        Bytes = bytes;
    }
}