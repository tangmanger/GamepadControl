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
            Task.Run(async () =>
            {

                await Task.Delay(10000);
                Console.WriteLine("--------------------->stop");
                gamePadController.Stop();

                await Task.Delay(10000);
                Console.WriteLine("--------------------->start");
                gamePadController.Start();
            });
            Console.ReadKey();
        }
    }
}
