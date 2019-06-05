using P2P;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Web;

namespace P2P
{
    public class Peer
    {
        private readonly AutoResetEvent _stopFlag = new AutoResetEvent(false);

        public IVoting Channel;
        public IVoting Host;

        public Peer()
        {
        }

        public void StartService()
        {
            var binding = new NetPeerTcpBinding();
            binding.Security.Mode = SecurityMode.None;

            var endpoint = new ServiceEndpoint(
                ContractDescription.GetContract(typeof(IVoting)),
                binding,
                new EndpointAddress("net.p2p://P2P"));

            Host = new VotingImplementation();

            _factory = new DuplexChannelFactory<IVoting>(
                new InstanceContext(Host),
                endpoint);

            var channel = _factory.CreateChannel();

            ((ICommunicationObject)channel).Open();
            Channel = channel;
        }
        public void StopService()
        {
            ((ICommunicationObject)Channel).Close();
            if (_factory != null)
                _factory.Close();
        }
        private DuplexChannelFactory<IVoting> _factory;
        public void Run()
        {
            StartService();
            _stopFlag.WaitOne();
            StopService();
        }

        public void Stop()
        {
            _stopFlag.Set();
        }
    }
}