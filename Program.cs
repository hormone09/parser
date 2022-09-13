using System;
using System.Collections.Generic;
using System.IO;

namespace Parser
{
	class Program
	{
		static void Main(string[] args)
		{
			/*var excelParser = new ExcelParser(@"C:/Users/Domu/Desktop/read.xlsx", @"C:/Users/Domu/Desktop/hSickOncoTopography_Add.txt", "hSickOncoTopography");
			var db = excelParser.ReadFile();
			var strings = excelParser.Add(db);
			excelParser.WriteFile(strings);
			var excelParser = new ExcelParser(@"C:/Users/Domu/Desktop/read.xlsx", @"C:/Users/Domu/Desktop/hSickOnco_Remove.txt", "hSickOnco");
			//var excelParser = new ExcelParser(@"C:/Users/Domu/Desktop/read.xlsx", @"C:/Users/Domu/Desktop/hSickOnco_Add.txt", "hSickOnco");
			//var excelParser = new ExcelParser(@"C:/Users/Domu/Desktop/read.xlsx", @"C:/Users/Domu/Desktop/hSickOnco_Update.txt", "hSickOnco");
			var db = excelParser.ReadFile();
			var strings = excelParser.Delete(db);
			excelParser.WriteFile(strings);*/

			var parser = new SickSpecializationParser(null, @"C:/Users/Domu/Desktop/SickSpecialization.txt", null);
			var strings = new List<string>();

			strings.AddRange(parser.GetStrings("A15", "A19.9", 0, new string[] { "1200", "11700" }));
			strings.AddRange(parser.GetStrings("B90", "B90.9", 0, new string[] { "1200", "11700" }));

			strings.AddRange(parser.GetStrings("B20", "B24.9", 0, new string[] { "1100", "11200" }));
			strings.AddRange(parser.GetStrings("B18.0", "B18.2", 0, new string[] { "1100", "11200" }));
			strings.AddRange(parser.GetStrings("B18.8", "B18.8", 0, new string[] { "1100", "11200" }));

			//strings.AddRange(parser.GetStrings("C00", "С97.9", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("D00", "D09.9", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("D37", "D48.9", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("C81", "C96.9", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("D46", "D46.9", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("D47.1", "D47.1", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("D56.0", "D56.2", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("D56.4", "D56.4", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("D57.0", "D57.2", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("D59.0", "D59.9", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("D58.0", "D58.9", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("D61", "D61.8", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("D62", "D62.9", 0, new string[] { "8200", "13600" }));
			strings.AddRange(parser.GetStrings("D63", "D63.9", 0, new string[] { "8200", "13600" }));

			strings.AddRange(parser.GetStrings("C81", "C96.9", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D46", "D46.9", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D47.1", "D47.1", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D56.0", "D56.2", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D56.4", "D56.4", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D57.0", "D57.2", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D59.4", "D59.9", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D61.9", "D61.9", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D69.3", "D69.3", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D80", "D84.9", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D58", "D58.9", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D50", "D50.9", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D60", "D60.9", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D61.0", "D61.9", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D62", "D62.9", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D63", "D63.9", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("I78", "I78.9", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D66", "D67", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D68.0", "D68.0", 0, new string[] { "900", "4700", "10600" }));
			strings.AddRange(parser.GetStrings("D68.2", "D68.2", 0, new string[] { "900", "4700", "10600" }));

			strings.AddRange(parser.GetStrings("E22.0", "E22.9", 0, new string[] { "9800", "9900"}));
			strings.AddRange(parser.GetStrings("E28", "E28.9", 0, new string[] { "9800", "9900" }));
			strings.AddRange(parser.GetStrings("E30", "E30.9", 0, new string[] { "9800", "9900" }));
			strings.AddRange(parser.GetStrings("N81", "N81.9", 0, new string[] { "9800", "9900" }));
			strings.AddRange(parser.GetStrings("N91", "N91.9", 0, new string[] { "9800", "9900" }));
			strings.AddRange(parser.GetStrings("N93", "N93.9", 0, new string[] { "9800", "9900" }));
			strings.AddRange(parser.GetStrings("N97", "N97.9", 0, new string[] { "9800", "9900" }));
			strings.AddRange(parser.GetStrings("D27", "D27", 0, new string[] { "9800", "9900" }));
			strings.AddRange(parser.GetStrings("N60", "N60.9", 0, new string[] { "9800", "9900" }));
			strings.AddRange(parser.GetStrings("N80", "N80.9", 0, new string[] { "9800", "9900" }));
			strings.AddRange(parser.GetStrings("N84", "N84.9", 0, new string[] { "9800", "9900" }));
			strings.AddRange(parser.GetStrings("N85.0", "N85.1", 0, new string[] { "9800", "9900" }));
			strings.AddRange(parser.GetStrings("N86", "N86", 0, new string[] { "9800", "9900" }));
			strings.AddRange(parser.GetStrings("N88.0", "N88.0", 0, new string[] { "9800", "9900" }));

			strings.AddRange(parser.GetStrings("F00", "F99.9", 0, new string[] { "1800", "42600" }));

			strings.AddRange(parser.GetStrings("F00", "F99.9", 0, new string[] { "1700", "11500" }));
			strings.AddRange(parser.GetStrings("G30", "G32.9", 0, new string[] { "1700", "11500" }));

			strings.AddRange(parser.GetStrings("G12.2", "G12.2", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G30", "G32.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G35", "G37.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G40.0", "G40.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G93.4", "G93.4", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("I00", "I02.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("B91", "B91.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G09", "G09.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G20", "G20.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G23", "G23.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G43", "G43.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G50", "G52.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G54", "G54.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G70", "G70.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G95", "G95.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("H33", "H33.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("H34", "H34.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("H35", "H35.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("G60", "G60.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("P10.0", "P10.0", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("P14", "P14.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("Q02", "Q02.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("S06", "S06.9", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("I60", "I69.8", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("I74.2", "I74.2", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("I79.1", "I79.1", 0, new string[] { "1600", "11400" }));
			strings.AddRange(parser.GetStrings("Q11", "Q11.3", 0, new string[] { "1600", "11400" }));

			strings.AddRange(parser.GetStrings("G40.4", "G40.4", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("G93.4", "G93.4", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("G09", "G09.9", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("H20", "H20.9", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("H32", "H32.9", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("H40", "H40.9", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("H44", "H44.9", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("H52", "H52.9", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("H53", "H53.9", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("H33", "H33.9", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("H34", "H34.9", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("H35", "H35.9", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("Q11", "Q11.9", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("M05", "M06.9", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("M07.3", "M07.3", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("M45", "M45", 0, new string[] { "8900", "13800" }));
			strings.AddRange(parser.GetStrings("M08", "M08.9", 0, new string[] { "8900", "13800" }));

			strings.AddRange(parser.GetStrings("I00", "I02.9", 0, new string[] { "1400", "10800" }));
			strings.AddRange(parser.GetStrings("I78", "I78.9", 0, new string[] { "1400", "10800" }));
			strings.AddRange(parser.GetStrings("M05", "M06.9", 0, new string[] { "1400", "10800" }));
			strings.AddRange(parser.GetStrings("M07.3", "M07.3", 0, new string[] { "1400", "10800" }));
			strings.AddRange(parser.GetStrings("M45", "M45", 0, new string[] { "1400", "10800" }));
			strings.AddRange(parser.GetStrings("M08", "M08.9", 0, new string[] { "1400", "10800" }));
			strings.AddRange(parser.GetStrings("M30", "M35.9", 0, new string[] { "1400", "10800" }));

			strings.AddRange(parser.GetStrings("I00", "I02.9", 0, new string[] { "7900", "12700" }));

			strings.AddRange(parser.GetStrings("I00", "I02.9", 0, new string[] { "9000", "13700" }));
			strings.AddRange(parser.GetStrings("H66", "H66.9", 0, new string[] { "9000", "13700" }));
			strings.AddRange(parser.GetStrings("H74", "H74.9", 0, new string[] { "9000", "13700" }));
			strings.AddRange(parser.GetStrings("H90", "H90.9", 0, new string[] { "9000", "13700" }));
			strings.AddRange(parser.GetStrings("Q16", "Q16.9", 0, new string[] { "9000", "13700" }));

			strings.AddRange(parser.GetStrings("K05", "K05.9", 0, new string[] { "14500", "19000", "14600" }));

			strings.AddRange(parser.GetStrings("I27.0", "I27.0", 0, new string[] { "1300", "10700"}));
			strings.AddRange(parser.GetStrings("I70", "I70.9", 0, new string[] { "1300", "10700" }));
			strings.AddRange(parser.GetStrings("G60", "G60.9", 0, new string[] { "1300", "10700" }));
			strings.AddRange(parser.GetStrings("G60", "G60.9", 0, new string[] { "1300", "10700" }));
			strings.AddRange(parser.GetStrings("G60", "G60.9", 0, new string[] { "1300", "10700" }));
			strings.AddRange(parser.GetStrings("G60", "G60.9", 0, new string[] { "1300", "10700" }));
			strings.AddRange(parser.GetStrings("G60", "G60.9", 0, new string[] { "1300", "10700" }));

			parser.WriteFile(strings);
		}
	}
}
