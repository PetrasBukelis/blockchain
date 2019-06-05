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
        List<Candidate> candi = new List<Candidate>()
        {
            new Candidate("1", "Simonyte", "0"),
            new Candidate("2", "Nauseda", "0"),
            new Candidate("3", "Skvernelis", "0")
        };
        List<Candidate> orderedCandi = new List<Candidate>();
        private Blockchain bc = new Blockchain();

        public void Vote(Block block)
        {
            if(bc.IsValid())
                bc.AddBlock(block);

            Console.WriteLine("-----RESULTS-----");
            foreach (Candidate can in candi)
            {
                if (block.GetData() == can.id) can.AddVote();
            }
            orderedCandi = candi.OrderByDescending(order => order.votes).ToList();
            foreach (Candidate can in orderedCandi)
            {
                Console.WriteLine(can.name + " " + can.votes);
            }
            Console.WriteLine("");
            Console.WriteLine("---WRITE NUMBER---");
            foreach (Candidate can in candi)
            {
                Console.WriteLine(can.id + ". " + can.name);
            }
            Console.WriteLine("---------------");
            Console.Write(">");
        }
        
    }
}
