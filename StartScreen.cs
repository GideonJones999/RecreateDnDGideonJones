using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace RecreateDND
{
    class StartScreen
    {
        static int charnumb, YPos, spacing;
        public void Main()
        {
            Console.SetCursorPosition(2, 0);
            Program.SlowText("In a land, known as GRYKAR...", 100, ConsoleColor.DarkRed, 1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            charnumb = 0;
            YPos = 1;
            spacing = 15;
            Console.SetCursorPosition(2, 3);

            SoundPlayer sound = new SoundPlayer(Properties.Resources.NES_Overworld); //Replace Later with own song
            sound.Play();
            G();
            R();
            Y();
            K();
            A();
            R();
            
            Console.SetCursorPosition(2, 7);
            Program.SlowText("Press Enter to Start", 10, ConsoleColor.White);

            Console.ReadLine();
            sound.Stop();
            Console.Clear();
        }
        public void G()
        {
            Console.SetCursorPosition(spacing * charnumb, YPos);
            Console.WriteLine("///======\\\\\\");
            Console.SetCursorPosition(spacing * charnumb, YPos + 1);
            Console.WriteLine("|||");
            Console.SetCursorPosition(spacing * charnumb, YPos + 2);
            Console.WriteLine("|||  ====\\\\\\");
            Console.SetCursorPosition(spacing * charnumb, YPos + 3);
            Console.WriteLine("\\\\\\======///");
            System.Threading.Thread.Sleep(100);
            charnumb = charnumb + 1;
        }
        public void R()
        {
            Console.SetCursorPosition(spacing * charnumb, YPos);
            Console.WriteLine("///=====\\\\\\");
            Console.SetCursorPosition(spacing * charnumb, YPos + 1);
            Console.WriteLine("|||=====///");
            Console.SetCursorPosition(spacing * charnumb, YPos + 2);
            Console.WriteLine("|||  \\\\\\");
            Console.SetCursorPosition(spacing * charnumb, YPos + 3);
            Console.WriteLine("|||   \\\\\\");
            System.Threading.Thread.Sleep(100);
            charnumb = charnumb + 1;
        }
        public void Y()
        {
            Console.SetCursorPosition(spacing * charnumb, YPos);
            Console.WriteLine(" \\\\\\     ///");
            Console.SetCursorPosition(spacing * charnumb, YPos + 1);
            Console.WriteLine("  \\\\\\   ///");
            Console.SetCursorPosition(spacing * charnumb, YPos + 2);
            Console.WriteLine("   \\\\|||//");
            Console.SetCursorPosition(spacing * charnumb, YPos + 3);
            Console.WriteLine("     |||");
            System.Threading.Thread.Sleep(100);
            charnumb = charnumb + 1;
        }
        public void K()
        {
            Console.SetCursorPosition(spacing * charnumb, YPos);
            Console.WriteLine("|||  ///");
            Console.SetCursorPosition(spacing * charnumb, YPos + 1);
            Console.WriteLine("||| ///");
            Console.SetCursorPosition(spacing * charnumb, YPos + 2);
            Console.WriteLine("||| \\\\\\");
            Console.SetCursorPosition(spacing * charnumb, YPos + 3);
            Console.WriteLine("|||  \\\\\\");
            System.Threading.Thread.Sleep(100);
            charnumb = charnumb + 1;
        }
        public void A()
        {
            Console.SetCursorPosition(spacing * charnumb, YPos);
            Console.WriteLine("///====\\\\\\");
            Console.SetCursorPosition(spacing * charnumb, YPos + 1);
            Console.WriteLine("|||====|||");
            Console.SetCursorPosition(spacing * charnumb, YPos + 2);
            Console.WriteLine("|||    |||");
            Console.SetCursorPosition(spacing * charnumb, YPos + 3);
            Console.WriteLine("|||    |||");
            System.Threading.Thread.Sleep(100);
            charnumb = charnumb + 1;
        }
        public void space()
        {
            Console.SetCursorPosition(spacing * charnumb, YPos);
            System.Threading.Thread.Sleep(100);
            charnumb = charnumb + 1;
        }

    }
}
