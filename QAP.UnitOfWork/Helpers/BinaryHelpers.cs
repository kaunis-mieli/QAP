using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace QAP.UnitOfWork.Helpers;

#pragma warning disable SYSLIB0011

public static class BinaryHelpers
{
    public static byte[] ToBytes(object source)
    {
        using var stream = new MemoryStream();

        new BinaryFormatter().Serialize(stream, source);

        return stream.ToArray();
    }

    public static T ToOrigin<T>(byte[] source)
    {
        using var stream = new MemoryStream();
        stream.Write(source, 0, source.Length);
        stream.Seek(0, SeekOrigin.Begin);

        return (T)new BinaryFormatter().Deserialize(stream);
    }

    public static byte[] GetHash(IEnumerable<byte> source)
    {
        using var hasher = SHA256.Create();
        return hasher.ComputeHash(source.ToArray());
    }
}
