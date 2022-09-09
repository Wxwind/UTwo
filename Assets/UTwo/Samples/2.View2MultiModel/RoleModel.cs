using Wx.UTwo.Core;

namespace UTwo.Samples.View2MultiModel
{
    public class RoleModel:PureModel
    {
        public BindablePropery<string> bp_roleInfo=new BindablePropery<string>();
        public BindablePropery<int> bp_hp = new BindablePropery<int>();
    }
}