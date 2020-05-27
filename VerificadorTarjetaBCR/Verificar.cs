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
    public partial class Verificar : Form
    {
        List<string> values = new List<string>();
        public Verificar()
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

        private void Verificar_Load(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string card = Hash(txtCardNumber.Text.Trim());

            if (values.Contains(card))
                MessageBox.Show("Su tarjeta se encuentra entre los datos filtrados, póngase en contacto con el Banco");
            else
                MessageBox.Show("Su número de tarjeta no se encuentra en la lista de datos filtrados al 26 de mayo");
        }

        static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
