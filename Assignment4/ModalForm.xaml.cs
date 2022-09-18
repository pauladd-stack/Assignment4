using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for ModalForm.xaml
    /// </summary>
    public partial class ModalForm : Window
    {

        public MainWindow Main { get; set; }

        public ModalForm(MainWindow main)
        {
            InitializeComponent();
            this.Main = main;


        }
        
        

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Main.MyList.Add(new MainWindow.empInfo()
            {
                FirstName = firstName.Text,
                LastName = lastName.Text,
                ID = Convert.ToInt16(Main.listView.Items.Count)
            });
            DialogResult = true;
            Close();
        }
    }
}
