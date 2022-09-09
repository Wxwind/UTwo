using Wx.UTwo.Core;

namespace UTwo.Samples.View2MultiModel
{
    public class EnemyModel:PureModel
    {
        public ReactivePropery<string> bp_enemyInfo=new ReactivePropery<string>();
        public ReactivePropery<int> bp_attack = new ReactivePropery<int>();
    }
}