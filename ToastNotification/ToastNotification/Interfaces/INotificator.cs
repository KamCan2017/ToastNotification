namespace ToastNotification
{
    internal interface INotificator
    {
        void CloseWindow();
    }

     public enum MessageType
    {
        Info,
        Warning,
        Success,
        Error
    }
}
