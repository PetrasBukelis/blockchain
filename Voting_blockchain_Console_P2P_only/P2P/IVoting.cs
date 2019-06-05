using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace P2P
{
    [ServiceContract(CallbackContract = typeof(IVoting))]
    public interface IVoting
    {
        [OperationContract(IsOneWay = true)]
        void Vote(string message);
    }
}
