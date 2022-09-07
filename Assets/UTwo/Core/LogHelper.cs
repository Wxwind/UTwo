using UnityEngine;

namespace Wx.UTwo.Core
{
    public static class LogHelper
    {
        public static void LogInfo(string msg)
        {
            Debug.Log(msg);
        }

        public static void LogError(string error)
        {
            Debug.LogError(error);
        }
        
        public static void LogWarning(string error)
        {
            Debug.LogWarning(error);
        }
    }
}