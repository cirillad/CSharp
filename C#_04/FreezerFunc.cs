namespace C__04
{
    public partial class Freezer
    {
        public void ChangeCapacity(double newCapacity)
        {
            capacity = newCapacity;
        }

        public void UpdateDimensions(double newWidth, double newHeight)
        {
            width = newWidth;
            height = newHeight;
        }

        public void SetPowerConsumption(int newPowerConsumption)
        {
            powerConsumption = newPowerConsumption;
        }

        public override string ToString()
        {
            return $"Freezer Info: \n" +
                   $"- Brand: {Brand}\n" +
                   $"- Capacity: {Capacity} liters\n" +
                   $"- Dimensions: {Width}cm (W) x {Height}cm (H)\n" +
                   $"- Power Consumption: {PowerConsumption} W";
        }
    }
}
