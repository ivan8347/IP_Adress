namespace IP_Adress
{
    public class IpClass
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private string _binaryStart;
        public string BinaryStart
        {
            get => _binaryStart;
            set
            {
                _binaryStart = value;
                GenerateBits();
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
            }
        }

        public string DecimalStart { get; set; }
        public string DecimalEnd { get; set; }

        public string FirstBits { get; set; }
        public string OtherBits { get; set; }

        public string FirstBitsEnd { get; set; }
        public string OtherBitsEnd { get; set; }

        public string Structure { get; set; }

        public int BitsNetwork { get; set; }
        public int BitsHost { get; set; }

        public string Networks { get; set; }
        public string Hosts { get; set; }

        public string NetworksExplanation { get; set; }
        public string HostsExplanation { get; set; }

        public string MaskSlash { get; set; }
        public string MaskDecimal { get; set; }

        public string Color { get; set; }

        // ПУСТОЙ КОНСТРУКТОР — обязателен для new IpClass { ... }
        public IpClass()
        {
        }

        private void GenerateBits()
        {
            if (string.IsNullOrEmpty(BinaryStart) || string.IsNullOrEmpty(BinaryEnd))
                return;

            // START
            if (BinaryStart.StartsWith("0")) // A
            {
                FirstBits = BinaryStart.Substring(0, 1);
                OtherBits = BinaryStart.Substring(1);
            }
            else if (BinaryStart.StartsWith("10")) // B
            {
                FirstBits = BinaryStart.Substring(0, 2);
                OtherBits = BinaryStart.Substring(2);
            }
            else if (BinaryStart.StartsWith("110")) // C
            {
                FirstBits = BinaryStart.Substring(0, 3);
                OtherBits = BinaryStart.Substring(3);
            }

            // END
            if (BinaryEnd.StartsWith("0")) // A
            {
                FirstBitsEnd = BinaryEnd.Substring(0, 1);
                OtherBitsEnd = BinaryEnd.Substring(1);
            }
            else if (BinaryEnd.StartsWith("10")) // B
            {
                FirstBitsEnd = BinaryEnd.Substring(0, 2);
                OtherBitsEnd = BinaryEnd.Substring(2);
            }
            else if (BinaryEnd.StartsWith("110")) // C
            {
                FirstBitsEnd = BinaryEnd.Substring(0, 3);
                OtherBitsEnd = BinaryEnd.Substring(3);
            }
        }
    }


}
