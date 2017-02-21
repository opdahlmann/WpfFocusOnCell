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

namespace WpfFocusOnCell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Car> Cars = new List<Car>();
        private DataGridColumn yourColumn;
        private Car yourObject;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Cars.Clear();
            Cars.Add(new Car() { Id = 1, Brand = "BMW", Color = "Gray" });
            Cars.Add(new Car() { Id = 2, Brand = "BMW", Color = "Blue" });
            Cars.Add(new Car() { Id = 1, Brand = "Volvo", Color = "red" });
            dataGrid.ItemsSource = Cars;
            yourColumn = dataGrid.Columns[2];
            yourObject = Cars.LastOrDefault();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.UpdateLayout();
            dataGrid.ScrollIntoView(yourObject, yourColumn);
            dataGrid.Focus();
            dataGrid.SelectedItem = yourObject; // set your object to be selected
            //if (dataGrid.SelectedItem != null)
            //{
            //    var cellcontent = dataGrid.Columns[yourColumn.DisplayIndex].GetCellContent(dataGrid.SelectedItem);
            //    var cell = cellcontent?.Parent as DataGridCell;
            //    if (cell != null)
            //    {
            //        cell.Focus();
            //    }
            //}
        }
    }

    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
    }
}
