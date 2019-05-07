using System;
namespace Helper
{
    public class Global
    {
        public static MouseStatus mouseStatus = MouseStatus.Free;
        public static void setMouseStatus(MouseStatus status)
        {
            mouseStatus = status;
        }
    }
    public enum MouseStatus
    {
        Free,
        Click,
        Grap,
        Inspect
    }
}
