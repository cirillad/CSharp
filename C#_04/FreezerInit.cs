namespace C__04
{
    public partial class Freezer
    {
        private string brand;
        private double width;
        private double height;
        private double capacity;
        private int powerConsumption;

        public static double DefaultTemperature;
        public static string ManufacturerCountry;

        static Freezer()
        {
            DefaultTemperature = -18.0;
            ManufacturerCountry = "Unknown";
        }

        public Freezer() : this("Unknown", 0, 0, 0, 0) { }

        public Freezer(string brand, double capacity) : this(brand, capacity, 0, 0, 0) { }

        public Freezer(string brand, double capacity, double width) : this(brand, capacity, width, 0, 0) { }

        public Freezer(string brand, double capacity, double width, double height, int powerConsumption)
        {
            this.brand = brand;
            this.capacity = capacity;
            this.width = width;
            this.height = height;
            this.powerConsumption = powerConsumption;
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int PowerConsumption
        {
            get { return powerConsumption; }
            set { powerConsumption = value; }
        }
    }
}
