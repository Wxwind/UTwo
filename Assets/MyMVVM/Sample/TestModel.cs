using System;
using UnityEngine;
using Wx.UTwo.Core;

namespace MyMVVM.Sample
{
    public class TestModel:MonoBehaviour,IModel
    {
        public BindablePropery<string> bp_text=new BindablePropery<string>();
        public BindablePropery<int> bp_num = new BindablePropery<int>();

        private void Awake()
        {
            bp_text.Value = "123";
            bp_num.Value = -1;
        }
    }
}