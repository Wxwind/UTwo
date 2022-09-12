namespace Wx.UTwo.Core
{
    public interface IView
    {
        void OnInit();

        void OnDestroySelf();
        
        void OnOpen();

        void OnClose();
    }
}