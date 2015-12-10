using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace NeuroServer.Udp
{
    public class Server: IDisposable
    {
        public event Func<object, object> OnProcess;

        private UdpClient _udp;
        private Task _listenTask;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly BinarySerializer _serializer = new BinarySerializer();

        public void Init(int port)
        {
            _udp = new UdpClient(port);
            var token = _cancellationTokenSource.Token;
            _listenTask = new Task(() => Listen(token), token);
            OnProcess += o => o;
        }

        public void Start()
        {
            _listenTask.Start();
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }

        public void Dispose()
        {
            Stop();
            _udp.Dispose();
            _serializer.Dispose();
        }

        private void Listen(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                IPEndPoint endPoint = null;
                var bytes = _udp.Receive(ref endPoint);
                Task.Run(() => RawProcess(bytes, endPoint), token);
            }
            _udp.Close();
        }

        private void RawProcess(byte[] bytes, IPEndPoint endPoint)
        {
            var obj = _serializer.Deserialize<object>(bytes);
            var res = OnProcess(obj);
            bytes = _serializer.Serialize(res);
            _udp.Send(bytes, bytes.Length, endPoint);
        }
    }
}
