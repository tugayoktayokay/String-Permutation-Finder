using String_Permutation_Finder.Models;
using System;
using System.Linq;


namespace String_Permutation_Finder
{

    class Program
    {
        #region ************ Variables ************
        private static readonly GeneralModels generalModels = new GeneralModels();
        #endregion

        #region ************ Main ************
        private static void Main()
        {
            BackgroudChange();
            do
            {
                MainProcess();
            }
            while (generalModels.Exit != true);
        }
        #endregion

        #region ************ Main Process ************
        private static void MainProcess()
        {
            Console.Write("Lütfen Bir Kelime Giriniz: ");
            generalModels.InputText = Console.ReadLine().ToLower();
            char[] text = generalModels.InputText.ToCharArray();
            generalModels.FindText.Clear();
            Permutation(text, 0, text.Length - 1);
            Console.Write("Lütfen Aramak İstediğiniz Kelimeyi Giriniz: ");
            string findInputText = Console.ReadLine().ToLower();
            FindWord(findInputText);
            Console.Write("\n\nÇıkmak istiyormusunuz (E/H)");
            char quit = Convert.ToChar(Console.ReadLine().ToLower());
            if (quit == 'e')
            {
                generalModels.Exit = true;
                return;
            }
            else
            {
                generalModels.Exit = false;
            }
        }
        #endregion

        #region ************ Console Backgroud Changer ************
        private static void BackgroudChange()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion

        #region ************ Changed Text ************
        private static void ChangedText(ref char a, ref char b)
        {
            if (a == b) return;
            char c = a;
            a = b;
            b = c;
        }
        #endregion

        #region ************ Permutation ************
        private static void Permutation(char[] arr, int left, int right)
        {
            if (left == right)
            {
                generalModels.Number++;
                generalModels.FindText.Add(new string(arr));
            }
            else
            {
                for (int i = left; i <= right; i++)
                {
                    ChangedText(ref arr[left], ref arr[i]);
                    Permutation(arr, left + 1, right);
                    ChangedText(ref arr[left], ref arr[i]);
                }
            }
        }
        #endregion

        #region ************ Find Word ************
        private static void FindWord(string findTextVal)
        {
            bool isFinded = false;
            if (generalModels.FindText.Where(x => x.Contains(findTextVal)).Any())
            {
                isFinded = true;
            }
            else
            {
                isFinded = false;
            }
            Console.Write("İçerik Durumu: " + isFinded);
        }
        #endregion

    }
}