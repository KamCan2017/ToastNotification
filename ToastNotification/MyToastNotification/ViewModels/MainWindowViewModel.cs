
#region Usings

using System.Threading.Tasks;
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
            SendSuccessCommand = new DelegateCommand(async () =>  await SendMessage(MessageType.Success));
            SendErrorCommand = new DelegateCommand(async () =>  await SendMessage(MessageType.Error));
            SendWarningCommand = new DelegateCommand(async () =>  await SendMessage(MessageType.Warning));
            SendInfoCommand = new DelegateCommand(async () =>  await SendMessage(MessageType.Info));
            ClearCommand = new DelegateCommand(() => { Text = string.Empty;});
        }
        public string Text { get => _text; set => SetProperty(ref _text, value); }

        public DelegateCommand SendSuccessCommand { get; set; }

         public DelegateCommand SendErrorCommand { get; set; }

         public DelegateCommand SendWarningCommand { get; set; }

         public DelegateCommand SendInfoCommand { get; set; }

        public DelegateCommand ClearCommand { get; set; }

        private async  Task SendMessage(MessageType messageType)
        {
          await NotificationProvider.NotifyAsync(Text, messageType);
        }   
       
    }
}