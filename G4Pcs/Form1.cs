using System;
using System.Drawing;
using System.Windows.Forms;

namespace G4Pcs
{
    public partial class Form1 : Form
    {
        public static int groundLevel = 250;
        public static int fpr = 480;

        public int updateCount = 0;

        public bool ASAP = false;

        public int specimenIndex = 0;
        public int generationIndex = 0;

        private Specimen currentSpecimen;
        private Generation currentGeneration;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            currentSpecimen = new Specimen();
            frameTimer.Start();
            fpsTimer.Start();
            Generation();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!ASAP)
            {
                foreach (Joint joint in currentSpecimen.jointList)
                {
                    e.Graphics.FillEllipse(new SolidBrush(Color.Black), joint.getPosition().X - 4, joint.getPosition().Y - 4, 8, 8);
                }
                foreach (Bone bone in currentSpecimen.boneList)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black), bone.getJoint1().getPosition(), bone.getJoint2().getPosition());
                }
                e.Graphics.DrawString("FPS:" + fps.ToString(), new Font(FontFamily.GenericSansSerif, 12f), new SolidBrush(Color.Black), 10, 10);
            }
            e.Dispose();
        }

        int fps = 32;
        int fc;
        int prevfc = 0;
        private void frameTimer_OnTick(object sender, EventArgs e)
        {
            fc++;
            Update();
            if(updateCount>=fpr)
            {
                Run();
            }
        }

        private new void Update()
        {
            updateCount++;
            label1.Text = "Generation:" + generationIndex;
            label2.Text = "Specimen:" + specimenIndex;
            //foreach (Joint joint in currentSpecimen.jointList)
            //{
            //    joint.updateAcceleration(currentSpecimen);
            //    if(!ASAP)
            //    {
            //        joint.updateVelocity(fps);
            //        joint.updatePosition(fps);
            //    }
            //    else
            //    {
            //        joint.updateVelocity(32);
            //        joint.updatePosition(32);
            //    }
            //}
            if (!ASAP)
                currentSpecimen.Update(fps);
            else
                currentSpecimen.Update(32);
            this.Invalidate();
        }

        private void fpsTimer_Tick(object sender, EventArgs e)
        {
            fps = fc - prevfc;
            prevfc = fc;
            this.Invalidate();
        }

        private void Run()
        {
            currentSpecimen = currentGeneration.getSpecimen(specimenIndex);
            if (ASAP)
            {
                for (int i = 0; i < fpr; i++)
                {
                    Update();
                }
            }
            updateCount = 0;
            specimenIndex++; 
        }
        private void Generation()
        {
            try {
                currentGeneration = currentGeneration.Mutated();
            } catch(NullReferenceException e) {
                currentGeneration = new G4Pcs.Generation();
            }
            if(ASAP)
            {
                for(int i = specimenIndex; i < G4Pcs.Generation.generationSize; i++)
                {
                    Run();
                }
            }
            specimenIndex %= 1000;
            generationIndex++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ASAP = true;
            Generation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ASAP = false;
            fpsTimer.Start();
            frameTimer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fpsTimer.Stop();
            frameTimer.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            player.Show();
        }
    }
}
