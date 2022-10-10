using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.Helpers;

#pragma warning disable SYSLIB0011

public static class BinaryHelpers
{
    public static byte[] ToBytes(object source)
    {
        using var stream = new MemoryStream();

        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, source);

        return stream.ToArray();
    }

    public static T ToOrigin<T>(byte[] source)
    {
        using var stream = new MemoryStream();
        stream.Write(source, 0, source.Length);
        stream.Seek(0, SeekOrigin.Begin);

        var formatter = new BinaryFormatter();
        return (T)formatter.Deserialize(stream);
    }
}
