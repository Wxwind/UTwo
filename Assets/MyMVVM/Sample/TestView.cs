using TMPro;
using UnityEngine;
using Wx.MyMVVM;

namespace MyMVVM.Sample
{
    public class TestView:UView<TestViewModel>
    {
        public TMP_Text text;
        public TMP_Text num;
    }
}