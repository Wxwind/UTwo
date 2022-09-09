using Wx.UTwo.Core;

namespace MyMVVM.Sample.View2Model
{
    public class CharacterModel:PureModel
    {
        public BindablePropery<string> bp_text=new BindablePropery<string>();
        public BindablePropery<int> bp_num = new BindablePropery<int>();

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