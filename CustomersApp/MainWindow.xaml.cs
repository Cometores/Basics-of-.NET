using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WiredBrainCoffee.CustomersApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
    {
      //var column = (int)customerListGrid.GetValue(Grid.ColumnProperty);

      //var newColumn = column == 0 ? 2 : 0;
      //customerListGrid.SetValue(Grid.ColumnProperty, newColumn);

      var column = Grid.GetColumn(customerListGrid);

      var newColumn = column == 0 ? 2 : 0;
      Grid.SetColumn(customerListGrid, newColumn);
    }
  }
}
