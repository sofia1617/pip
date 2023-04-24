using eee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace eee
{
    /// <summary>
    /// Логика взаимодействия для small_win.xaml
    /// </summary>
    public partial class small_win : Window
    {
        public small_win()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            string name = new_type.Text;
            MainWindow.types.Add(name);
            in_file.Serialize(MainWindow.types, "types");
            new_type.Text = "";
            Close();
        }
    }
}