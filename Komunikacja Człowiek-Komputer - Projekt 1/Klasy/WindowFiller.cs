using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikacja_Człowiek_Komputer___Projekt_1
{
    class WindowFiller
    {
        public void FillTopLeftPolish(Database database)
        {
            int i;
            Console.SetCursorPosition(7, 7);
            Console.WriteLine("{0,2}  {1,-20}{2,6}{3,5}", "#", "Drużyna", "RG", "P");
            Console.SetCursorPosition(7, 8);
            Console.WriteLine();
            for (i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(7, 9 + i);
                Console.WriteLine("{0,2}  {1,-20}{2,6}{3,5}", database.Table[i].Position, database.Table[i].Name, database.Table[i].GoalDifference, database.Table[i].Points);
            }
            Console.SetCursorPosition(7, 9 + i);
            Console.WriteLine("{0,2}  {1,-20}", "", "------");
            for (i = 16; i < 20; i++)
            {
                Console.SetCursorPosition(7, i - 2);
                Console.WriteLine("{0,2}  {1,-20}{2,6}{3,5}", database.Table[i].Position, database.Table[i].Name, database.Table[i].GoalDifference, database.Table[i].Points);
            }
        }

        public void FillTopLeftEnglish(Database database)
        {
            int i;
            Console.SetCursorPosition(7, 7);
            Console.WriteLine("{0,2}  {1,-20}{2,6}{3,5}", "#", "Team", "GD", "P");
            Console.SetCursorPosition(7, 8);
            Console.WriteLine();
            for (i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(7, 9 + i);
                Console.WriteLine("{0,2}  {1,-20}{2,6}{3,5}", database.Table[i].Position, database.Table[i].Name, database.Table[i].GoalDifference, database.Table[i].Points);
            }
            Console.SetCursorPosition(7, 9 + i);
            Console.WriteLine("{0,2}  {1,-20}", "", "------");
            for (i = 16; i < 20; i++)
            {
                Console.SetCursorPosition(7, i - 2);
                Console.WriteLine("{0,2}  {1,-20}{2,6}{3,5}", database.Table[i].Position, database.Table[i].Name, database.Table[i].GoalDifference, database.Table[i].Points);
            }
        }

        public void FillTopRightPolish(Database database)
        {
            int i = 0, gameweek = 8;
            Console.SetCursorPosition((150 - "Kolejka X".Length) / 2, 7);
            Console.WriteLine("Kolejka {0}", gameweek);
            Console.SetCursorPosition(56, 8);
            Console.WriteLine();
            for (int j = 0; j < database.Schedule.Count(); j++)
            {
                Console.SetCursorPosition(56, 9 + i);
                if (database.Schedule[j].Gameweek == gameweek)
                {
                    i++;
                    Console.WriteLine("{0,15}{1,1}{2,5}{3,1}{4,-15}", database.Schedule[j].Home, "", database.Schedule[j].Score + " ", "", database.Schedule[j].Visitor);
                }
            }
        }

        public void FillTopRightEnglish(Database database)
        {
            int i = 0, gameweek = 8;
            Console.SetCursorPosition((150 - "Gameweek X".Length) / 2, 7);
            Console.WriteLine("Gameweek {0}", gameweek);
            Console.SetCursorPosition(56, 8);
            Console.WriteLine();
            for (int j = 0; j < database.Schedule.Count(); j++)
            {
                Console.SetCursorPosition(56, 9 + i);
                if (database.Schedule[j].Gameweek == gameweek)
                {
                    i++;
                    Console.WriteLine("{0,15}{1,1}{2,5}{3,1}{4,-15}", database.Schedule[j].Home, "", database.Schedule[j].Score + " ", "", database.Schedule[j].Visitor);
                }
            }
        }

        public void FillBottomLeftPolish(Database database)
        {
            int i;
            Console.SetCursorPosition((50 - "Strzelcy".Length) / 2, 26);
            Console.WriteLine("Strzelcy");
            Console.SetCursorPosition(7, 27);
            Console.WriteLine();
            for (i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(7, 28 + i);
                Console.WriteLine("{0,2}  {1,-20}{2,6}", database.Scorers[i].Position, database.Scorers[i].Name, database.Scorers[i].Goals);
            }
            Console.SetCursorPosition((50 - "Asystenci".Length) / 2, 29 + i);
            Console.WriteLine("Asystenci");
            for (i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(7, 34 + i);
                Console.WriteLine("{0,2}  {1,-20}{2,6}", database.Assistants[i].Position, database.Assistants[i].Name, database.Assistants[i].Assists);
            }
        }

        public void FillBottomLeftEnglish(Database database)
        {
            int i;
            Console.SetCursorPosition((50 - "Scorers".Length) / 2, 26);
            Console.WriteLine("Scorers");
            Console.SetCursorPosition(7, 27);
            Console.WriteLine();
            for (i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(7, 28 + i);
                Console.WriteLine("{0,2}  {1,-20}{2,6}", database.Scorers[i].Position, database.Scorers[i].Name, database.Scorers[i].Goals);
            }
            Console.SetCursorPosition((50 - "Assistants".Length) / 2, 29 + i);
            Console.WriteLine("Assistants");
            for (i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(7, 34 + i);
                Console.WriteLine("{0,2}  {1,-20}{2,6}", database.Assistants[i].Position, database.Assistants[i].Name, database.Assistants[i].Assists);
            }
        }

        public void FillBottomRightPolish()
        {
            string[] tekst = new string[8];
            tekst[0] = "    Już w niedzielę trzeci w tabeli      ";
            tekst[1] = "  Tottenham  podejmuje ósmy Liverpool.   ";
            tekst[2] = "    Jest to klasyczny przykład meczu     ";
            tekst[3] = "   o 6 punktów. Obie drużyny świetnie    ";
            tekst[4] = " zaprezentowały się w tygodniu w meczach ";
            tekst[5] = " Ligi Mistrzów. Koguty z tarczą wróciły  ";
            tekst[6] = "   z Madrytu, a The Reds roznieśli na    ";
            tekst[7] = "          wyjeździe Maribor.             ";
            for (int i=0; i<tekst.Length; i++) {
                Console.SetCursorPosition((150 - tekst[0].Length) / 2, i+26);
                Console.WriteLine(tekst[i]); }
        }

        public void FillBottomRightEnglish()
        {
            string[] text = new string[8];
            text[0] = " Tottenham Hotspur can affirm their place ";
            text[1] = "as Premier League title contenders if they";
            text[2] = "     beat Liverpool at Wembley Stadium    ";
            text[3] = "     on Sunday, with both teams having    ";
            text[4] = "     clinched valuable midweek results    ";
            text[5] = "  in Europe. Both Spurs and Liverpool sit ";
            text[6] = " at the top of their respective respective";
            text[7] = "       UEFA Champions League groups.      ";
            for (int i=0; i<text.Length; i++) {
                Console.SetCursorPosition((150 - text[0].Length) / 2, i+26);
            Console.WriteLine(text[i]); }
        }
    }
}
