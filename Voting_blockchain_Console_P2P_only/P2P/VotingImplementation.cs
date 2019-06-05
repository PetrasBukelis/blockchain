using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace P2P
{
    public class VotingImplementation : IVoting
    {
        public void Vote(string message)
        {
            Console.WriteLine("new value: " + message);
        }
    }
}
