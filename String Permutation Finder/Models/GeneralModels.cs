using System.Collections.Generic;

namespace String_Permutation_Finder.Models
{
    class GeneralModels
    {
        public bool Exit { get; set; }
        public string InputText { get; set; }
        public int Number { get; set; }
        public List<string> FindText { get; set; }

        public GeneralModels()
        {
            FindText = new List<string>();
        }
    }
}
