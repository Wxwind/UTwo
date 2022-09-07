using System;
using System.Collections.Generic;

namespace Wx.UTwo.Core
{
    //用于View和Model之间的多对多的绑定关系,此ViewModel包含了来自多个Model的不同属性
    public abstract class ViewModel : IModel
    {
        private Dictionary<string, PureModel> m_models = new Dictionary<string, PureModel>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="models">要监听的Models</param>
        public ViewModel(params PureModel[] models)
        {
            foreach (var m in models)
            {
                m_models.Add(nameof(m), m);
            }
        }

        public bool RegisterField<TProperty>(string modelName, string modelFieldName,
            BindablePropery<TProperty>.OnValueChangedEventHandler OnValueChanged)
        {
            if (m_models.TryGetValue(modelName, out var model))
            {
                var modelType = model.GetType();
                var fieldInfo = modelType.GetField(modelFieldName);
                if (fieldInfo is null)
                {
                    throw new Exception(
                        $"counld't find field \"{modelFieldName}\"(Type: {typeof(TProperty)}) in Model \"{modelType}\"");
                }

                var field = fieldInfo.GetValue(model);
                if (field is BindablePropery<TProperty> f)
                {
                    f.AddListener(OnValueChanged);
                    return true;
                }

                throw new Exception(
                    $"VM2PM：\"<color=#ff0000>{modelFieldName}</color>\":the type <color=#ff0000>{typeof(TProperty)}</color> you want to bind doesn't match type <color=#ff0000>{field.GetType()}</color> in Model \"<color=#ff0000>{modelType}</color>\",check your code please");
            }

            throw new Exception($"Coundn't find model named \"{modelName}\",Are you missing import in ctor() or typo error?");
        }
    }
}