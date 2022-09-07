
using UnityEngine;

namespace Wx.UTwo.Core
{
    //一个View只能对应一个Model
    public abstract class UView<T> : MonoBehaviour, IView where T : IModel
    {
        private T m_model;

        /// <summary>
        /// <para>记录当前绑定的model，view会自动重新绑定新的Model</para>
        /// <para>请先绑定View的属性至Model(Type)，最后绑定此BindingModel(实例)</para>
        /// </summary>
        public T BindingModel
        {
            get
            {
                if (m_model is null)
                {
                    LogHelper.LogError($"the BindingModel in view \"{GetType().Name}\" in \"{gameObject.name}\" hasn't bind any model");
                }

                return m_model;
            }
            set
            {
                if (Equals(m_model, value)) return;
                T oldValue = m_model;
                m_model = value;
                m_allPropertyBinder.UnBindToModel(oldValue);
                m_allPropertyBinder.BindToModel(value);
            }
        }

        /// <summary>
        /// 记录了此View下所有BindableProperty的绑定与解绑函数
        /// </summary>
        protected readonly PropertyBinder<T> m_allPropertyBinder = new PropertyBinder<T>();

        /// <summary>
        /// 初始化View将其属性绑定到Model(Type)上
        /// </summary>
        public abstract void OnInit();
        public abstract void OnOpen();
        public abstract void OnClose();
        public abstract void OnDestroySelf();
    }

   
}