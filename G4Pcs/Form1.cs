using System;
using System.Drawing;
using System.Windows.Forms;

namespace G4Pcs
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Initialize();
            this.DoubleBuffered = true;
            frameTimer.Start();
            fpsTimer.Start();
        }

        private void Initialize()
        {
            Joint.jointList.Add(new Joint(1, 30, 250));       
            Joint.jointList.Add(new Joint(1, 75, 250));
            Joint.jointList.Add(new Joint(1, 75, 200));
            Joint.jointList.Add(new Joint(1, 150, 125));
            Joint.jointList.Add(new Joint(1, 225, 200));
            Joint.jointList.Add(new Joint(1, 225, 250));
            Joint.jointList.Add(new Joint(1, 270, 250));
            Joint.jointList.Add(new Joint(1, 150, 50));
            Joint.jointList.Add(new Joint(1, 85, 70));
            Joint.jointList.Add(new Joint(1, 20, 50));
            Joint.jointList.Add(new Joint(1, 215, 70));
            Joint.jointList.Add(new Joint(1, 280, 50));
            Bone.boneList.Add(new Bone(1, Joint.jointList[0], Joint.jointList[1]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[1], Joint.jointList[2]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[2], Joint.jointList[3]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[3], Joint.jointList[4]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[4], Joint.jointList[5]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[5], Joint.jointList[6]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[3], Joint.jointList[7]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[7], Joint.jointList[8]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[8], Joint.jointList[9]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[7], Joint.jointList[10]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[10], Joint.jointList[11]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[0], sigmoid(Joint.jointList[0].getPosition().Y)));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[1], sigmoid(Joint.jointList[1].getPosition().Y)));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[2], sigmoid(Joint.jointList[2].getPosition().Y)));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[3], sigmoid(Joint.jointList[3].getPosition().Y)));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[4], sigmoid(Joint.jointList[4].getPosition().Y)));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[5], sigmoid(Joint.jointList[5].getPosition().Y)));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[6], sigmoid(Joint.jointList[6].getPosition().Y)));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[7], sigmoid(Joint.jointList[7].getPosition().Y)));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[8], sigmoid(Joint.jointList[8].getPosition().Y)));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[9], sigmoid(Joint.jointList[9].getPosition().Y)));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[10], sigmoid(Joint.jointList[10].getPosition().Y)));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[11], sigmoid(Joint.jointList[11].getPosition().Y)));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Joint joint in Joint.jointList)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Black), joint.getPosition().X - 5, joint.getPosition().Y - 5, 10, 10);
            }
            foreach (Bone bone in Bone.boneList)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), bone.getJoint1().getPosition(), bone.getJoint2().getPosition());
            }
            e.Graphics.DrawString(fps.ToString(), new Font(FontFamily.GenericSansSerif, 12f), new SolidBrush(Color.Black), 10, 10);
            e.Graphics.DrawString(Joint.jointList[2].velocity.getValue().ToString(), new Font(FontFamily.GenericSansSerif, 12f), new SolidBrush(Color.Black), 10, 24);
            e.Graphics.DrawString(Joint.jointList[2].acceleration.getValue().ToString(), new Font(FontFamily.GenericSansSerif, 12f), new SolidBrush(Color.Black), 10, 38);
            e.Graphics.DrawString(Gravity.gravityList[0].getValue().ToString(), new Font(FontFamily.GenericSansSerif, 12f), new SolidBrush(Color.Black), 10, 52);
        }

        int fps = 32;
        int fc;
        int prevfc = 0;
        private void frameTimer_OnTick(object sender, EventArgs e)
        {
            fc++;
            foreach(Joint joint in Joint.jointList)
            {
                joint.updateAcceleration();
                joint.updateVelocity(fps);
                joint.updatePosition(fps);
            }
            foreach(Gravity gravity in Gravity.gravityList)
            {
                gravity.update(sigmoid(gravity.getPatient().getPosition().Y));
            }
            this.Refresh();
        }

        private void fpsTimer_Tick(object sender, EventArgs e)
        {
            fps = fc - prevfc;
            prevfc = fc;
            this.Refresh();
        }

        private double sigmoid(int position)
        {
            return 6.371E6 * Math.Tanh(250 - position);
        }
    }
}
