using System;
using System.IO;
using ProtoBuf;

namespace NeuroServer.Udp
{
    public class BinarySerializer : ISerializer, IDisposable
    {
        private readonly MemoryStream _stream = new MemoryStream();

        public byte[] Serialize<T>(T entity)
        {
            Serializer.Serialize(_stream, entity);
            var res = _stream.ToArray();
            _stream.Seek(0, SeekOrigin.Begin);
            return res;
        }

        public T Deserialize<T>(byte[] bytes)
        {
            _stream.Write(bytes, 0, bytes.Length);
            var res = Serializer.Deserialize<T>(_stream);
            _stream.Seek(0, SeekOrigin.Begin);
            return res;
        }

        public void Dispose()
        {
            _stream.Dispose();
        }
    }
}
