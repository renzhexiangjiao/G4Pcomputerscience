using System.Drawing;
using System.Collections.Generic;
using System;

namespace G4Pcs
{
    class Joint : Object
    {
        public static List<Joint> jointList = new List<Joint>();

        public Joint(double mass, Point position) : base(mass)
        {
            this.position = position;
        }
        public Joint(double mass, int x, int y) : base(mass)
        {
            position = new Point(x, y);
        }

        public void updatePosition(int fps)
        {
            this.position.X += (int)velocity.scaledBy(1.0 / (double)fps).toPoint().X;
            this.position.Y += (int)velocity.scaledBy(1.0 / (double)fps).toPoint().Y;
        }       
    }
}
