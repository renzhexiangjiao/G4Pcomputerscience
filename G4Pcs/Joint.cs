using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace G4Pcs
{
    class Joint
    {
        private Point position;
        public Joint(Point position)
        {
            this.position = position;
        }
        public Joint(int x, int y)
        {
            position = new Point(x, y);
        }

        public Point getPosition() => position;
    }
}
