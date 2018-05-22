﻿using System.Collections.Generic;

namespace G4Pcs
{
    abstract class Force : Vector
    {
        protected Object object1, object2;

        public Force(Object object1, Object object2)
        {
            this.object1 = object1;
            this.object2 = object2;
        }
        public Force(Object object2)
        {
            this.object2 = object2;
        }   

        public Object getAgent() => this.object1;
        public Object getPatient() => this.object2;
    }
}
