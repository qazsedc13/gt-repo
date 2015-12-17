using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtilites
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TSMIExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TSMIAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа мои утилиты, содержит ряд небольших программ, которые могут пригодиться в жизни. \nА главное научить меня основам программирования на C#.\nАвтор Ковалёв Н.И.","О программе");
        }
    }
}
