using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using ServerSimulator.Models;

namespace ServerSimulator.ViewModels
{
    public class ServerSimViewModel : BindableBase, IDisposable
    {
        private CompositeDisposable disposables = new CompositeDisposable();
        private ServerSimData serverSimData;

        public List<ReactiveProperty<bool>> Toggles { get; }
        public ReactiveProperty<bool> Toggle00 { get; }
        public ReactiveProperty<bool> Toggle01 { get; }
        public ReactiveProperty<bool> Toggle02 { get; }
        public ReactiveProperty<bool> Toggle03 { get; }
        public ReactiveProperty<bool> Toggle04 { get; }
        public ReactiveProperty<bool> Toggle05 { get; }
        public ReactiveProperty<bool> Toggle06 { get; }
        public ReactiveProperty<bool> Toggle07 { get; }
        public ReactiveProperty<bool> Toggle08 { get; }
        public ReactiveProperty<bool> Toggle09 { get; }
        public ReactiveProperty<bool> Toggle10 { get; }
        public ReactiveProperty<bool> Toggle11 { get; }
        public ReactiveProperty<bool> Toggle12 { get; }
        public ReactiveProperty<bool> Toggle13 { get; }
        public ReactiveProperty<bool> Toggle14 { get; }
        public ReactiveProperty<bool> Toggle15 { get; }

        public ServerSimViewModel(ServerSimData _simData)
        {
            serverSimData = _simData;

            Toggle00 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle01 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle02 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle03 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle04 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle05 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle06 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle07 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle08 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle09 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle10 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle11 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle12 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle13 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle14 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggle15 = new ReactiveProperty<bool>(false).AddTo(disposables);
            Toggles = new List<ReactiveProperty<bool>>();
            Toggles.Add(Toggle00);
            Toggles.Add(Toggle01);
            Toggles.Add(Toggle02);
            Toggles.Add(Toggle03);
            Toggles.Add(Toggle04);
            Toggles.Add(Toggle05);
            Toggles.Add(Toggle06);
            Toggles.Add(Toggle07);
            Toggles.Add(Toggle08);
            Toggles.Add(Toggle09);
            Toggles.Add(Toggle10);
            Toggles.Add(Toggle11);
            Toggles.Add(Toggle12);
            Toggles.Add(Toggle13);
            Toggles.Add(Toggle14);
            Toggles.Add(Toggle15);
            Toggle00.Subscribe(OnChanged);
            Toggle01.Subscribe(OnChanged);
            Toggle02.Subscribe(OnChanged);
            Toggle03.Subscribe(OnChanged);
            Toggle04.Subscribe(OnChanged);
            Toggle05.Subscribe(OnChanged);
            Toggle06.Subscribe(OnChanged);
            Toggle07.Subscribe(OnChanged);
            Toggle08.Subscribe(OnChanged);
            Toggle09.Subscribe(OnChanged);
            Toggle10.Subscribe(OnChanged);
            Toggle11.Subscribe(OnChanged);
            Toggle12.Subscribe(OnChanged);
            Toggle13.Subscribe(OnChanged);
            Toggle14.Subscribe(OnChanged);
            Toggle15.Subscribe(OnChanged);

        }

        private void OnChanged(bool value)
        {
            int bitSize = 8;
            int size = 2;
            int count = 0;
            byte[] _bytes = new byte[size];
            for (int i  = 0; i < size; i++)
            {
                _bytes[i] = 0;
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < bitSize; j++)
                {
                    _bytes[i] |= Toggles[count].Value ? (byte)(0x80 >> j) : (byte)0;
                    count++;
                }
            }
            serverSimData.OutData = _bytes;

            Debug.Print(_bytes[0].ToString("x2") + _bytes[1].ToString("x2"));
        }

        public void Dispose()
        {
            disposables?.Dispose();           
        }
    }
}
