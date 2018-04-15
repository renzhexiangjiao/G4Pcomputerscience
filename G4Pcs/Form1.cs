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

        public Form1()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            Joint[] joints = new Joint[12];
            joints[0] = new Joint(0, 0);
            joints[1] = new Joint(0, 0);
            joints[2] = new Joint(0, 0);
            joints[3] = new Joint(0, 0);
            joints[4] = new Joint(0, 0);
            joints[5] = new Joint(0, 0);
            joints[6] = new Joint(0, 0);
            joints[7] = new Joint(0, 0);
            joints[8] = new Joint(0, 0);
            joints[9] = new Joint(0, 0);
            joints[10] = new Joint(0, 0);
            joints[11] = new Joint(0, 0);
            Bone[] bones = new Bone[11];
            bones[0] = new Bone(joints[0], joints[1]);
            bones[1] = new Bone(joints[1], joints[2]);
            bones[2] = new Bone(joints[2], joints[3]);
            bones[3] = new Bone(joints[3], joints[4]);
            bones[4] = new Bone(joints[4], joints[5]);
            bones[5] = new Bone(joints[5], joints[6]);
            bones[6] = new Bone(joints[3], joints[7]);
            bones[7] = new Bone(joints[7], joints[8]);
            bones[8] = new Bone(joints[8], joints[9]);
            bones[9] = new Bone(joints[7], joints[10]);
            bones[10] = new Bone(joints[10], joints[11]);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = null;
            //paint(g, coords);
        }

        private void paint(Graphics g, Point[,] coords)
        {

        }
    }
}
