using Microsoft.SqlServer.Server;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Controls;


namespace Assignment4
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<empInfo> myList = new ObservableCollection<empInfo>();
        
        public  ObservableCollection<empInfo> MyList
        {
            get { return myList; }
            set
            {
                myList.Add(new empInfo());
                NotifyPropertyChanged(value.ToString());
            }
            

        }

        public class empInfo
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public override string ToString()
            {
                return ID.ToString() + " " + FirstName.ToString() + " " + LastName.ToString();
            }

        }
        
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyList.Add(new empInfo()
            {
                FirstName = "test",
                LastName = "test",
                ID = 0
            });

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ModalForm popup = new ModalForm(this);
            var dialog = popup.ShowDialog();

            if (dialog == true)
            {
                Debug.WriteLine("OK");

                foreach (empInfo employee in myList)
                {
                    Debug.Write(employee.FirstName);
                }
            }
            else
            {
                Debug.WriteLine("No");
            }


            popup.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selected = listView.SelectedIndex;
            Debug.WriteLine(selected);
            MyList.Remove(MyList[selected]);
        }

        private void list_GotFocus(object sender, RoutedEventArgs e)
        {
            var focusedItem = (e.OriginalSource as ListViewItem)?.Content;
            Debug.WriteLine(focusedItem);
        }
    }
}
