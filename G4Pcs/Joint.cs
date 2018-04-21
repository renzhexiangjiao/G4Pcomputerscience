using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace G4Pcs
{
    class Joint : Object
    {
        private Point position;

        public Joint(double mass, Point position) : base(mass)
        {
            this.position = position;
        }
        public Joint(double mass, int x, int y) : base(mass)
        {
            position = new Point(x, y);
        }

        public Point getPosition() => position;
    }
}
