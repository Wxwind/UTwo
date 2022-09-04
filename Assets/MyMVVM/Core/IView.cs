namespace Wx.MyMVVM
{
    public interface IView
    {
        void OnInit();

        void OnOpen();

        void OnClose();

        void OnDestory();
    }
}