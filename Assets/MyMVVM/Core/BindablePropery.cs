namespace Wx.MyMVVM
{
    /// <summary>
    /// T发生变化时自动调用事件
    /// </summary>
    /// <typeparam name="T">要监听的对象类型</typeparam>
    public class BindablePropery<T>
    {
        public delegate void OnValueChangedEventHandler(T oldValue, T newValue);

        public event OnValueChangedEventHandler OnValueChanged;
        private T m_value;

        public T Value
        {
            get => m_value;
            set
            {
                if (Equals(m_value, value)) return;
                T oldValue = m_value;
                m_value = value;
                OnValueChanged?.Invoke(oldValue, m_value);
            }
        }

        /// <summary>
        /// 用于model变化时去通知view
        /// </summary>
        /// <param name="OnValueChangedCallBack"></param>
        public void AddListener(OnValueChangedEventHandler OnValueChangedCallBack)
        {
            OnValueChanged += OnValueChangedCallBack;
        }

        public void RemoveListener(OnValueChangedEventHandler OnValueChangedCallBack)
        {
            OnValueChanged -= OnValueChangedCallBack;
        }

        public override string ToString()
        {
            return m_value == null ? "null" : m_value.ToString();
        }

        public bool Equals(BindablePropery<T> other)
        {
            return Equals(m_value, other.m_value);
        }
    }
}