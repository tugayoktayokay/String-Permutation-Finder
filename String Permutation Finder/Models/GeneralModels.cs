using System.Collections.Generic;

namespace String_Permutation_Finder.Models
{
    class GeneralModels
    {
        public bool Exit { get; set; }
        public string InputText { get; set; }
        public string FindInputText { get; set; }
        public string TempInput { get; set; }
        public List<string> FindText { get; set; }

        public GeneralModels()
        {
            FindText = new List<string>();
        }
    }
}
