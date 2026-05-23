using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace IP_Adress
{
    public class IpClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        public string Name { get; set; }
        public string Description { get; set; }

        public int BitsNetwork { get; set; }
        public int BitsHost { get; set; }

        public string MaskSlash { get; set; }
        public string MaskDecimal { get; set; }

        public string Color { get; set; }

        // -----------------------------
        // Бинарные диапазоны
        // -----------------------------

        private string _binaryStart;
        public string BinaryStart
        {
            get => _binaryStart;
            set
            {
                _binaryStart = value;
                GenerateBits();
                OnPropertyChanged();
            }
        }

        private string _binaryEnd;
        public string BinaryEnd
        {
            get => _binaryEnd;
            set
            {
                _binaryEnd = value;
                GenerateBits();
                OnPropertyChanged();
            }
        }

        public string DecimalStart { get; set; }
        public string DecimalEnd { get; set; }

        private string _firstBits;
        public string FirstBits
        {
            get => _firstBits;
            set { _firstBits = value; OnPropertyChanged(); }
        }

        private string _otherBits;
        public string OtherBits
        {
            get => _otherBits;
            set { _otherBits = value; OnPropertyChanged(); }
        }

        private string _firstBitsEnd;
        public string FirstBitsEnd
        {
            get => _firstBitsEnd;
            set { _firstBitsEnd = value; OnPropertyChanged(); }
        }

        private string _otherBitsEnd;
        public string OtherBitsEnd
        {
            get => _otherBitsEnd;
            set { _otherBitsEnd = value; OnPropertyChanged(); }
        }

        // -----------------------------
        // Количество сетей / хостов
        // -----------------------------

        private string _networks;
        public string Networks
        {
            get => _networks;
            set
            {
                _networks = value;
                ValidateNetworks();
                OnPropertyChanged();
            }
        }

        private string _hosts;
        public string Hosts
        {
            get => _hosts;
            set
            {
                _hosts = value;
                ValidateHosts();
                OnPropertyChanged();
            }
        }

        private string _networksColor = "LightGreen";
        public string NetworksColor
        {
            get => _networksColor;
            set { _networksColor = value; OnPropertyChanged(); }
        }

        private string _hostsColor = "LightGreen";
        public string HostsColor
        {
            get => _hostsColor;
            set { _hostsColor = value; OnPropertyChanged(); }
        }

        // -----------------------------
        // Конструктор
        // -----------------------------

        public IpClass() { }

        // -----------------------------
        // Генерация подсветки первых битов
        // -----------------------------

        private void GenerateBits()
        {
            if (string.IsNullOrEmpty(BinaryStart) || string.IsNullOrEmpty(BinaryEnd))
                return;

            // START
            if (BinaryStart.StartsWith("0")) // A
            {
                FirstBits = BinaryStart.Substring(0, 1);
                OtherBits = BinaryStart.Substring(1,3) + "  " + BinaryStart.Substring(4,4);
            }
            else if (BinaryStart.StartsWith("10")) // B
            {
                FirstBits = BinaryStart.Substring(0, 2);
                OtherBits = BinaryStart.Substring(2,2) + "  " + BinaryStart.Substring(4, 4);
            }
            else if (BinaryStart.StartsWith("110")) // C
            {
                FirstBits = BinaryStart.Substring(0, 3);
                OtherBits = BinaryStart.Substring(3,1) + "  " + BinaryStart.Substring(4, 4);
            }

            // END
            if (BinaryEnd.StartsWith("0")) // A
            {
                FirstBitsEnd = BinaryEnd.Substring(0, 1);
                OtherBitsEnd = BinaryEnd.Substring(1,3) + "  " + BinaryStart.Substring(4, 4);
            }
            else if (BinaryEnd.StartsWith("10")) // B
            {
                FirstBitsEnd = BinaryEnd.Substring(0, 2);
                OtherBitsEnd = BinaryEnd.Substring(2,2) + "  " + BinaryStart.Substring(4, 4);
            }
            else if (BinaryEnd.StartsWith("110")) // C
            {
                FirstBitsEnd = BinaryEnd.Substring(0, 3);
                OtherBitsEnd = BinaryEnd.Substring(3,1) + "  " + BinaryStart.Substring(4, 4);
            }
        }

        // -----------------------------
        // Проверка правильности ввода
        // -----------------------------

        private void ValidateNetworks()
        {
            if (Name == "Класс A")
            {
               if (Networks == "126")
                {
                    NetworksColor = "LightGreen";
                }
               else if (Networks == "128")
                {
                    NetworksColor = "Red";
                    MessageBox.Show("НЕТ. Правильное количество сетей = 126.\n А почему - спросите у Олега Анатольевича!!!");
                       // "128 — это 2^7, но 0 и 127 зарезервированы.");
                }
                else
                {
                    NetworksColor = "Red";
                }
                return;
            }
           
            if (Name == "Класс B")
            {
                NetworksColor = (Networks == "16384") ? "LightGreen" : "Red";
                return;
            }

            if (Name == "Класс C")
            {
                NetworksColor = (Networks == "2097152") ? "LightGreen" : "Red";
                return;
            }

          //  NetworksColor = "LightGreen";
        }

        private void ValidateHosts()
        {

            if(Name == "Класс A")
            {
                HostsColor = (Hosts == "16777216") ? "LightGreen" : "Red";
                return;
            }

            if (Name == "Класс B")
            {
                HostsColor = (Hosts == "65536") ? "LightGreen" : "Red";
                return;
            }

            if(Name == "Класс C")
            {
                HostsColor = (Hosts == "256") ? "LightGreen" : "Red";
                return;
            }
        }
    }
}
