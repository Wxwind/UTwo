using System.Collections.Generic;
using UnityEngine;

namespace Wx.UTwo.UCore
{
    public class UIManager:MonoBehaviour
    {
        public static UIManager instance;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
}