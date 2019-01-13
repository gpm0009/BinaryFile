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
            FileStream fs= File.Create("Hola.txt");
            fs.Close();
            //Accion que traducira el fichero.
            FileName = BoxFileName.Text;
            //MessageBox.Show(FileName);
            pictureBox1.Visible=true;
            groupBox1.Visible = true;
            List<String> red=ReadBinary(FileName);
            textBox2.Visible = true;
            foreach (var i in red)
            {
                textBox2.AppendText(i);
                textBox2.AppendText("\n");
            }
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
    }
}
