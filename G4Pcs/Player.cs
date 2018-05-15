using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G4Pcs
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void Player_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
