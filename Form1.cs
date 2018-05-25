using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Antivira
{
    public partial class AntiviraUI : Form
    {

        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

        public AntiviraUI()
        {
            InitializeComponent();
            pictureBox1.Image = Antivira.Properties.Resources.virenscan;
        }


        public DialogResult showWithData()
        {
            DialogResult dlr = ShowDialog();
            return dlr;
        }
    }
}
