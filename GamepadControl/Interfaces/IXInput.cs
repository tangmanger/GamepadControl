using GamepadControl.Enums;
using GamepadControl.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamepadControl.Interfaces
{
    public interface IXInput
    {
        bool IsInit { get; set; }
        string Msg { get; set; }
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="dwUserIndex"></param>
        /// <param name="gamePadState"></param>
        /// <returns></returns>
        int XInputGetState( out GamePadState gamePadState);
        int XInputGetState(UserIndex userIndex, out GamePadState gamePadState);
        /// <summary>
        /// 加载
        /// </summary>
        /// <returns></returns>
        bool Load();
        /// <summary>
        /// 库名称
        /// </summary>
        string DllName { get; }
         bool IsConnected { get; }
    }
}
