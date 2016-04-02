﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace appWin_PDB
{
    public class ConsoleSpinner
    {
        int counter = 0;
        public void Turn()
        {
            counter++;
            switch (counter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
}
