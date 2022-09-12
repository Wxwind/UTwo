using System;
using System.Collections.Generic;
using System.Text;

namespace Wx.UTwo.Core
{
    /// <summary>
    /// 用于实现View和Model之间的多对多的绑定关系,此ViewModel包含了来自多个Model的不同属性
    /// </summary>
    public abstract class ViewModel : IModel
    {
        /// <summary>
        ///<para>Key:typeof(Model).fullname/tostring()</para>> 
        ///<para>Value:model instance</para>> 
        /// </summary>
        private Dictionary<string, PureModel> m_models = new Dictionary<string, PureModel>();

        public ViewModel()
        {
            
        }

        protected bool RegisterField<TProperty>(string modelTypeName, string modelFieldName,
            ReactivePropery<TProperty>.OnValueChangedEventHandler OnValueChanged)
        {
            if (m_models.TryGetValue(modelTypeName, out var model))
            {
                var modelType = model.GetType();
                var fieldInfo = modelType.GetField(modelFieldName);
                if (fieldInfo is null)
                {
                    throw new Exception(
                        $"counld't find field \"{modelFieldName}\"(Type: {typeof(TProperty)}) in Model \"{modelType}\"");
                }

                var field = fieldInfo.GetValue(model);
                if (field is ReactivePropery<TProperty> f)
                {
                    f.AddListener(OnValueChanged);
                    return true;
                }

                throw new Exception(
                    $"VM2PM：\"<color=#ff0000>{modelFieldName}</color>\":the type <color=#ff0000>{typeof(TProperty)}</color> you want to bind doesn't match type <color=#ff0000>{field.GetType()}</color> in Model \"<color=#ff0000>{modelType}</color>\",check your code please");
            }

            throw new Exception($"Coundn't find model named \"{modelTypeName}\",Are you missing import in ctor() or typo error?");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="models">要监听的Models</param>
        protected bool BindToModels(params PureModel[] models)
        {
            if (m_models.Count!=0)
            {
                LogHelper.LogError("不要多次绑定Model，暂不支持对ViewModel对Model的重绑定");
                return false;
            }
            bool isSucceed = true;
            foreach (var m in models)
            {
                var typeName = m.GetType().ToString();
                if (m_models.ContainsKey(typeName))
                {
                    LogHelper.LogWarning("暂不支持对同一类的多个Model实例的绑定");
                    isSucceed = false;
                }
                else m_models.Add(typeName, m);
            }
            return isSucceed;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var item in m_models)
            {
                sb.Append($"{i}:  key:{item.Key} value:{item.Value}\n");
                i++;
            }

            return sb.ToString();
        }
    }
}