namespace IP_Adress
{
    public class IpClass
    {
        public string Name { get; set; }

        public string BinaryStart { get; set; }
        public string BinaryEnd { get; set; }

        public string DecimalStart { get; set; }
        public string DecimalEnd { get; set; }

        public string Structure { get; set; }

        public int BitsNetwork { get; set; }
        public int BitsHost { get; set; }

        public string Networks { get; set; }
        public string Hosts { get; set; }

        public string MaskSlash { get; set; }
        public string MaskDecimal { get; set; }

        public string Description { get; set; }
        public string Color { get; set; }
    }
}
