using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain_Balsavimas
{
    class Kandidatas
    {
        private string name;
        private string img;
        private int votes;

        public Kandidatas(string name, string img)
        {
            this.name = name;
            this.img = img;
            votes = 0;
        }

        public string GetName()
        {
            return name;
        }

        public string GetImg()
        {
            return img;
        }

        public int GetVotes()
        {
            return votes;
        }

        public void AddVote()
        {
            votes += 1;
        }

        public void SetVotesToZero()
        {
            votes = 0;
        }
    }
}
