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
            Initialize();
        }

        Joint[] joints = new Joint[12];
        Bone[] bones = new Bone[11];

        private void Initialize()
        {
            //Joint[] joints = new Joint[12];
            joints[0] = new Joint(1, 30, 250);
            joints[1] = new Joint(1, 75, 250);
            joints[2] = new Joint(1, 75, 200);
            joints[3] = new Joint(1, 150, 125);
            joints[4] = new Joint(1, 225, 200);
            joints[5] = new Joint(1, 225, 250);
            joints[6] = new Joint(1, 270, 250);
            joints[7] = new Joint(1, 150, 50);
            joints[8] = new Joint(1, 85, 70);
            joints[9] = new Joint(1, 20, 50);
            joints[10] = new Joint(1, 215, 70);
            joints[11] = new Joint(1, 280, 50);
            //Bone[] bones = new Bone[11];
            bones[0] = new Bone(1, joints[0], joints[1]);
            bones[1] = new Bone(1, joints[1], joints[2]);
            bones[2] = new Bone(1, joints[2], joints[3]);
            bones[3] = new Bone(1, joints[3], joints[4]);
            bones[4] = new Bone(1, joints[4], joints[5]);
            bones[5] = new Bone(1, joints[5], joints[6]);
            bones[6] = new Bone(1, joints[3], joints[7]);
            bones[7] = new Bone(1, joints[7], joints[8]);
            bones[8] = new Bone(1, joints[8], joints[9]);
            bones[9] = new Bone(1, joints[7], joints[10]);
            bones[10] = new Bone(1, joints[10], joints[11]);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            paint(g, joints, bones);
        }

        private void paint(Graphics g, Joint[] joints, Bone[] bones)
        {
            foreach(Joint joint in joints)
            {
                g.DrawEllipse(new Pen(Color.Black), joint.getPosition().X - 5, joint.getPosition().Y - 5, 10, 10);
            }
            foreach(Bone bone in bones)
            {
                g.DrawLine(new Pen(Color.Black), bone.getJoint1().getPosition(), bone.getJoint2().getPosition());
            }
        }
    }
}
