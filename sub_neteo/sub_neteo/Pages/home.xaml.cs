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

namespace sub_neteo.Pages
{
    /// <summary>
    /// Lógica de interacción para home.xaml
    /// </summary>
    public partial class home : Page
    {
        public home(string direccionIP = "0", string numero_redes = "0")
        {
            InitializeComponent();
            tb_direccionIP.Text = direccionIP;
            tb_numeroRedes.Text = numero_redes;
        }

        private void RegistroIP(object sender, TextChangedEventArgs e)
        {
            string direccionIP = tb_direccionIP.Text;
            List<char> numeros = new List<char>();
            numeros.AddRange(direccionIP);


            tb_clase.Text = ClasePertenece(numeros);
            tb_IPred.Text = IPred(numeros);
            tb_MascaraRed.Text = MascaraRed(numeros);

            DataInter.direccion_ip = direccionIP;

            if (!String.IsNullOrEmpty(tb_direccionIP.Text) && !String.IsNullOrEmpty(tb_numeroRedes.Text))
            {
                Calculos();
            }

        }

        private string ClasePertenece(List<char> palabras)
        {
            string valor = "";
            int numero = 0;


            for (int i = 0; i < palabras.Count; i++)
            {
                if (palabras[i] == '.')
                {
                    break;
                }
                else
                {
                    valor = valor + palabras[i];
                }
            }

            if (palabras == null)
            {
                numero = 0;
            }

            else
            {
                numero = Convert.ToInt32(valor);
            }

            if (numero >= 1 && numero <= 27)
            {
                return "A";
            }

            else if (numero >= 28 && numero <= 191)
            {
                return "B";
            }

            else if (numero >= 192 && numero <= 223)
            {
                return "C";
            }

            else
            {
                return "Error";
            }

        }

        private int ContarPuntos(List<char> palabras)
        {
            int n = 0;

            for (int i = 0; i < palabras.Count; i++)
            {
                if (palabras[i] == '.')
                {
                    n++;
                }

                if (n == 3)
                {
                    break;
                }
            }
            return n;
        }

        private string ipClaseC(List<char> palabras)
        {
            string valor = "";
            int n = 0;
            for (int i = 0; i < palabras.Count; i++)
            {
                valor += palabras[i];
                if (palabras[i] == '.')
                {
                    n++;
                }
                if (n == 3)
                {
                    break;
                }
            }
            return valor;
        }

        private string ipClaseB(List<char> palabras)
        {
            string valor = "";
            int n = 0;
            for (int i = 0; i < palabras.Count; i++)
            {
                valor += palabras[i];
                if (palabras[i] == '.')
                {
                    n++;
                }
                if (n == 2)
                {
                    break;
                }
            }
            return valor;
        }

        private string ipClaseA(List<char> palabras)
        {
            string valor = "";
            int n = 0;
            for (int i = 0; i < palabras.Count; i++)
            {
                valor += palabras[i];
                if (palabras[i] == '.')
                {
                    n++;
                }
                if (n == 1)
                {
                    break;
                }
            }
            return valor;
        }


        private string IPred(List<char> palabras)
        {
            string clase = ClasePertenece(palabras);
            string ip_red = "";

            for (int i = 0; i < palabras.Count; i++)
            {
                ip_red += palabras[i];
            }


            if (clase == "C")
            {
                if (ContarPuntos(palabras) == 0)
                {
                    return ip_red + ".0.0.0";
                }

                if (ContarPuntos(palabras) == 1)
                {
                    return ip_red + ".0.0";
                }

                if (ContarPuntos(palabras) == 2)
                {
                    return ip_red + ".0";
                }

                if (ContarPuntos(palabras) == 3)
                {
                    return ipClaseC(palabras) + "0";
                }

                else
                {
                    return "0.0.0.0";
                }
            }

            else if (clase == "B")
            {
                if (ContarPuntos(palabras) == 0)
                {
                    return ip_red + ".0.0.0";
                }

                if (ContarPuntos(palabras) == 1)
                {
                    return ip_red + ".0.0";
                }

                if (ContarPuntos(palabras) == 2)
                {
                    return ipClaseB(palabras) + "0.0";
                }

                if (ContarPuntos(palabras) == 3)
                {
                    return ipClaseB(palabras) + "0.0";
                }

                else
                {
                    return "0.0.0.0";
                }
            }

            else if (clase == "A")
            {
                if (ContarPuntos(palabras) == 0)
                {
                    return ip_red + ".0.0.0";
                }

                if (ContarPuntos(palabras) == 1)
                {
                    return ipClaseA(palabras) + "0.0.0";
                }

                if (ContarPuntos(palabras) == 2)
                {
                    return ipClaseA(palabras) + "0.0.0";
                }

                if (ContarPuntos(palabras) == 3)
                {
                    return ipClaseA(palabras) + "0.0.0";
                }

                else
                {
                    return "0.0.0.0";
                }
            }

            else
            {
                return "Error";
            }
        }

        private string MascaraRed(List<char> palabras)
        {
            string clase = ClasePertenece(palabras);

            if (clase == "C")
            {
                return "255.255.255.0";
            }
            else if (clase == "B")
            {
                return "255.255.0.0";
            }
            else if (clase == "A")
            {
                return "255.0.0.0";
            }
            else
            {
                return "Error";
            }

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
            tb_bits.Text = "" + bit_quitar;
            DataInter.numero_redes = valor;

            if (!String.IsNullOrEmpty(tb_direccionIP.Text) && !String.IsNullOrEmpty(tb_numeroRedes.Text))
            {
                Calculos();
            }

        }

        private void Calculos()
        {
            int _bits = bits(Convert.ToInt32(tb_numeroRedes.Text));
            double salto = 256 / (Math.Pow(2, _bits));
            tb_salto.Text = "" + salto;

            if (_bits == 2)
            {
                tb_SubRedUtil.Text = "2";
                tb_SubRedMascara.Text = "/26";
                tb_IPutil.Text = "62";
            }
            else if (_bits == 3)
            {
                tb_SubRedUtil.Text = "6";
                tb_SubRedMascara.Text = "/27";
                tb_IPutil.Text = "30";
            }
            else if (_bits == 4)
            {
                tb_SubRedUtil.Text = "14";
                tb_SubRedMascara.Text = "/28";
                tb_IPutil.Text = "14";
            }
            else if (_bits == 5)
            {
                tb_SubRedUtil.Text = "30";
                tb_SubRedMascara.Text = "/29";
                tb_IPutil.Text = "6";
            }
            else if (_bits == 6)
            {
                tb_SubRedUtil.Text = "62";
                tb_SubRedMascara.Text = "/30";
                tb_IPutil.Text = "2";
            }
            else if (_bits == 7)
            {
                tb_SubRedUtil.Text = "128";
                tb_SubRedMascara.Text = "/31";
                tb_IPutil.Text = "0";
            }

        }
    }
}
