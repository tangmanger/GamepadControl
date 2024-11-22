using GamepadControl.Enums;
using GamepadControl.Interfaces;
using GamepadControl.Models.Inputs;
using GamepadControl.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamepadControl.Models
{
    public class GamePadController
    {
        IXInput xInput;
        Task _controllerTask;
        CancellationTokenSource cancellationTokenSource;
        public GamePadController(UserIndex userIndex = UserIndex.One)
        {
            xInput = new XInput13(userIndex);
            if (xInput != null && !xInput.IsInit)
            {

            }
        }
        public void Start()
        {
            cancellationTokenSource = new CancellationTokenSource();
            _controllerTask = Task.Run(() =>
            {
                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    if (xInput.IsConnected)
                    {
                        GamePadState gamePadState;
                        xInput.XInputGetState(out gamePadState);
                        //            state.Gamepad.sThumbLX, state.Gamepad.sThumbLY,
                        //state.Gamepad.sThumbRX, state.Gamepad.sThumbRY,
                        Console.WriteLine("LeftTrigger: {0} RightTrigger:{1} LeftThumb: {2},{3} RightThumb: {4},{5} Button:{6}\r\n",
            gamePadState.Gamepad.bLeftTrigger, gamePadState.Gamepad.bRightTrigger,
            gamePadState.Gamepad.sThumbLX, gamePadState.Gamepad.sThumbLY,
            gamePadState.Gamepad.sThumbRX, gamePadState.Gamepad.sThumbRY,
            gamePadState.Gamepad.wButtons);
                    }


                    Thread.Sleep(20);
                }

            }, cancellationTokenSource.Token);
        }
        public void Stop()
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                Thread.Sleep(20);
            }
        }
    }
}
