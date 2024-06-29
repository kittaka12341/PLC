namespace ServerSimulator.ViewModels
{
    public class ServerSimViewModel : BindableBase, IDisposable
    {
        private CompositeDisposable disposables = new CompositeDisposable();
        private ServerSimData serverSimData;

        private List<ReactiveProperty<bool>> _toggleButtonProperties;

        public List<ReactiveProperty<bool>> ToggleButtonProperties { get ; set ;}
        public ReactiveProperty<string> CurrentRegisterValue { get; set; }

        public ServerSimViewModel(ServerSimData _simData)
        {
            serverSimData = _simData;

            ToggleButtonProperties = new List<ReactiveProperty<bool>>();
            CurrentRegisterValue = new ReactiveProperty<string>();

            for (int i = 0; i < serverSimData.BitSize; i++)
            {
                ToggleButtonProperties.Add(new ReactiveProperty<bool>());
            }
            foreach(var buttonProperty in ToggleButtonProperties)
            {
                buttonProperty.Subscribe(OnChanged).AddTo(disposables);
            }
        }

        private void OnChanged(bool value)
        {
            int bitSize = 8;
            int size = serverSimData.ByteSize;
            int count = 0;
            byte[] _bytes = new byte[size];
            Array.Fill<byte>(_bytes, 0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < bitSize; j++)
                {
                    _bytes[i] |= ToggleButtonProperties[count].Value ? (byte)(0x80 >> j) : (byte)0;
                    count++;
                }
            }
            serverSimData.OutData = _bytes;

            var ret = _bytes[0].ToString("x2") + _bytes[1].ToString("x2");
            CurrentRegisterValue.Value = ret;
        }

        public void Dispose()
        {
            disposables?.Dispose();           
        }
    }
}
