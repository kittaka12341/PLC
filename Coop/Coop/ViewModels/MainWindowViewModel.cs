namespace Coop.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly CompositeDisposable disposables = new CompositeDisposable();
        private readonly IRegionManager regionManager;
        private IClientSender clientSender;

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ReactiveCommand ClickCommand { get; set; }

        public MainWindowViewModel(IRegionManager _regionManager, IClientSender _clientSender)
        {
            this.regionManager = _regionManager;
            this.clientSender = _clientSender;
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ServerSim));

            ClickCommand = new ReactiveCommand().AddTo(disposables);

            ClickCommand.Subscribe(OnClick);
        }

        private void OnClick()
        {
            // TODO:正しい送信を行うクラス構造を検討する
            byte[] _bytes = clientSender.Write(new byte[1]);
            Debug.Print(_bytes[0].ToString("x2") + _bytes[1].ToString("x2"));
        }
    }
}
