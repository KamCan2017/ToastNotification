
#region Usings

using Prism.Mvvm;
using System.Timers;
using System.Windows;
using System.Windows.Media;

#endregion

namespace ToastNotification
{
    internal class NotificatorViewModel : BindableBase
    {
        private string _text;
        private double _opacity = 1;
        private double _leftPosition;

        private SolidColorBrush _background;
        private Timer _changeOpacityTimer;
        private Timer _closingWindowTimer;

        private readonly INotificator _notificator;


        public NotificatorViewModel(INotificator notificator)
        {
            _notificator = notificator;
            Design(MessageType.Info);
            SetLocation();
            InitTimer();
        }

         public NotificatorViewModel(INotificator notificator, string message, MessageType messageType = MessageType.Info)
        {
             _notificator = notificator;
            Text = message;
            Design(messageType);
            SetLocation();
            InitTimer();
        }

        public string Text { get => _text; set => SetProperty(ref _text, value); }

        public SolidColorBrush Background { get => _background; set => SetProperty(ref _background, value); }

        public double Opacity { get => _opacity; set => SetProperty(ref _opacity, value); }

        public double LeftPosition  { get => _leftPosition; set => SetProperty(ref _leftPosition, value); }

         private void Design(MessageType messageType)
        {
            switch(messageType)
            {
                case MessageType.Warning:
                Background = Brushes.OrangeRed;
                break;

                case MessageType.Error:
                Background = Brushes.Red;
                break;

                case MessageType.Success:
                Background = Brushes.Green;
                break;

                default:
                Background = Brushes.Gray;
                break;
            }
        }

        private void SetLocation()
        {
            LeftPosition = SystemParameters.WorkArea.BottomRight.X * 0.8;
        }       
       
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {             
             Application.Current.Dispatcher.Invoke(() =>
            {
                _closingWindowTimer.Stop();
                _changeOpacityTimer.Stop();
                _closingWindowTimer.Dispose();
                _changeOpacityTimer.Dispose();
                _notificator.CloseWindow();
             });
        }        
        private void InitTimer()
        {
            _closingWindowTimer = new Timer(3000);
            _closingWindowTimer.Elapsed += Timer_Elapsed;            
            _closingWindowTimer.Start();           

            _changeOpacityTimer = new Timer(500);
            _changeOpacityTimer.Elapsed += ChangeOpacityTimer_Elapsed;       
            _changeOpacityTimer.Start();
        }

        private async void ChangeOpacityTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
             await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                 if(Opacity >= 0.7)
                     Opacity -=  0.1;
             });          
        }
       
    }
}