using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4Pcs
{
    class Generation
    {
        public static int generationSize = 1000;
        private Specimen[] listOfSpecimina = new Specimen[generationSize];

        public Generation(Specimen[] listOfSpecimina)
        {
            this.listOfSpecimina = listOfSpecimina;
        }
    }
}
