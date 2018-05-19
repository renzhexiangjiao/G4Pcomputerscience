using System.Drawing;
using System.Collections.Generic;
using System;

namespace G4Pcs
{
    class Joint : Object
    {
        public static List<Joint> jointList = new List<Joint>();

        private Point position;

        private double angle;
        private double deltaAngle;

        private double minAngle, maxAngle;
        private double minDeltaAngle, maxDeltaAngle;



        private Joint parent;
        private List<Joint> children = new List<Joint>();

        public Joint(double mass, Point position, Joint parent, double minAngle, double maxAngle, double minDeltaAngle, double maxDeltaAngle) : base(mass)
        {
            this.position = position;
            this.parent = parent;
        }  
        public Joint(double mass, int x, int y, Joint parent, double minAngle, double maxAngle, double minDeltaAngle, double maxDeltaAngle) : base(mass)
        {
            position = new Point(x, y);
            this.parent = parent;
        }

        public void assignChildren()
        {
            foreach(Joint joint in Joint.jointList)
            {
                if (joint.parent!=null&&joint.parent.Equals(this))
                    this.children.Add(joint);
            }
        }

        public void updatePosition(int fps)
        {
            this.position.X += (int)velocity.scaledBy(1.0 / (double)fps).toPoint().X;
            this.position.Y += (int)velocity.scaledBy(1.0 / (double)fps).toPoint().Y;
            if(this.position.Y >= Form1.groundLevel)
            {
                this.position.Y = Form1.groundLevel;
            }
        }

        public void updateAngle()
        {
            angle = Math.Min(Math.Max(angle + deltaAngle, minAngle), maxAngle);
        }

        public void setDeltaAngle(double value)
        {
            deltaAngle = value * Math.PI;
        }

        public Point getPosition() => position;

        public Joint getParent() => parent;
        public Joint getChild(int index) => children[index];
    }
}
