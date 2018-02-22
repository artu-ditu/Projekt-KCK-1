using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using WMPLib;
using WMPDXMLib;
using System.Reflection;

namespace Komunikacja_Człowiek_Komputer___Projekt_1 {   

    class Program {

        static void Main (string[] args) {

            /*WindowsMediaPlayer Music = new WindowsMediaPlayer();
            Music.URL = "PremierLeagueMusic.mp3";
            Music.controls.play();*/
            
            Assembly assembly;
            SoundPlayer soundPlayer;
            assembly = Assembly.GetExecutingAssembly();
            soundPlayer = new SoundPlayer("PremierLeagueMusic.wav");
            soundPlayer.PlayLooping();

            Console.SetWindowSize(100,50);
            ConsoleController consoleController = new ConsoleController ("polish","normal");
        }
    }
}
