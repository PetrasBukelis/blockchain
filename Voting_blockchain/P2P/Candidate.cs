using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P
{
    class Candidate
    {
        public string id { set; get; }
        public string name { set; get; }
        public string votes { set; get; }

        public Candidate(string id, string name, string votes)
        {
            this.id = id;
            this.name = name;
            this.votes = votes;
        }

        public void AddVote()
        {
            votes = (Convert.ToInt32(votes) + 1).ToString();
        }
    }
}
