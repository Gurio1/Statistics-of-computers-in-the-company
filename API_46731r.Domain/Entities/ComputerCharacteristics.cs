namespace API_46731r.Domain.Entities
{
    public class ComputerCharacteristics : BaseEntity
    {
        public int ComputerId { get; set; }

        public string? Processor { get; set; }
        public int? RAM { get; set; }
        public string? MotherBoard { get; set; }
        public int? Storage { get; set; }
    }
}
