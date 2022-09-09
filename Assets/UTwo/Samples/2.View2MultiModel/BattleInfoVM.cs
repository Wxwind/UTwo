using Wx.UTwo.Core;

namespace UTwo.Samples.View2MultiModel
{
    public class BattleInfoVM:ViewModel
    {
        public BindablePropery<string> bp_enemyInfo=new BindablePropery<string>();
        public BindablePropery<string> bp_roleInfo=new BindablePropery<string>();
    }
}