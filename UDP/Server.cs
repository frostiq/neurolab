using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace UDP
{
    public class Server
    {
        public event Func<object, object> OnProcess;

        private readonly UdpClient _udp;
        private Task _listenTask;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly BinarySerializer _serializer = new BinarySerializer();

        public Server(int port)
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

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
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
