using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchScanTextFilesSiteImproveAs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create Text files directory with name :--> TextFiles <---- in your C drive......................");
            Console.WriteLine("Insert all 0-9 html files inside the TextFiles folder  :.....................");

            SearchAndScanTextFiles();
        }

        public static void SearchAndScanTextFiles()
        {
            try
            {
                // Follow for 30 mintues regular expression training : https://www.codeproject.com/Articles/9099/The-Minute-Regex-Tutorial
                // Find text with "Section" followed by "Refresh"
                string searchPattern = @"\bSection\b.*\bRefresh\b";
                // Absolute C drive path 
                string absolutePath = @"C://TextFiles//";
                // As we need to scan and search multiple file
                List<string> allFiles = new List<string>() { "0.html", "1.html", "2.html", "3.html", "4.html", "5.html", "6.html", "7.html", "8.html", "9.html" };
                // after scan and search , we store Ids in the list
                List<string> matchingIds = new List<string>();

                // use foreach loop for scan single file 
                foreach (var singleFile in allFiles)
                {
                    Console.WriteLine("Searching ..................File no:" + singleFile);
                    string combinePathFile = Path.Combine(absolutePath, singleFile);
                    var textLines = File.ReadAllLines(combinePathFile);
                    foreach (string line in textLines)
                    {
                        // here we split the line and get the unique Id in a particular line of file
                        string[] separateId = line.Split(':');
                        // Id is store in [0] index --> as though we need only Id 
                        string id = separateId[0];
                        // Here I am using Regex class for scan and searcing strings in the file 
                        MatchCollection matches = Regex.Matches(line, searchPattern, RegexOptions.IgnoreCase);
                        // If particular input string matches in the line of file , so we extract Id of that particular line of file 
                        foreach (Match match in matches)
                        {
                            // Add matching Id in the list 
                            matchingIds.Add(id);
                        }
                    }
                }
                Console.WriteLine(".......................................................................");
                Console.WriteLine("Diaplaying the matching Ids....................................");
                foreach (var matchId in matchingIds)
                {
                    Console.Write(matchId + ",");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
            Console.ReadKey();
        }


    }
}
