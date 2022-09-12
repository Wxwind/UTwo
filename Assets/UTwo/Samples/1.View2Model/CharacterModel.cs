using Wx.UTwo.Core;

namespace MyMVVM.Sample.View2Model
{
    public class CharacterModel:PureModel
    {
        public ReactivePropery<string> rp_text=new ReactivePropery<string>();
        public ReactivePropery<int> rp_num = new ReactivePropery<int>();

        public CharacterModel()
        {
        }

        public void Set(string text, int num)
        {
            rp_text.Value = text;
            rp_num.Value = num;
        }
    }
}