using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerificadorTarjetaBCR
{
    public partial class Verify : Form
    {
        List<string> values = new List<string>();
        public Verify()
        {
            InitializeComponent();
        }
        private void LoadFile()
        {
            string file = (Application.StartupPath + @"\T.txt");

            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                values = lines.ToList();
            }
        }

      

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string card = Hash.Hashing(txtCardNumber.Text.Trim());

            if (values.Contains(card))
                MessageBox.Show("Su tarjeta se encuentra entre los datos filtrados, póngase en contacto con el Banco");
            else
                MessageBox.Show("Su número de tarjeta no se encuentra en la lista de datos filtrados al 25 de mayo");
        }

        private void Verify_Load(object sender, EventArgs e)
        {
            LoadFile();
        }
    }
}
