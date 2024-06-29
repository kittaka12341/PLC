namespace ServerSimulator.Views
{
    /// <summary>
    /// Interaction logic for ServerSim.xaml
    /// </summary>
    public partial class ServerSim : UserControl
    {
        ServerSimViewModel vm;
        public ServerSim(ServerSimViewModel _serverSimViewModel)
        {
            InitializeComponent();
            vm = _serverSimViewModel;
        }
    }
}
