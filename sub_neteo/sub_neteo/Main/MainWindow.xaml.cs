using System;
using System.Windows;
using sub_neteo.Pages;

namespace sub_neteo
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

        private void click_programador(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/programador.xaml", UriKind.RelativeOrAbsolute));
        }

        private void click_home(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(DataInter.direccion_ip) && !String.IsNullOrEmpty(DataInter.numero_redes))
            {
                PagesNavigation.Navigate(new home("0", DataInter.numero_redes));
            }

            else if (!String.IsNullOrEmpty(DataInter.direccion_ip) && String.IsNullOrEmpty(DataInter.numero_redes))
            {
                PagesNavigation.Navigate(new home(DataInter.direccion_ip, "0"));
            }

            else if (!String.IsNullOrEmpty(DataInter.direccion_ip) && !String.IsNullOrEmpty(DataInter.numero_redes))
            {
                PagesNavigation.Navigate(new home(DataInter.direccion_ip, DataInter.numero_redes));
            }
            else
            {
                PagesNavigation.Navigate(new home());
            }
        }

        private void click_tabla(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(DataInter.direccion_ip) && !String.IsNullOrEmpty(DataInter.numero_redes))
            {
                PagesNavigation.Navigate(new Tabla("0", DataInter.numero_redes));
            }

            else if (!String.IsNullOrEmpty(DataInter.direccion_ip) && String.IsNullOrEmpty(DataInter.numero_redes))
            {
                PagesNavigation.Navigate(new Tabla(DataInter.direccion_ip, "0"));
            }

            else if (!String.IsNullOrEmpty(DataInter.direccion_ip) && !String.IsNullOrEmpty(DataInter.numero_redes))
            {
                PagesNavigation.Navigate(new Tabla(DataInter.direccion_ip, DataInter.numero_redes));
            }
            else
            {
                PagesNavigation.Navigate(new Tabla());
            }
            
        }

        private void btnMain(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
