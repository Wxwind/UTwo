using TMPro;
using Wx.UTwo.Core;

namespace MyMVVM.Sample.View2Model
{
    public class CharacterView : UView<CharacterModel>
    {
        public TMP_Text MyString;
        public TMP_Text Num;
        public TMP_InputField InputField;

        private CharacterModel testModel;
        
        private void Start()
        {
            OnInit();
            testModel = new CharacterModel();
            BindingModel = testModel;
            LogHelper.LogInfo("Bind to a new CharacterModel");
            testModel.Set("I'm Character",-1);
        }

        public override void OnInit()
        {
            LogHelper.LogInfo($"init {GetType()}");
            
            m_allPropertyBinder.RegisterField<string>("bp_text",
                (oldValue, newValue) =>
                {
                    MyString.text = newValue;
                    LogHelper.LogInfo("View 的 MyString 随Model发生改变");
                });
            m_allPropertyBinder.RegisterField<int>("bp_num",
                (oldValue, newValue) =>
                {
                    LogHelper.LogInfo("Model 的 bp_num+1 ");
                    if (oldValue % 2 == 0)
                    {
                        Num.text = newValue.ToString();
                        LogHelper.LogInfo("View 的 Num 随Model发生改变");
                    }
                });
        }

        public override void OnOpen()
        {
            LogHelper.LogInfo($"open {GetType()}");
        }

        public override void OnClose()
        {
            LogHelper.LogInfo($"close {GetType()}");
        }

        public override void OnDestroySelf()
        {
            LogHelper.LogInfo($"destory {GetType()}");
        }

        #region Controller for View To Trigger Model

        public void OnBtnClick_NumPlusOne()
        {
            testModel.bp_num.Value++;
        }

        public void OnBtnClick_SetText()
        {
            testModel.bp_text.Value = InputField.text;
        }

        #endregion
    }
}