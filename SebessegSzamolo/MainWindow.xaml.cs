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

namespace SebessegSzamolo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sliCsuszka.ValueChanged += sliCsuszka_ValueChanged;
        }

        private void sliCsuszka_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labCsuszka.Content = sliCsuszka.Value.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double textboxertek=-1;
            try
            {
                textboxertek = double.Parse(tbKapacitas.Text);
            }
            catch (FormatException)
            {          
                MessageBox.Show("Nem jól adtad meg a kapacitást","Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (textboxertek!=-1)
            {
                double kapacitaskb = textboxertek;
                if (cbKapacitas.SelectionBoxItem.ToString() == "MB")
                {
                    kapacitaskb = textboxertek * 1000;
                }
                else if (cbKapacitas.SelectionBoxItem.ToString() == "GB")
                {
                    kapacitaskb = textboxertek * 1000 * 1000;
                }
                else if (cbKapacitas.SelectionBoxItem.ToString() == "TB")
                {
                    kapacitaskb = textboxertek * 1000 * 1000 * 1000;
                }
                double csuszkaertek = Convert.ToInt32(sliCsuszka.Value);
                double atvitelisebessegkb = csuszkaertek;

                if (cbAtviteliSebesseg.SelectionBoxItem.ToString() == "MBps")
                {
                    atvitelisebessegkb = csuszkaertek * 1000;
                }
                else if (cbAtviteliSebesseg.SelectionBoxItem.ToString() == "GBps")
                {
                    atvitelisebessegkb = csuszkaertek * 1000 * 1000;
                }
                else if (cbAtviteliSebesseg.SelectionBoxItem.ToString() == "TBps")
                {
                    atvitelisebessegkb = csuszkaertek * 1000 * 1000 * 1000;
                }
                TimeSpan t = TimeSpan.FromSeconds(kapacitaskb / atvitelisebessegkb);

                string ido = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);
                labEredmeny.Content = ido;
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Bezárás_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Tálca_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
