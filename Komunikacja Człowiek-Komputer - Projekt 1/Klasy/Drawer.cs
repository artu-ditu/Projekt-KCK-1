using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komunikacja_Człowiek_Komputer___Projekt_1
{
    class Drawer
    {
        private static void WriteHeader()
        {
            string headerText = "PremierLigator 2017/2018 Turbo#5000 v1.0";
            Console.SetCursorPosition((Console.WindowWidth - headerText.Length) / 2, Console.CursorTop + 1);
            Console.WriteLine(headerText);
        }

        private static void WriteMenuControls(string language)
        {
            string controlsText = "";
            if (language == "polish")
                controlsText = "nawigacja: strzałki | zatwierdź: enter | zamknij: escape";
            else if (language == "english")
                controlsText = "navigation: arrowkeys | confirm: enter | quit: escape";


            Console.SetCursorPosition((Console.WindowWidth - controlsText.Length) / 2, 42);
            Console.WriteLine(controlsText);
        }

        private static void WriteViewControls(string selectedOption, string language)
        {
            string controlsText = "";
            if (language=="polish") {
                if (selectedOption == "** Terminarz **") controlsText = "nawigacja: strzałki | zatwierdź: enter | powrót: backspace | zamknij: escape";
                else controlsText = "powrót: backspace | zamknij: escape"; }
            else if (language=="english") {
                if (selectedOption == "** Schedule **") controlsText = "navigation: arrowkeys | confirm: enter | back: backspace | quit: escape";
                else controlsText = "back: backspace | quit: escape"; }

            if (selectedOption!="** Mecz kolejki **" && selectedOption!="** Match of the Week **") {
                Console.SetCursorPosition((Console.WindowWidth - controlsText.Length) / 2, 42);
                Console.WriteLine(controlsText); }
        }

        private static void DrawMenuWindows()
        {
            for (int i = 1; i < 99; i++)
            {
                if (i != 49 && i != 50)
                {
                    Console.SetCursorPosition(i, 3);
                    Console.Write('█');
                    Console.SetCursorPosition(i, 20);
                    Console.Write('█');
                    Console.SetCursorPosition(i, 22);
                    Console.Write('█');
                    Console.SetCursorPosition(i, 39);
                    Console.Write('█');
                }
            }

            for (int i = 3; i < 40; i++)
            {
                if (i != 21)
                {
                    Console.SetCursorPosition(1, i);
                    Console.Write('█');
                    Console.Write('█');
                    Console.SetCursorPosition(47, i);
                    Console.Write('█');
                    Console.Write('█');
                    Console.SetCursorPosition(51, i);
                    Console.Write('█');
                    Console.Write('█');
                    Console.SetCursorPosition(97, i);
                    Console.Write('█');
                    Console.Write('█');
                }
            }
        }

        private static void FillMenuWindows(Database database, string language, string theme)
        {
            WindowFiller menuFiller = new WindowFiller();
            if (language == "polish") {
                menuFiller.FillTopLeftPolish(database);
                menuFiller.FillTopRightPolish(database);
                menuFiller.FillBottomLeftPolish(database);
                menuFiller.FillBottomRightPolish(); }
            else if (language == "english") {
                menuFiller.FillTopLeftEnglish(database);
                menuFiller.FillTopRightEnglish(database);
                menuFiller.FillBottomLeftEnglish(database);
                menuFiller.FillBottomRightEnglish(); }
        }

        private static void DrawScheduleView(Database database, int gameweek, int highlightedInSchedule, ConsoleController consoleController)
        {
            ConsoleKeyInfo scheduleKey;

            string[] scheduleOptions = new string[2];
            if (consoleController.GetLanguage()=="polish") {
                scheduleOptions[0] = "<< poprzednia";
                scheduleOptions[1] = "następna >>"; }
            else if (consoleController.GetLanguage()=="english") {
                scheduleOptions[0] = "<< previous";
                scheduleOptions[1] = "next >>"; }
            string selectedOption = scheduleOptions[0];

            do
            {
                #region opcje terminarza
                for (int c = 0; c < scheduleOptions.Length; c++)
                {
                    if (highlightedInSchedule == c)
                    {
                        selectedOption = scheduleOptions[c];
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        if (consoleController.GetTheme()=="dark") {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White; }
                        switch (c)
                        {
                            case 0:
                                Console.SetCursorPosition(17, 5);
                                break;
                            case 1:
                                Console.SetCursorPosition(70, 5);
                                break;
                        }
                        Console.WriteLine(scheduleOptions[c]);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        if (consoleController.GetTheme()=="dark") {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White; }
                    }
                    else
                    {
                        switch (c)
                        {
                            case 0:
                                Console.SetCursorPosition(17, 5);
                                break;
                            case 1:
                                Console.SetCursorPosition(70, 5);
                                break;
                        }
                        Console.WriteLine(scheduleOptions[c]);
                    }
                }
                #endregion

                #region sterowanie terminarzem
                scheduleKey = Console.ReadKey(true);

                if (scheduleKey.Key.ToString() == "LeftArrow")
                {
                    if (highlightedInSchedule == 1) highlightedInSchedule--;
                }
                else if (scheduleKey.Key.ToString() == "RightArrow")
                {
                    if (highlightedInSchedule == 0) highlightedInSchedule++;
                }
                #endregion

            } while (scheduleKey.KeyChar != 13 && scheduleKey.KeyChar != 27 && scheduleKey.KeyChar != 8);

            if (scheduleKey.KeyChar == 27) Environment.Exit(0);
            else if (scheduleKey.KeyChar == 8) return;

            if (highlightedInSchedule == 0) gameweek--;
            else gameweek++;

            if (gameweek < 1) gameweek = 1;
            if (gameweek > 9) gameweek = 9;

            if (consoleController.GetLanguage() == "polish")
                database.WriteSchedulePolish(gameweek);
            else if (consoleController.GetLanguage()=="english")
                database.WriteScheduleEnglish(gameweek);
            DrawScheduleView(database, gameweek, highlightedInSchedule,consoleController);
        }

        private static void DrawView(string selectedOption, Database database, ConsoleController consoleController)
        {
            Console.Clear();
            ConsoleKeyInfo displayKey;
            int gameweek = 1;

            WriteHeader();
            Console.WriteLine("\n\n");

            switch (selectedOption)
            {
                case "** Tabela ligi **":
                case "** League table **":
                    if (consoleController.GetLanguage()=="polish")
                        database.WriteTablePolish(consoleController.GetTheme());
                    else if (consoleController.GetLanguage()=="english")
                        database.WriteTableEnglish(consoleController.GetTheme());
                    break;
                case "** Statystyki **":
                case "** Statistics **":
                    if (consoleController.GetLanguage()=="polish") {
                        database.WriteScorersPolish();
                        Console.WriteLine("\n");
                        database.WriteAssistantsPolish(); }
                    else if (consoleController.GetLanguage()=="english") {
                        database.WriteScorersEnglish();
                        Console.WriteLine("\n");
                        database.WriteAssistantsEnglish(); }
                    break;
                case "** Terminarz **":
                case "** Schedule **":
                    if (consoleController.GetLanguage()=="polish")
                        database.WriteSchedulePolish(gameweek);
                    else if (consoleController.GetLanguage()=="english")
                        database.WriteScheduleEnglish(gameweek);
                    break;
                case "** Mecz kolejki **":
                case "** Match of the Week **":
                    if (consoleController.GetLanguage()=="polish")
                        database.WriteMatchOfTheWeekPolish(consoleController);
                    else if (consoleController.GetLanguage()=="english")
                        database.WriteMatchOfTheWeekEnglish(consoleController);
                    break;
            }

            WriteViewControls(selectedOption, consoleController.GetLanguage());


            if (selectedOption == "** Terminarz **" || selectedOption=="** Schedule **") DrawScheduleView(database, gameweek, 0,consoleController);
            else
            {
                do
                {
                    displayKey = Console.ReadKey(true);
                    if (displayKey.KeyChar == 27) Environment.Exit(0);
                } while (displayKey.KeyChar != 8);
            }
        }

        public static ConsoleController DrawMenu(string[] menuOptions, Database database, int highlightedInMenu, ConsoleController consoleController)
        {
            Console.Clear();
            ConsoleKeyInfo menuKey;
            
            string selectedOption = menuOptions[0];

            WriteHeader();
            WriteMenuControls(consoleController.GetLanguage());
            DrawMenuWindows();
            FillMenuWindows(database,consoleController.GetLanguage(), consoleController.GetTheme());

            do
            {
                #region opcje menu
                for (int c = 0; c < menuOptions.Length; c++)
                {
                    if (highlightedInMenu == c)
                    {
                        selectedOption = menuOptions[c];
                        if (consoleController.GetTheme()=="normal") {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Cyan; }
                        else if (consoleController.GetTheme()=="dark") {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                        }
                        switch (c)
                        {
                            case 0:
                                Console.SetCursorPosition((50 - menuOptions[c].Length) / 2, 5);
                                break;
                            case 1:
                                Console.SetCursorPosition((150 - menuOptions[c].Length) / 2, 5);
                                break;
                            case 2:
                                Console.SetCursorPosition((50 - menuOptions[c].Length) / 2, 24);
                                break;
                            case 3:
                                Console.SetCursorPosition((150 - menuOptions[c].Length) / 2, 24);
                                break;
                        }
                        Console.WriteLine(menuOptions[c]);
                        if (consoleController.GetTheme()=="normal") {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White; }
                        else if (consoleController.GetTheme()=="dark") {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black; }
                    }
                    else
                    {
                        switch (c)
                        {
                            case 0:
                                Console.SetCursorPosition((50 - menuOptions[c].Length) / 2, 5);
                                break;
                            case 1:
                                Console.SetCursorPosition((150 - menuOptions[c].Length) / 2, 5);
                                break;
                            case 2:
                                Console.SetCursorPosition((50 - menuOptions[c].Length) / 2, 24);
                                break;
                            case 3:
                                Console.SetCursorPosition((150 - menuOptions[c].Length) / 2, 24);
                                break;
                        }
                        Console.WriteLine(menuOptions[c]);
                    }
                }
                #endregion

                #region sterowanie menu
                menuKey = Console.ReadKey(true);

                if (menuKey.Key.ToString() == "UpArrow")
                {
                    if (highlightedInMenu != 0 && highlightedInMenu != 1) highlightedInMenu = highlightedInMenu - 2;
                }
                else if (menuKey.Key.ToString() == "DownArrow")
                {
                    if (highlightedInMenu != 2 && highlightedInMenu != 3) highlightedInMenu = highlightedInMenu + 2;
                }
                else if (menuKey.Key.ToString() == "LeftArrow")
                {
                    if (highlightedInMenu != 0 && highlightedInMenu != 2) highlightedInMenu--;
                }
                else if (menuKey.Key.ToString() == "RightArrow")
                {
                    if (highlightedInMenu != 1 && highlightedInMenu != 3) highlightedInMenu++;
                }
                #endregion

            } while (menuKey.KeyChar != 13 && menuKey.KeyChar != 27);

            if (menuKey.KeyChar == 27) Environment.Exit(0);
            else DrawView(selectedOption, database, consoleController);
            DrawMenu(menuOptions, database, highlightedInMenu,consoleController);
            return consoleController;
        }
    }
}
