using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UIContents.Models;

namespace ClientCommunicator.Implement
{
    public class ServerSimulatorClient : IClientSender
    {
        private ServerSimData simData;

        public ServerSimulatorClient(ServerSimData _data)
        {
            simData = _data;
        }

        public bool ConnectAsync(CancellationToken token)
        {
            bool result = true;
            try
            {
                Task.Delay(1000, token);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public void Dispose()
        {
            return;
        }

        public byte[] Write(byte[] sendBytes)
        {
            // TODO:指定された範囲を切り抜いて返す
            return  simData.OutData.ToArray(); 
        }
    }
}
