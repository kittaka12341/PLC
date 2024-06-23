using Prism.Mvvm;
using Prism.Regions;
using UIContents.Views;

namespace Coop.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly IRegionManager regionManager;

        public MainWindowViewModel(IRegionManager _regionManager)
        {
            this.regionManager = _regionManager;
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ServerSim));
        }
    }
}
