using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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

namespace sub_neteo.Pages
{
    /// <summary>
    /// Lógica de interacción para Tabla.xaml
    /// </summary>
    public partial class Tabla : Page
    {
        public Tabla()
        {
            InitializeComponent();
        }

        private string extraer(List<char> palabras)
        {
            string cortada = "";
            int puntos = 0;

            for (int i = 0; i <= palabras.Count; i++)
            {
                if (puntos == 3)
                {
                    break;
                }
                else
                {
                    cortada = cortada + palabras[i];
                    if (palabras[i] =='.')
                    {
                        puntos++;
                    }
                }
            }

            return cortada;
        }

        private int bits(int n)
        {
            if (n == 0 || n == 1 || n > 128)
            {
                return 0;
            }

            else if (n == 2)
            {
                return 2;
            }

            else if (n <= 6)
            {
                return 3;
            }

            else if (n <= 14)
            {
                return 4;
            }

            else if (n <= 30)
            {
                return 5;
            }

            else if (n <= 62)
            {
                return 6;
            }

            else if (n <= 128)
            {
                return 7;
            }
            else
            {
                return 0;

            }
        }

        private void NumeroRedes(object sender, TextChangedEventArgs e)
        {
            string valor = tb_numeroRedes.Text;
            int bit_quitar = bits(Convert.ToInt32(valor));

            if (!String.IsNullOrEmpty(tb_direccionIP.Text) && !String.IsNullOrEmpty(tb_numeroRedes.Text))
            {
                Generar();
            }

        }

        private void Generar()
        {
            string direccionIP = tb_direccionIP.Text;
            List<char> numeros = new List<char>();
            numeros.AddRange(direccionIP);
            string valor = tb_numeroRedes.Text;
            int bit_quitar = bits(Convert.ToInt32(valor));
            List<rangoIP> lista_elementos = new List<rangoIP>();
            double n = Math.Pow(2, bit_quitar);
            string primera_parte = extraer(numeros);
            int salto = 0;
            double sal=256/n;
            int sal1 = (int)sal;
            int rango_util = sal1 - 2;

            for(int i=0; i < n; i++){
                lista_elementos.Add(new rangoIP() { subred = primera_parte+salto, ip_configurables = primera_parte+(salto+1)+" - "+primera_parte+(salto+rango_util), broadcast = primera_parte+ (salto + rango_util+1) });
                salto = salto+ sal1;
            }

            tabla.ItemsSource= lista_elementos;

        }

        private void RegistroIP(object sender, TextChangedEventArgs e)
        {
            string direccionIP = tb_direccionIP.Text;
            List<char> numeros = new List<char>();
            numeros.AddRange(direccionIP);
            if (!String.IsNullOrEmpty(tb_direccionIP.Text) && !String.IsNullOrEmpty(tb_numeroRedes.Text) && ip_correct(numeros))
            {
                Generar();
            }
        }

        public bool ip_correct(List<char> palabras)
        {
            int n = 0;

            for(int i=0; i<palabras.Count; i++) {
                if (palabras[i]=='.')
                {
                    n++;
                }
            }

            if (n == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class rangoIP{
        public string subred { get; set; }
        public string ip_configurables { get; set;}
        public string broadcast { get; set; }
    }
}
