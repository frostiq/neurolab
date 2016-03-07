using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NeuroServer.Udp
{
    public class BinarySerializer : ISerializer, IDisposable
    {
        private static readonly BinaryFormatter _formatter = new BinaryFormatter();

        public byte[] Serialize<T>(T entity)
        {
            using (var stream = new MemoryStream())
            {
                _formatter.Serialize(stream, entity);
                return stream.ToArray();
            }
        }

        public T Deserialize<T>(byte[] bytes)
        {
            using (var stream = new MemoryStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Position = 0;
                return (T)_formatter.Deserialize(stream);
            }
        }

        public void Dispose()
        {
            //_stream.Dispose();
        }
    }
}
