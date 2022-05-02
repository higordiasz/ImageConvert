using ImageConverter.Viewer;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ImageConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ImageMultiple.Source = new BitmapImage(new Uri("pack://application:,,,/Image/1.png"));
            ImageSingle.Source = new BitmapImage(new Uri("pack://application:,,,/Image/2.png"));
            ImageLeave.Source = new BitmapImage(new Uri("pack://application:,,,/Image/3.png"));
            ContentPage.Content = new SingleControl();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        private void Border_Multiple_Enter (object sender, MouseEventArgs e)
        {
            ImageMultiple.Source = new BitmapImage(new Uri("pack://application:,,,/Image/11.png"));
        }

        private void Border_Multiple_Leave (object sender, MouseEventArgs e)
        {
            ImageMultiple.Source = new BitmapImage(new Uri("pack://application:,,,/Image/1.png"));
        }

        private void Border_Single_Enter(object sender, MouseEventArgs e)
        {
            ImageSingle.Source = new BitmapImage(new Uri("pack://application:,,,/Image/22.png"));
        }

        private void Border_Single_Leave(object sender, MouseEventArgs e)
        {
            ImageSingle.Source = new BitmapImage(new Uri("pack://application:,,,/Image/2.png"));
        }

        private void Border_Leave_Enter(object sender, MouseEventArgs e)
        {
            ImageLeave.Source = new BitmapImage(new Uri("pack://application:,,,/Image/33.png"));
        }

        private void Border_Leave_Leave(object sender, MouseEventArgs e)
        {
            ImageLeave.Source = new BitmapImage(new Uri("pack://application:,,,/Image/3.png"));
        }

        private void Border_Leave_Click (object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Border_Single_Click (object sender, MouseButtonEventArgs e)
        {
            ContentPage.Content = new SingleControl();
        }

        private void Border_Multiple_Click(object sender, MouseButtonEventArgs e)
        {
            ContentPage.Content = new MultipleControl();
        }
    }
}
