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
    public partial class Form1 : Form
    {
        Point[,] coords = new Point[2,10];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = new Graphics();
            paint(g, coords);
        }

        private void paint(Graphics g, Point[,] coords)
        {

        }
    }
}
