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

namespace Streams1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Vyber soubor";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "Text files (TXT) | *.TXT";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                // Streamreader pro cteni streamu ze souboru
                // using blog pro automaticke uvolneni streamu a zavretie otvoreneho souboru


                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    string obsahSouboru = reader.ReadToEnd();
                    textBox2.Text = obsahSouboru;

                }


                using (StreamWriter writer = new StreamWriter(@"C:\Temp\KOPIE.TXT", true))
                {
                    //chceme aby neprepisoval ale do neho pridaval a pridal Velke pismena
                    writer.Write(textBox2.Text.ToUpper());

                }

            }

        }
    }
}
