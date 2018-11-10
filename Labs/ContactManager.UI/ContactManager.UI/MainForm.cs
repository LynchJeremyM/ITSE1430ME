using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show(this, "Jeremy Lynch\nITSE-140-20630\nContact Manager", "About", MessageBoxButtons.OK);
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            if (MessageBox.Show("Are you sure you want to exit?",
                "Close", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Close();
        }
    }
}
