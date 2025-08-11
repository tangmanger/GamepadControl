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
        public event Action<GamePadChangedArgs> GameButtonStateChanged;
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
        public bool IsConnect
        {
            get
            {
                return xInput.IsConnected;
            }
        }
        Dictionary<UserIndex, uint> UserIndexDic = new Dictionary<UserIndex, uint>();
        public void Start()
        {
            cancellationTokenSource = new CancellationTokenSource();
            _controllerTask = Task.Run(() =>
            {
                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    if (xInput.IsConnected)
                    {
                        List<UserIndex> userIndices = new List<UserIndex>() { UserIndex.One, UserIndex.Two, UserIndex.Three, UserIndex.Four };
                        foreach (var userInfo in userIndices)
                        {
                            GamePadState gamePadState;
                            xInput.XInputGetState(userInfo, out gamePadState);
                            if (!UserIndexDic.ContainsKey(userInfo))
                                UserIndexDic.Add(userInfo, gamePadState.dwPacketNumber);
                            else
                            {
                                if (gamePadState.dwPacketNumber == UserIndexDic[userInfo])
                                {
                                    continue;
                                }
                                UserIndexDic[userInfo] = gamePadState.dwPacketNumber;
                            }
                            //            state.Gamepad.sThumbLX, state.Gamepad.sThumbLY,

                            //            Console.WriteLine("LeftTrigger: {0} RightTrigger:{1} LeftThumb: {2},{3} RightThumb: {4},{5} Button:{6}\r\n",
                            //gamePadState.Gamepad.bLeftTrigger, gamePadState.Gamepad.bRightTrigger,
                            //gamePadState.Gamepad.sThumbLX, gamePadState.Gamepad.sThumbLY,
                            //gamePadState.Gamepad.sThumbRX, gamePadState.Gamepad.sThumbRY,
                            //gamePadState.Gamepad.wButtons);
                            GamePadChangedArgs gamePadChangedArgs = new GamePadChangedArgs();
                            gamePadChangedArgs.UserIndex = userInfo;
                            gamePadChangedArgs.ThumbRY = gamePadState.Gamepad.sThumbRY;
                            gamePadChangedArgs.ThumbRX = gamePadState.Gamepad.sThumbRX;
                            gamePadChangedArgs.ThumbLY = gamePadState.Gamepad.sThumbLY;
                            gamePadChangedArgs.ThumbLX = gamePadState.Gamepad.sThumbLX;
                            gamePadChangedArgs.LeftTrigger = gamePadState.Gamepad.bLeftTrigger;
                            gamePadChangedArgs.RightTrigger = gamePadState.Gamepad.bRightTrigger;
                            gamePadChangedArgs.Button = (GamePadButton)gamePadState.Gamepad.wButtons;
                            GameButtonStateChanged?.Invoke(gamePadChangedArgs);
                        }
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
