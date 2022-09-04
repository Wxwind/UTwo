using System.Reflection;

namespace Wx.MyMVVM
{
    public abstract class UView<T> : IView where T : UViewModel
    {
        
        protected T m_viewModel;

        /// <summary>
        /// 记录当前绑定的viewModel，view会自动重新绑定新的viewMovel
        /// </summary>
        public T BindingViewModel
        {
            get => m_viewModel;
            set
            {
                if (Equals(m_viewModel, value)) return;
                T oldValue = m_viewModel;
                m_viewModel = value;
                m_allPropertyBinder.UnBindToVM(oldValue);
                m_allPropertyBinder.BindToVM(value);
            }
        }

        /// <summary>
        /// 记录了此View下所有BindableProperty的绑定与解绑函数
        /// </summary>
        protected readonly PropertyBinder<T> m_allPropertyBinder = new PropertyBinder<T>();

        public virtual void OnInit()
        {
            Log.LogInfo($"init {GetType()}");
        }

        public virtual void OnOpen()
        {
            Log.LogInfo($"open {GetType()}");
        }

        public virtual void OnClose()
        {
            Log.LogInfo($"close {GetType()}");
        }

        public virtual void OnDestory()
        {
            Log.LogInfo($"destory {GetType()}");
        }
    }

    public class PropertyBinder<T> where T : UViewModel
    {
        public delegate void BindEventHandler(T viewModel);

        public delegate void UnBindEventHandler(T viewModel);

        public event BindEventHandler OnBinds;
        public event UnBindEventHandler OnUnBinds;

        
        public void RigisterProperty<TProperty>(string propertyName,BindablePropery<TProperty>.OnValueChangedEventHandler OnValueChanged)
        {
            OnBinds += (viewModel) => { };
            OnUnBinds += (viewModel) => { };
        }

        public void BindToVM(T viewModel)
        {
            OnBinds?.Invoke(viewModel);
        }

        public void UnBindToVM(T viewModel)
        {
            OnUnBinds?.Invoke(viewModel);
        }
    }
}