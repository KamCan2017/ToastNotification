using System.Windows;

namespace ToastNotification
{
    public class NotificationProvider
    {
        public static void Notify(string message, MessageType messageType = MessageType.Info)
        {
            if(string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
                return;

             Application.Current.Dispatcher.Invoke(() => 
            {
                Notificator notificator = new Notificator(message, messageType);
                  notificator.Show();
                });
        }
    }
}
