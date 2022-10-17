using Lopushok.DB;
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
using System.IO;
using System.Collections.ObjectModel;
using Lopushok.Pages;

namespace Lopushok
{
    /// <summary>
    /// Interaction logic for LopushokWindow.xaml
    /// </summary>
    public partial class LopushokWindow : Window
    {
        public string pageTitle { get; set; }
        public LopushokWindow()
        {
            InitializeComponent();
            frame.Navigated += Frame_Navigated;
            frame.NavigationService.Navigate(new ProductsListPage());
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            var pageContent = frame.Content;
            pageTitle = (pageContent as Page).Title;
            tbTitle.Text = pageTitle;
        }
    }
}
