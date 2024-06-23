using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ServerSimulator.ViewModels;

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

            CreateGridItem();
        }

        private void CreateGridItem()
        {
            int _colNum = 4;
            int _rowNum = 4;

            for (int i = 0; i < _colNum; i++)
            {
                var _columnDef = new ColumnDefinition();
                _columnDef.Width = new GridLength(1, GridUnitType.Star);
                MainGrid.ColumnDefinitions.Add(_columnDef);
            }

            for (int i = 0; i < _rowNum; i++)
            {
                var _rowDef = new RowDefinition();
                _rowDef.Height = new GridLength(1, GridUnitType.Star);
                MainGrid.RowDefinitions.Add(_rowDef);
            }

            int index = 0;
            for (int _col = 0; _col < _colNum; _col++)
            {
                for (int _row = 0; _row < _colNum; _row++)
                {
                    ToggleButton _toggleButton = new ToggleButton();
                    Binding binding = new Binding();
                    string _propertyName = "Toggle" + index.ToString("D2") + ".Value";
                    binding.Path = new PropertyPath(_propertyName);
                    binding.Source = vm;
                    binding.Mode = BindingMode.TwoWay; // 双方向バインディング
                    _toggleButton.SetBinding(ToggleButton.IsCheckedProperty, binding);
                    _toggleButton.Content = index.ToString();
                    _toggleButton.SetValue(Grid.RowProperty, _row);
                    _toggleButton.SetValue(Grid.ColumnProperty, _col);
                    MainGrid.Children.Add(_toggleButton);
                    index++;
                }
            }
        }
    }
}
