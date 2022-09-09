using Wx.UTwo.Core;

namespace UTwo.Samples.View2MultiModel
{
    public class RoleModel:PureModel
    {
        public ReactivePropery<string> bp_roleInfo=new ReactivePropery<string>();
        public ReactivePropery<int> bp_hp = new ReactivePropery<int>();
    }
}