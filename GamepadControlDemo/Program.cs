using GamepadControl.Enums;
using GamepadControl.Models;
using GamepadControl.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamepadControlDemo
{
    public class Program
    {
        [DllImport("GamePad.dll")]
        public static extern int Init();
        [DllImport("GamePad.dll")]
        public static extern int XInputGetStateEx(int userIndex, out GamePadState pState);
        [STAThread]
        static void Main(string[] args)
        {
            //    Init();
            //    Task.Run(() =>
            //    {
            //        while (true)
            //        {

            //            GamePadState gamePadState;
            //            XInputGetStateEx(0,out gamePadState);
            //            //            state.Gamepad.sThumbLX, state.Gamepad.sThumbLY,
            //            //state.Gamepad.sThumbRX, state.Gamepad.sThumbRY,
            //            Console.WriteLine("LeftTrigger: {0} RightTrigger:{1} LeftThumb: {2},{3} RightThumb: {4},{5} Button:{6}\r\n",
            //gamePadState.Gamepad.bLeftTrigger, gamePadState.Gamepad.bRightTrigger,
            //gamePadState.Gamepad.sThumbLX, gamePadState.Gamepad.sThumbLY,
            //gamePadState.Gamepad.sThumbRX, gamePadState.Gamepad.sThumbRY,
            //gamePadState.Gamepad.wButtons);


            //            Thread.Sleep(20);
            //        }

            //    });
            //    Console.ReadKey();
            GamePadController gamePadController = new GamePadController();
            gamePadController.GameButtonStateChanged += GamePadController_GameButtonStateChanged;
            gamePadController.Start();
            //Task.Run(async () =>
            //{

            //    await Task.Delay(10000);
            //    Console.WriteLine("--------------------->stop");
            //    gamePadController.Stop();

            //    //await Task.Delay(10000);
            //    //Console.WriteLine("--------------------->start");
            //    //gamePadController.Start();
            //});
            Console.ReadKey();
        }

        private static void GamePadController_GameButtonStateChanged(GamePadChangedArgs obj)
        {
            var button = obj.Button;
            if (button.HasFlag(GamepadControl.Enums.GamePadButton.Down))
            {
                Console.WriteLine("下 按下");
            }
            if (button.HasFlag(GamepadControl.Enums.GamePadButton.Up))
            {
                Console.WriteLine("上 按下");
            }
            if (button.HasFlag(GamepadControl.Enums.GamePadButton.A))
            {
                Console.WriteLine("A 按下");
            }
            if (button.HasFlag(GamePadButton.Back) && button.HasFlag(GamePadButton.Y))
            {
                //Console.WriteLine(obj.LeftDirection.ToString());
                //Console.WriteLine(obj.RightDirection.ToString());
                Console.WriteLine("================>" + button.ToString());
            }
        }
    }
}
