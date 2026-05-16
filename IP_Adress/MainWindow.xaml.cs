using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IP_Adress
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            LoadClasses();
        }

        private void LoadClasses()
        {
            IpList.ItemsSource = new List<IpClass>
            {
                new IpClass
                {
                    Name = "Класс A",

                    BinaryStart = "00000000",
                    BinaryEnd   = "01111111",

                    DecimalStart = "1.0.0.0",
                    DecimalEnd   = "126.255.255.255",

                    Structure = "N.H.H.H",

                    BitsNetwork = 7,
                    BitsHost = 24,

                    Networks = "128 (фактически 126)",
                    Hosts = "16 777 214",

                    MaskSlash = "/8",
                    MaskDecimal = "255.0.0.0",

                    Description = "Очень крупные сети. Первый байт - сеть. Можно подключить не более 16 777 214 устройств. ",
                    Color = "#FF1E3A5F"
                },

                new IpClass
                {
                    Name = "Класс B",

                    BinaryStart = "10000000",
                    BinaryEnd   = "10111111",

                    DecimalStart = "128.0.0.0",
                    DecimalEnd   = "191.255.255.255",

                    Structure = "N.N.H.H",

                    BitsNetwork = 14,
                    BitsHost = 16,

                    Networks = "16 384",
                    Hosts = "65 534",

                    MaskSlash = "/16",
                    MaskDecimal = "255.255.0.0",

                    Description = "Средние сети. Первые два октета — сеть.",
                    Color = "#FF225F3A"
                },

                new IpClass
                {
                    Name = "Класс C",

                    BinaryStart = "11000000",
                    BinaryEnd   = "11011111",

                    DecimalStart = "192.0.0.0",
                    DecimalEnd   = "223.255.255.255",

                    Structure = "N.N.N.H",

                    BitsNetwork = 21,
                    BitsHost = 8,

                    Networks = "2 097 152",
                    Hosts = "254",

                    MaskSlash = "/24",
                    MaskDecimal = "255.255.255.0",

                    Description = "Малые сети. Первые три октета — сеть.",
                    Color = "#FF5F3A22"
                }
            };
        }

       

        private void CheckIpClass_Click(object sender, RoutedEventArgs e)
        {
            string ip = IpInput.Text.Trim();
            if (!System.Net.IPAddress.TryParse(ip, out _))
            {
                MessageBox.Show("Некорректный IP");
                return;
            }

            string[] parts = ip.Split('.');
            int first = int.Parse(parts[0]);

            // выводим октеты
            Oct1Text.Text = parts[0];
            Oct2Text.Text = parts[1];
            Oct3Text.Text = parts[2];
            Oct4Text.Text = parts[3];

            // сброс цвета
            ResetOctetColors();

            // определяем класс
            if (first >= 1 && first <= 126)
            {
                HighlightClassA();
            }
            else if (first >= 128 && first <= 191)
            {
                HighlightClassB();
            }
            else if (first >= 192 && first <= 223)
            {
                HighlightClassC();
            }
            else
            {
                MessageBox.Show("Это не класс A/B/C");
            }
        }

        private void ResetOctetColors()
        {
            Oct1.Background = Oct2.Background = Oct3.Background = Oct4.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(50, 50, 50));
        }

        private void HighlightClassA()
        {
            Oct1.Background = Brushes.SteelBlue;   // сеть
            Oct2.Background = Brushes.DarkOrange;  // хост
            Oct3.Background = Brushes.DarkOrange;
            Oct4.Background = Brushes.DarkOrange;
        }

        private void HighlightClassB()
        {
            Oct1.Background = Brushes.SeaGreen;    // сеть
            Oct2.Background = Brushes.SeaGreen;    // сеть
            Oct3.Background = Brushes.DarkOrange;  // хост
            Oct4.Background = Brushes.DarkOrange;
        }

        private void HighlightClassC()
        {
            Oct1.Background = Brushes.Brown;   // сеть
            Oct2.Background = Brushes.Brown;   // сеть
            Oct3.Background = Brushes.Brown;   // сеть
            Oct4.Background = Brushes.DarkOrange;  // хост
        }
        private void PowerInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(PowerInput.Text, out int power))
            {
                FormulaResult.Text = Math.Pow(2, power).ToString("N0");
            }
            else
            {
                FormulaResult.Text = "";
            }
        }

    }
}
