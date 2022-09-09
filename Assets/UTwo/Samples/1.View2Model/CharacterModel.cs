using Wx.UTwo.Core;

namespace MyMVVM.Sample.View2Model
{
    public class CharacterModel:PureModel
    {
        public ReactivePropery<string> bp_text=new ReactivePropery<string>();
        public ReactivePropery<int> bp_num = new ReactivePropery<int>();

        public CharacterModel()
        {
        }

        public void Set(string text, int num)
        {
            bp_text.Value = text;
            bp_num.Value = num;
        }
    }
}