namespace WPF_46731r.Domain.Models.Computer
{
    public class Characteristics
    {
        public Characteristics()
        {
            
        }

        public Characteristics(Characteristics characteristics)
        {
            Processor = characteristics.Processor;
            Ram = characteristics.Ram;
            MotherBoard = characteristics.MotherBoard;
            Storage = characteristics.Storage;
            ComputerId = characteristics.ComputerId;
            Id = characteristics.Id;
        }
        public int ComputerId { get; set; }
        public int Id { get; set; }
        public string Processor { get; set; }
        public int Ram { get; set; }
        public string MotherBoard { get; set; }
        public int Storage { get; set; }
    }


}
