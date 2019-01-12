using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binary
{
    public partial class Form1 : Form
    {

        String FileName = "";

        public Form1()
        {
            InitializeComponent();
        }

        
        private void but_ToText_Click(object sender, EventArgs e)
        {
            //Accion que traducira el fichero.
            FileName = BoxFileName.Text;
            MessageBox.Show(FileName);
        }

    }
}
