using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G4Pcs
{
    class FileSystem
    {
        public void WriteToFile(string address, Generation generation)
        {

        }
        public List<Generation> ReadFromFile(string address)
        {
            string file = "";
            try
            {
                TextReader reader = new StreamReader(address);
                file = reader.ReadToEnd();
            }
            catch(IOException e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string[] words = file.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int genIndex;
            int specIndex;
            foreach(string word in words)
            {
                if(word.Contains("GENERATION#"))
                {
                    genIndex = Int32.Parse(word.Substring(11));
                }
                else if(word.Contains("SPECIMEN#"))
                {
                    specIndex = Int32.Parse(word.Substring(9));
                }
                else
                {

                }
            }
            return null;
        }
    }
}
