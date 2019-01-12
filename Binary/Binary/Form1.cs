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
        //private List<string> texto = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        
        private void but_ToText_Click(object sender, EventArgs e)
        {
            
            //Accion que traducira el fichero.
            FileName = BoxFileName.Text;
            //MessageBox.Show(FileName);
            pictureBox1.Visible=true;
            groupBox1.Visible = true;
            List<string> traduc=ReadBinary(FileName);
            textBox2.Visible = true;
            textBox2.AppendText(traduc.ToString());

        }

        static List<string> ReadBinary(string file)
        {
            List<string> texto = new List<string>();
            StreamReader sr = new StreamReader(file);
            int n = 0;
            while (n < 50)
            {
               
                texto.Add(BinaryToString(sr.ReadLine()));
                /*string tipo = BinaryToString(sr.ReadLine());
                switch(tipo){
                    case "string":

                        break;

                    case "int":

                        break;

                    case "float":

                        break;

                    case "double":

                        break;

                }
                n +=3;*/
            }

            sr.Close();
            return texto;
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
