using System;
using Wx.UTwo.Core;

namespace UTwo.Samples.View2MultiModel
{
    [Serializable]
    public class EnemyModel:PureModel
    {
        public ReactivePropery<string> rp_enemyInfo=new ReactivePropery<string>();
        public ReactivePropery<int> rp_attack = new ReactivePropery<int>();
    }
}