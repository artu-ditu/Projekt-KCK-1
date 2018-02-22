using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Komunikacja_Człowiek_Komputer___Projekt_1 {

    class ConsoleController {

        private string _selectedLanguage;
        private string _selectedTheme;

        public void SetLanguage (string language) {
            this._selectedLanguage = language; }

        public string GetLanguage () { 
            return this._selectedLanguage; }

        public void SetTheme (string theme) {
            this._selectedTheme = theme; }

        public string GetTheme () {
            return this._selectedTheme; }

        public ConsoleController (string language, string theme) {
            this._selectedLanguage = language;
            this._selectedTheme = theme;
            this.WelcomeScreen(); }

        private void printPicture (string fileName) {
            if (this._selectedTheme == "normal")
                Console.BackgroundColor = ConsoleColor.White;
            else if (this._selectedTheme == "dark")
                Console.BackgroundColor = ConsoleColor.Black;
            if (File.Exists(fileName)) {
                StringBuilder stringBuilder = new StringBuilder();
                StreamReader streamReader = new StreamReader(fileName);
                string line = streamReader.ReadLine();
                string[] firstLine = new string[2];
                firstLine = line.Split(null);
                int rows = Int32.Parse(firstLine[0]);
                int columns = Int32.Parse(firstLine[1]);
                char[,] pictureArray = new char[rows, columns];
                for (int i=0; i<Console.WindowWidth; i++)
                    Console.Write(" ");
                for (int i=0; i<rows; i++) {
                    line = streamReader.ReadLine();
                    for (int j=0; j<columns; j++)
                        pictureArray[i, j] = line[j]; }
                Console.WriteLine();
                for (int i=0; i<rows; i++) {
                    if (_selectedTheme == "normal")
                        Console.BackgroundColor = ConsoleColor.White;
                    else if (_selectedTheme== "dark")
                        Console.BackgroundColor = ConsoleColor.Black;
                    for (int j=0; j<((Console.WindowWidth-columns)/2); j++)
                        Console.Write(" ");
                    Console.SetCursorPosition((Console.WindowWidth-columns)/2,i+1);
                    for (int j=0; j<columns; j++) {
                        switch (pictureArray[i,j]) {
                            case '.':
                                if (this._selectedTheme=="normal")
                                    Console.BackgroundColor=ConsoleColor.White;
                                else if (this._selectedTheme=="dark")
                                    Console.BackgroundColor=ConsoleColor.Black;
                                break;
                            case '=':
                                if (this._selectedTheme=="normal")
                                    Console.BackgroundColor=ConsoleColor.Black;
                                else if (this._selectedTheme=="dark")
                                    Console.BackgroundColor=ConsoleColor.White;
                                break;
                            case 'b':
                                Console.BackgroundColor=ConsoleColor.Black;
                                break;
                            case 'W':
                                Console.BackgroundColor=ConsoleColor.White;
                                break;
                            case 'R':
                                Console.BackgroundColor=ConsoleColor.Red;
                                break;
                            case 'B':
                                Console.BackgroundColor=ConsoleColor.DarkBlue;
                                break;
                            case 'Y':
                                Console.BackgroundColor=ConsoleColor.Yellow;
                                break;
                            case 'C':
                                Console.BackgroundColor=ConsoleColor.DarkCyan;
                                break;
                            case 'G':
                                Console.BackgroundColor=ConsoleColor.Green;
                                break;
                            case 'g':
                                Console.BackgroundColor=ConsoleColor.Gray;
                                break;
                            default:
                                break;
                        }
                        Console.Write(" ");
                    }
                    if (_selectedTheme=="normal")
                        Console.BackgroundColor=ConsoleColor.White;
                    else if (_selectedTheme=="dark")
                        Console.BackgroundColor=ConsoleColor.Black;
                    for (int j=0; j<((Console.WindowWidth-columns)/2); j++)
                        Console.Write(" ");
                    if (columns % 2 == 1)
                        Console.Write(" ");
                    Console.Write("\n");
                }
                if (_selectedTheme == "normal")
                    Console.BackgroundColor = ConsoleColor.White;
                else if (_selectedTheme == "dark")
                    Console.BackgroundColor = ConsoleColor.Black;
                if (rows<Console.WindowHeight) {
                    for (int i=rows; i<Console.WindowHeight; i++) {
                        for (int j = 0; j<Console.WindowWidth; j++)
                            Console.Write(" ");
                        Console.Write("\n");
                    }
                }
                for (int j=0; j<Console.WindowWidth; j++)
                    Console.Write(" ");
            }
        }

        private void WelcomeScreen () {
            Console.Clear();
            if (this._selectedLanguage=="polish")
                printPicture("WelcomeScreen-Polish.txt");
            else if (this._selectedLanguage=="english")
                printPicture("WelcomeScreen-English.txt");
            do {
                switch (Console.ReadKey(false).Key) {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        return;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        if (this.GetLanguage()=="polish") {
                            this.SetLanguage("english");
                            for (int i=0; i<2; i++) {
                                Console.SetCursorPosition(40,42+i);
                                Console.BackgroundColor=ConsoleColor.White;
                                for (int j=0; j<8; j++)
                                    Console.Write(" ");
                                Console.BackgroundColor=ConsoleColor.Red;
                                for (int j=8; j<12; j++)
                                    Console.Write(" ");
                                Console.BackgroundColor=ConsoleColor.White;
                                for (int j=12; j<20; j++)
                                    Console.Write(" "); }
                            for (int i=2; i<4; i++) {
                                Console.SetCursorPosition(40,42+i);
                                Console.BackgroundColor=ConsoleColor.Red;
                                for (int j=0; j<20; j++)
                                    Console.Write(" "); }
                            for (int i=4; i<6; i++) {
                                Console.SetCursorPosition(40,42+i);
                                Console.BackgroundColor=ConsoleColor.White;
                                for (int j=0; j<8; j++)
                                    Console.Write(" ");
                                Console.BackgroundColor=ConsoleColor.Red;
                                for (int j=8; j<12; j++)
                                    Console.Write(" ");
                                Console.BackgroundColor=ConsoleColor.White;
                                for (int j=12; j<20; j++)
                                    Console.Write(" "); }
                            Console.CursorVisible=false;
                            Console.BackgroundColor=ConsoleColor.Black;
                        }
                        else if (this.GetLanguage()=="english") {
                            this.SetLanguage("polish");
                            for (int i=0; i<3; i++) {
                                Console.SetCursorPosition(40,42+i);
                                Console.BackgroundColor=ConsoleColor.White;
                                for (int j=0; j<20; j++)
                                    Console.Write(" "); }
                            for (int i=3; i<6; i++) {
                                Console.SetCursorPosition(40,42+i);
                                Console.BackgroundColor=ConsoleColor.Red;
                                for (int j=0; j<20; j++)
                                    Console.Write(" "); }
                            Console.CursorVisible = false;
                            Console.BackgroundColor = ConsoleColor.Black; }
                        break;
                    default:
                        break;
                }
            } while (Console.ReadKey(true).Key!=ConsoleKey.Enter);
            this.ThemeSelectionScreen();
        }

        private void ThemeSelectionScreen () {
            Console.Clear();
            if (this._selectedLanguage == "polish") {
                printPicture("ThemeSelectionScreen-Polish-Normal.txt"); }
            else if (this._selectedLanguage=="english") {
                printPicture("ThemeSelectionScreen-English-Normal.txt"); }
            do {
                switch (Console.ReadKey(false).Key) {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        return;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        if (this._selectedLanguage=="polish") {
                            if (this._selectedTheme == "normal") {
                                Console.Clear();
                                this.SetTheme("dark");
                                this.printPicture("ThemeSelectionScreen-Polish-Dark.txt"); }
                            else if (this._selectedTheme == "dark") {
                                Console.Clear();
                                this.SetTheme("normal");
                                this.printPicture("ThemeSelectionScreen-Polish-Normal.txt"); }}
                        else if (this.GetLanguage()=="english") {
                            if (this._selectedTheme == "normal") {
                                Console.Clear();
                                this.SetTheme("dark");
                                this.printPicture("ThemeSelectionScreen-English-Dark.txt"); }
                            else if (this._selectedTheme == "dark") {
                                Console.Clear();
                                this.SetTheme("normal");
                                this.printPicture("ThemeSelectionScreen-English-Normal.txt"); }}
                        break;
                    case ConsoleKey.Backspace:
                        this.SetTheme("normal");
                        this.SetLanguage("polish");
                        this.WelcomeScreen();
                        break;
                    default:
                        break;
                }
            } while (Console.ReadKey(true).Key!=ConsoleKey.Enter);
            this.MainPageScreen();
            return;
        }

        public void MainPageScreen () {
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 44);

            //zdefiniowanie kolorów i odświeżenie konsoli
            if (this._selectedTheme=="normal") {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White; }
            else if (this._selectedTheme=="dark") {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.Clear();

            //utworzenie bazy danych
            Database database = new Database();
            database.ReadDatabase();

            //utworzenie rysownika
            Drawer drawer = new Drawer();

            //nazwy opcji menu
            string[] menuOptionsPolish = { "** Tabela ligi **", "** Terminarz **", "** Statystyki **", "** Mecz kolejki **" };
            string[] menuOptionsEnglish = { "** League table **","** Schedule **","** Statistics **","** Match of the Week **"};

            //wywołanie rysownika tworzącego menu
            while (1!=2)
            {
                if (this._selectedLanguage=="polish")
                    Drawer.DrawMenu(menuOptionsPolish,database,0,this);
                else if (this._selectedLanguage=="english")
                    Drawer.DrawMenu(menuOptionsEnglish,database,0,this);
            }
            }

        private void FullTableScreen () {
            Console.Clear();
            if (this._selectedLanguage=="polish")
                this.printPicture("FullTableScreen-Polish.txt");
            else if (this._selectedLanguage=="english")
                this.printPicture("FullTableScreen-English.txt");
            do {
                switch (Console.ReadKey(false).Key) {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        return;
                    default:
                        break;
                }
            } while (Console.ReadKey(true).Key!=ConsoleKey.Backspace);
            //this.MainPageScreen();
            return;
        }

        private void TopPlayersScreen () {
            Console.Clear();
            if (this._selectedLanguage=="polish")
                this.printPicture("TopPlayersScreen-Polish.txt");
            else if (this._selectedLanguage=="english")
                this.printPicture("TopPlayersScreen-English.txt");
            do {
                switch (Console.ReadKey(false).Key) {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        return;
                    default:
                        break;
                }
            } while (Console.ReadKey(true).Key!=ConsoleKey.Backspace);
            //this.MainPageScreen();
            return;
        }

        private void ScheduleScreen () {
            Console.Clear();
            if (this._selectedLanguage=="polish")
                this.printPicture("WeekScheduleScreen-Polish.txt");
            else if (this._selectedLanguage=="english")
                this.printPicture("WeekScheduleScreen-English.txt");
            do {
                switch (Console.ReadKey(false).Key) {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        return;
                    default:
                        break;
                }
            } while (Console.ReadKey(true).Key!=ConsoleKey.Backspace);
            //this.MainPageScreen();
            return;
        }

        public void TottenhamLiverpoolScreen () {
            Console.Clear();
            if (this._selectedLanguage=="polish")
                this.printPicture("TottenhamLiverpool-Polish.txt");
            else if (this._selectedLanguage=="english")
                this.printPicture("TottenhamLiverpool-English.txt");
            do {
                switch (Console.ReadKey(false).Key) {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        return;
                    default:
                        break;
                }
            } while (Console.ReadKey(true).Key!=ConsoleKey.Backspace);
            //this.MainPageScreen();
            return;
        }
    }
}