namespace Wx.UTwo.Core
{
    public interface IView
    {
        void OnInit();

        void OnOpen();

        void OnClose();

        void OnDestroySelf();
    }
}