using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Binary
{
    public partial class Form1 : Form
    {

        private String FileName = "";
        private String texto = "";
        //private List<string> texto = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        
        private void but_ToText_Click(object sender, EventArgs e)
        {
            //Accion que traducira el fichero.
            FileName = BoxFileName.Text;
            pictureBox1.Visible=true;
            groupBox1.Visible = true;
            //List<String> red=ReadBinary(FileName);
            //textBox2.Visible = true;
            //foreach (var i in red)
            //{
            //    textBox2.AppendText(i);
            //    textBox2.AppendText("\n");
            //}
            
            StreamReader sr = new StreamReader(FileName);
            int n = 0;
            while (n < 8)
            {
                string linea = sr.ReadLine();
                textBox1.AppendText(linea);
                n++;
            }
            sr.Close();

        }

        public static List<String> ReadBinary(string file)
        {
            List<string> tex = new List<string>();
            StreamReader sr = new StreamReader(file);
            int n = 0;
            while (n < 8)
            {
                string linea = sr.ReadLine();
                tex.Add(BinaryToString(linea)); 
                n++;
            }
            sr.Close();
            return tex;
        }

        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            List<String> red = ReadBinary(FileName);
            groupBox2.Visible = true;
            foreach (var i in red)
            {
                textBox2.AppendText(i);
                textBox2.AppendText("\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string te = textBox2.Text;
            string fileName_txt=textBox3.Text;
            StreamWriter sw = new StreamWriter(fileName_txt+".txt");
            foreach (var i in te)
            {
                sw.WriteLine(i);
            }
            sw.Close();
            MessageBox.Show("Save");
        }
    }
}
