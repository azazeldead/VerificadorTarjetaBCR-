using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerificadorTarjetaBCR
{
    public partial class Encrypt : Form
    {
        public Encrypt()
        {
            InitializeComponent();
        }

        private void Encrypt_Load(object sender, EventArgs e)
        {
            string inputfile = (Application.StartupPath + @"\U.txt");
            string outputfile = (Application.StartupPath + @"\T.txt");

            if (File.Exists(inputfile))
            {
                string[] lines = File.ReadAllLines(inputfile);
                string[] hashlines = new string[lines.Length];

                for (int x = 0; x < lines.Length; x++)
                {
                    hashlines[x] = Hash.Hashing(lines[x]);
                }
                System.IO.File.WriteAllLines(outputfile, hashlines);
            }
        }
    }
}
