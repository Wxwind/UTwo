using Wx.UTwo.Core;

namespace UTwo.Samples.View2MultiModel
{
    public class RoleModel:PureModel
    {
        public ReactivePropery<string> rp_roleInfo=new ReactivePropery<string>();
        public ReactivePropery<int> rp_hp = new ReactivePropery<int>();
    }
}