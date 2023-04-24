using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Xml.Linq;

namespace eee
{
    public partial class MainWindow : Window
    {
        public static ObservableCollection<string> types = new();
        int index;
        int selected_index_note_in_notes;
        int price;
        Note note;
        static ObservableCollection<Note> notes = new ObservableCollection<Note>();
        static ObservableCollection<Note> dop_note = new ObservableCollection<Note>();
        DateTime date;
        public MainWindow()
        {
            InitializeComponent();
            date = DateTime.Today;
            Calendar.SelectedDate = date;
            notes = new ObservableCollection<Note>();
            notes = in_file.Mydeserializer<Note>("notes");
            data_grid.ItemsSource = notes;
            types = new ObservableCollection<string>();
            types = in_file.Mydeserializer<string>("types");
            type_list.ItemsSource = types;
            sum();
        }

        private void create_type_Click(object sender, RoutedEventArgs e)
        {
            small_win small_win = new small_win();
            small_win.Show();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            Note note = new Note(name.Text, type_list.Text, Convert.ToInt32(money_product.Text), true, (DateTime)Calendar.SelectedDate);
            notes.Add(note);
            in_file.Serialize(notes, "notes");
            name.Text = "";
            money_product.Text = "";
            sum();
        }


        private void Calendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            create.IsEnabled = true;
            delete.IsEnabled = true;
            update.IsEnabled = true;
            if (notes.Count > 0)
            {
                foreach (Note note in notes)
                {
                    if (Calendar.SelectedDate == note.Date)
                    {
                        dop_note.Add(note);
                    }
                }
                data_grid.ItemsSource = dop_note;
            }
        }

        private void data_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            note = data_grid.SelectedItem as Note;
            index = data_grid.SelectedIndex;
            find_index();
            if (index >= 0)
            {
                index = 0;
                name.Text = notes[selected_index_note_in_notes].Name;
                type_list.Text = notes[selected_index_note_in_notes].Type;
                money_product.Text = $"{notes[selected_index_note_in_notes].Price}";
            }
        }

        private void find_index()
        {
            int sub_perem = 0;
            foreach (var Note in notes)
            {
                if (note == Note)
                {
                    selected_index_note_in_notes = sub_perem;
                    break;
                }
                sub_perem++;
            }
        }

        private void sum()
        {
            price = 0;
            foreach (Note note in notes)
            {
                int cost = note.Price;
                price = price + cost;
                cost = 0;
            }
            end.Content = price;
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            index = data_grid.SelectedIndex;
            find_index();
            notes.RemoveAt(selected_index_note_in_notes);

            Note note = new Note(name.Text, type_list.Text, Convert.ToInt32(money_product.Text), true, (DateTime)Calendar.SelectedDate);
            notes.Add(note);
            in_file.Serialize(notes, "notes");
            name.Text = "";
            money_product.Text = "";
            sum();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            note = data_grid.SelectedItem as Note;
            index = data_grid.SelectedIndex;
            find_index();
            notes.RemoveAt(selected_index_note_in_notes);
            in_file.Serialize<Note>(notes, "notes");
        }
    }
}