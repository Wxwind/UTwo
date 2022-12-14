using System;
using System.Reflection;

namespace Wx.UTwo.Core
{
     /// <summary>
    /// 负责管理View下所有BindableProperty对目标Model的绑定与解绑函数
    /// </summary>
    /// <typeparam name="T">目标Model</typeparam>
    public class PropertyBinder<T> where T : IModel
    {
        public delegate void BindEventHandler(T model);

        public delegate void UnBindEventHandler(T model);

        public event BindEventHandler OnBinds;
        public event UnBindEventHandler OnUnBinds;

        /// <summary>
        /// 通过反射将view的字段绑定到目标Model下BindablePropery字段的OnValueChanged事件中
        /// </summary>
        /// <param name="fieldName">目标Model下BindablePropery字段名</param>
        /// <param name="OnValueChanged">要绑定的事件</param>
        /// <param name="isWeakBind">如果True，则忽略绑定Model没有的字段且不抛出异常</param>
        /// <typeparam name="TProperty">view要绑定的字段类型</typeparam>
        /// <returns>绑定成功则返回True，否则返回False</returns>
        /// <exception cref="ArgumentException">绑定的类型错误</exception>
        public bool RegisterField<TProperty>(string fieldName,
            ReactivePropery<TProperty>.OnValueChangedEventHandler OnValueChanged, bool isWeakBind = false)
        {
            var fieldInfo = typeof(T).GetField(fieldName,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (fieldInfo is null)
            {
                if (isWeakBind) return false;
                throw new Exception($"counld't find field \"{fieldName}\"(Type: {typeof(TProperty)}) in Model \"{typeof(T)}\"");
            }

            OnBinds += (model) =>
                FetchFieldInModel<TProperty>(fieldName, model, fieldInfo, isWeakBind).AddListener(OnValueChanged);
            OnUnBinds += (model) =>
                FetchFieldInModel<TProperty>(fieldName, model, fieldInfo, isWeakBind).RemoveListener(OnValueChanged);
            return true;
        }

        private ReactivePropery<TProperty> FetchFieldInModel<TProperty>(string fieldName, T model, FieldInfo fieldInfo,
            bool isWeakBind)
        {
            var field = fieldInfo.GetValue(model);
            if (field is null)
            {
                throw new Exception("not exist this exception in theory");
            }

            //绑定的model属性匹配成功
            if (field is ReactivePropery<TProperty> f)
            {
                return f;
            }

            //
            string msg =
                $"\"V2M：<color=#ff0000>{fieldName}</color>\":the type <color=#ff0000>{typeof(TProperty)}</color> you want to bind doesn't match type <color=#ff0000>{field.GetType()}</color> in Model \"<color=#ff0000>{typeof(T)}</color>\",check your code please";
            if (isWeakBind)
            {
                LogHelper.LogWarning(msg);
                return null;
            }

            throw new Exception(msg);
        }

        public void BindToModel(T model)
        {
            if (model is null)
            {
                LogHelper.LogWarning("New Model is null");
                return;
            }
            OnBinds?.Invoke(model);
        }

        public void UnBindToModel(T model)
        {
            if (model is null)
            {
                LogHelper.LogInfo("Old Model is null,it might be first inited");
                return;
            }
            OnUnBinds?.Invoke(model);
        }
    }
}