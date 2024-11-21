using GamepadControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamepadControlDemo
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            GamePadController gamePadController = new GamePadController();
            gamePadController.Start();
            Console.ReadKey();
        }
    }
}
