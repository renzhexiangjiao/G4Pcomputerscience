using System;
using System.Drawing;
using System.Windows.Forms;

namespace G4Pcs
{
    public partial class Form1 : Form
    {
        public static int groundLevel = 250;
        public static int fpr = 480;

        public bool ASAP = false;

        public int specimenIndex = 0;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            frameTimer.Start();
            fpsTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Joint joint in Joint.jointList)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Black), joint.getPosition().X - 4, joint.getPosition().Y - 4, 8, 8);
            }
            foreach (Bone bone in Bone.boneList)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), bone.getJoint1().getPosition(), bone.getJoint2().getPosition());
            }
            e.Graphics.DrawString("FPS:"+fps.ToString(), new Font(FontFamily.GenericSansSerif, 12f), new SolidBrush(Color.Black), 10, 10);       
        }

        int fps = 32;
        int fc;
        int prevfc = 0;
        private void frameTimer_OnTick(object sender, EventArgs e)
        {
            fc++;
            Update();
        }

        private new void Update()
        {
            foreach (Joint joint in Joint.jointList)
            {
                joint.updateAcceleration();
                joint.updateVelocity(fps);
                joint.updatePosition(fps);
            }
            this.Refresh();
        }

        private void fpsTimer_Tick(object sender, EventArgs e)
        {
            fps = fc - prevfc;
            prevfc = fc;
            this.Refresh();
        }

        private void Run()
        {
            if (ASAP)
            {
                for (int i = 0; i < fpr; i++)
                {
                    Update();
                }
            }
            else
            {

            }
            specimenIndex++;
        }
        private void Generation(int startIndex)
        {
            for(int i = startIndex; i < G4Pcs.Generation.generationSize; i++)
            {
                Run();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
             
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            player.Show();
        }
    }
}
