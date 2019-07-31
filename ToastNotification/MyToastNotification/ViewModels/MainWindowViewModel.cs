
#region Usings

using Prism.Commands;
using Prism.Mvvm;
using ToastNotification;

#endregion

namespace MyToastNotification
{
    public class MainWindowViewModel : BindableBase
    {
        private string _text;

        public MainWindowViewModel()
        {
            SendSuccessCommand = new DelegateCommand(() =>  SendMessage(MessageType.Success));
            SendErrorCommand = new DelegateCommand(() =>  SendMessage(MessageType.Error));
            SendWarningCommand = new DelegateCommand(() =>  SendMessage(MessageType.Warning));
            SendInfoCommand = new DelegateCommand(() =>  SendMessage(MessageType.Info));
            ClearCommand = new DelegateCommand(() => { Text = string.Empty;});
        }
        public string Text { get => _text; set => SetProperty(ref _text, value); }

        public DelegateCommand SendSuccessCommand { get; set; }

         public DelegateCommand SendErrorCommand { get; set; }

         public DelegateCommand SendWarningCommand { get; set; }

         public DelegateCommand SendInfoCommand { get; set; }

        public DelegateCommand ClearCommand { get; set; }

        private void SendMessage(MessageType messageType)
        {
          NotificationProvider.Notify(Text, messageType);
        }   
       
    }
}