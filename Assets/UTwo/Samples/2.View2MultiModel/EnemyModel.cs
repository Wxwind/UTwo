using Wx.UTwo.Core;

namespace UTwo.Samples.View2MultiModel
{
    public class EnemyModel:PureModel
    {
        public BindablePropery<string> bp_enemyInfo=new BindablePropery<string>();
        public BindablePropery<int> bp_attack = new BindablePropery<int>();
    }
}