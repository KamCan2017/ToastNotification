using System.Windows;

namespace ToastNotification
{
    /// <summary>
    /// Interaction logic for Notificator.xaml
    /// </summary>
    public partial class Notificator : Window, INotificator
    {
      
        public Notificator()
        {
            InitializeComponent();
            DataContext = new NotificatorViewModel(this);
        }        

        public Notificator(string message, MessageType messageType = MessageType.Info)
        {
            InitializeComponent();
            DataContext = new NotificatorViewModel(this, message, messageType);
        }
        public void CloseWindow()
        {
            Close();
        }        
    }

}
