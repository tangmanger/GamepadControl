using GamepadControl.Enums;
using GamepadControl.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GamepadControl.Models
{
    public class GamePadChangedArgs
    {
        public byte LeftTrigger;
        public byte RightTrigger;
        public short ThumbLX;
        public short ThumbLY;
        public short ThumbRX;
        public short ThumbRY;
        int MAX_JOYSTICK_RANG = 30000;
        int MAX_JOYSTICK_RANG_X = 30000;
        public JoystickDirection LeftDirection
        {
            get
            {
                //            LeftTrigger: 0 RightTrigger: 0 LeftThumb: -10080,-640 RightThumb: 0,0 Button: 0

                //============================================>Down
                //--------------------------------------
                //LeftTrigger: 0 RightTrigger:0 LeftThumb: -24288,384 RightThumb: 0,0 Button:0

                //============================================>Left
                if ((ThumbLX < 18000 && ThumbLX > -18000) && -25000 > ThumbLY && ThumbLY > -32768)
                    return JoystickDirection.Down;
                if (ThumbLX < -30000 && -32768 <= ThumbLX && (ThumbLY < 10000 && ThumbLY > -10000))
                    return JoystickDirection.Left;
                if ((ThumbLX < 18000 && ThumbLX > -18000) && 25000 < ThumbLY && ThumbLY <= 32767)
                    return JoystickDirection.Top;
                if (ThumbLX > 30000 && 32767 >= ThumbLX && (ThumbLY < 10000 && ThumbLY > -10000))
                {
                    return JoystickDirection.Right;
                }
                return JoystickDirection.None;
            }
        }

        public JoystickDirection RightDirection
        {
            get
            {
                if ((ThumbRX < 18000 && ThumbRX > -18000) && -25000 > ThumbRY && ThumbRY > -32768)
                    return JoystickDirection.Down;
                if (ThumbRX < -30000 && -32768 <= ThumbRX && (ThumbRY < 10000 && ThumbRY > -10000))
                    return JoystickDirection.Left;
                if ((ThumbRX < 18000 && ThumbRX > -18000) && 25000 < ThumbRY && ThumbRY <= 32767)
                    return JoystickDirection.Top;
                if (ThumbRX > 30000 && 32767 >= ThumbRX && (ThumbRY < 10000 && ThumbRY > -10000))
                {
                    return JoystickDirection.Right;
                }
                return JoystickDirection.None;
            }
        }
        public GamePadButton Button { get; set; }
    }
}
