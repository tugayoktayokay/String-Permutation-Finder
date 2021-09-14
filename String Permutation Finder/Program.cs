using String_Permutation_Finder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace String_Permutation_Finder
{

    static class Program
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
            Console.Write("Lütfen İlk Kelimeyi Giriniz: ");
            generalModels.FindText.Clear();
            generalModels.InputText = Console.ReadLine().ToLower();
            Console.Write("Lütfen ikinci Kelimeyi Giriniz: ");
            generalModels.FindInputText = Console.ReadLine().ToLower();
            CompareStrings(generalModels.InputText, generalModels.FindInputText);
            Console.WriteLine(FindWord(generalModels.TempInput));
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

        #region ************ Permutation ************
        private static IEnumerable<T[]> Permutate<T>(this IEnumerable<T> source)
        {
            return permutate(source, Enumerable.Empty<T>());
            IEnumerable<T[]> permutate(IEnumerable<T> reminder, IEnumerable<T> prefix) =>
                !reminder.Any() ? new[] { prefix.ToArray() } :
                reminder.SelectMany((c, i) => permutate(
                    reminder.Take(i).Concat(reminder.Skip(i + 1)).ToArray(),
                    prefix.Append(c)));
        }
        #endregion

        #region ************ Compare Strings ************
        private static void CompareStrings(string firstText, string lastText)
        {
            if (firstText.Length > lastText.Length)
            {
                generalModels.TempInput = lastText;
                PermutateFind(firstText);
            }
            else
            {
                generalModels.TempInput = firstText;
                PermutateFind(lastText);
            }

        }
        #endregion

        #region ************ Find Word ************
        private static bool FindWord(string findTextVal)
        {
            var tempFindModel = generalModels.FindText.Where(x => x.Contains(findTextVal)).Any();
            return tempFindModel;
        }
        #endregion

        #region ************ Permutation Find ************
        private static void PermutateFind(string val)
        {
            foreach (var k in Permutate(val))
            {
                generalModels.FindText.Add(new string(k));
            }
        }
        #endregion
    }
}