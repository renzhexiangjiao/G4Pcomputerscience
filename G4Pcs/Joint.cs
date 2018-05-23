using System.Drawing;
using System.Collections.Generic;
using System;

namespace G4Pcs
{
    class Joint : Object
    {
        private Point position;

        private double deltaAngle;

        private Bone parentBone;

        private double[] coefficients = new double[50];

        private Joint parent;
        private List<Joint> children = new List<Joint>();

        public Joint(double mass, Point position, Joint parent) : base(mass)
        {
            this.position = position;
            this.parent = parent;
        }  
        public Joint(double mass, int x, int y, Joint parent) : base(mass)
        {
            position = new Point(x, y);
            this.parent = parent;
        }

        public void assignChildren(Specimen specimen)
        {
            foreach(Joint joint in specimen.jointList)
            {
                if (joint.parent!=null&&joint.parent.Equals(this))
                    this.children.Add(joint);
            }
        }

        public void updatePosition(int fps)
        {
            
            double alfa = -Math.Atan2(getParent().getPosition().Y - getPosition().Y,
                getParent().getPosition().X - getPosition().X);
            //double beta = alfa + Math.Min(deltaAngle, Math.PI/20);

            double px = position.X - getParent().getPosition().X;
            double py = position.Y - getParent().getPosition().Y;

            double c = Math.Cos(Math.Max(Math.Min(deltaAngle, Math.PI / 12), -Math.PI / 12));
            double s = Math.Sin(Math.Max(Math.Min(deltaAngle, Math.PI / 12), -Math.PI / 12));

            position.X = (int)(px * c - py * s) + getParent().getPosition().X;
            position.Y = (int)(px * s + py * c) + getParent().getPosition().Y;

            if (this.getParentBone().getLength() > 1.2 * this.getParentBone().getDefLength())
            {
                this.position.X = getParent().getPosition().X + (int)(1.2 * this.getParentBone().getDefLength() * -Math.Cos(alfa));
                this.position.Y = getParent().getPosition().Y + (int)(1.2 * this.getParentBone().getDefLength() * Math.Sin(alfa));
            }
            else if(this.getParentBone().getLength() < 0.8 * this.getParentBone().getDefLength())
            {
                this.position.X = getParent().getPosition().X + (int)(0.8 * this.getParentBone().getDefLength() * -Math.Cos(alfa));
                this.position.Y = getParent().getPosition().Y + (int)(0.8 * this.getParentBone().getDefLength() * Math.Sin(alfa));
            }

            this.position.X += (int)velocity.scaledBy(1.0 / (double)fps).toPoint().X;
            this.position.Y += (int)velocity.scaledBy(1.0 / (double)fps).toPoint().Y;

            if (this.position.Y >= Form1.groundLevel)
            {
                this.position.Y = Form1.groundLevel;
            }
        }

        public void Function(int time)
        {
            deltaAngle = 0;
            for(int i = 0; i < coefficients.Length; i++)
            {
                deltaAngle += coefficients[i] * Math.Sin(coefficients[(i+1)%50] * time - coefficients[(i+2)%50]);
            }
        }

        public void randomizeFunction(Random random)
        {
            
            for (int i = 0; i < this.coefficients.Length; i++)
            {
                this.coefficients[i] = Math.Pow(2 * random.NextDouble() - 1, i);
            }
        }

        public void setParentBone(Bone parentBone)
        {
            this.parentBone = parentBone;
        }

        public void setParent(Joint parent)
        {
            this.parent = parent;
        }

        public Point getPosition() => position;

        public Joint getParent() => parent;
        public Joint getChild(int index) => children[index];

        public double getCoefficient(int index) => coefficients[index];

        public Bone getParentBone() => parentBone;
    }
}
