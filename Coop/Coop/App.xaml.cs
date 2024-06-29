namespace Coop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ServerSimData serverSimData = new ServerSimData(1);
            containerRegistry.RegisterInstance(serverSimData);
            containerRegistry.Register<IClientSender, ServerSimulatorClient>();
        }
    }
}
