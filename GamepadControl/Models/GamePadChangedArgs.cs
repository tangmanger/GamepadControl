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
        public GamePadButton Button { get; set; }
    }
}
