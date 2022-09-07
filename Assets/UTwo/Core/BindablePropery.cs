namespace Wx.UTwo.Core
{
    /// <summary>
    /// 监听T并自动调用事件OnValueChanged
    /// </summary>
    /// <typeparam name="T">要监听的字段类型</typeparam>
    public class BindablePropery<T>
    {
        public delegate void OnValueChangedEventHandler(T oldValue, T newValue);

        private event OnValueChangedEventHandler OnValueChanged;
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
        /// <param name="onValueChangedCallBack"></param>
        public void AddListener(OnValueChangedEventHandler onValueChangedCallBack)
        {
            OnValueChanged += onValueChangedCallBack;
        }

        public void RemoveListener(OnValueChangedEventHandler onValueChangedCallBack)
        {
            OnValueChanged -= onValueChangedCallBack;
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