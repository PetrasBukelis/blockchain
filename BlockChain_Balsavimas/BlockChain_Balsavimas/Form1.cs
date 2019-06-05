using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockChain_Balsavimas
{
    public partial class Form1 : Form
    {
        Blockchain bc = new Blockchain();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Blockchain bc = new Blockchain();
            bc.AddBlock(new Block(DateTime.Now, null, "{sender:Henry,receiver:MaHesh,amount:10}"));
            bc.AddBlock(new Block(DateTime.Now, null, "{sender:MaHesh,receiver:Henry,amount:5}"));
            bc.AddBlock(new Block(DateTime.Now, null, "{sender:Mahesh,receiver:Henry,amount:5}"));

            Console.WriteLine(JsonConvert.SerializeObject(bc, Formatting.Indented));
            Console.WriteLine($"Is Chain Valid: {bc.IsValid()}");

            Console.WriteLine($"Update amount to 1000");
            bc.chain[1].Data = "{sender:Henry,receiver:MaHesh,amount:1000}";

            Console.WriteLine($"Is Chain Valid: {bc.IsValid()}");
            bc.Chain[1].Hash = bc.Chain[1].CalculateHash();
            Console.WriteLine($"Update the entire chain");
            bc.Chain[2].PreviousHash = bc.Chain[1].Hash;
            bc.Chain[2].Hash = bc.Chain[2].CalculateHash();
            bc.Chain[3].PreviousHash = bc.Chain[2].Hash;
            bc.Chain[3].Hash = bc.Chain[3].CalculateHash();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
