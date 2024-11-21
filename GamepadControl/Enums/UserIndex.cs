using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamepadControl.Enums
{
    public enum UserIndex : byte
    {
        //
        // 摘要:
        //     [in] Index of the signed-in gamer associated with the device. Can be a value
        //     in the range 0?XUSER_MAX_COUNT ? 1, or SharpDX.XInput.UserIndex.Any to fetch
        //     the next available input event from any user.
        Any = byte.MaxValue,
        //
        // 摘要:
        //     [in] Reserved
        One = 0,
        //
        // 摘要:
        //     [out] Pointer to an SharpDX.XInput.Keystroke structure that receives an input
        //     event.
        Two = 1,
        //
        // 摘要:
        //     No documentation.
        Three = 2,
        //
        // 摘要:
        //     No documentation.
        Four = 3
    }
}
