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
        Blockchain bc = new Blockchain();
        int naus = 0;
        int sim = 0;
        int skve = 0;
        public void Vote(Block block)
        {
            if(bc.IsValid())
                bc.AddBlock(block);

            if (block.GetData() == "1")
                sim += 1;
            if (block.GetData() == "2")
                naus += 1;
            if (block.GetData() == "3")
                skve += 1;

            Console.WriteLine("Nauseda: " + naus);
            Console.WriteLine("Simonyte: " + sim);
            Console.WriteLine("Skvernelis: " + skve);
            Console.WriteLine("---------------");
            Console.WriteLine("1. Simonyte");
            Console.WriteLine("2. Nauseda");
            Console.WriteLine("3. Skvernelis");
            Console.WriteLine("---------------");
            Console.Write(">");
        }
    }
}
