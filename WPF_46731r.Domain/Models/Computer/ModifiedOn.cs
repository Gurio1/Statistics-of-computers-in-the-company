namespace WPF_46731r.Domain.Models.Computer
{
    public class ModifiedOn
    {
        public ModifiedOn()
        {
            
        }

        public ModifiedOn(ModifiedOn modifiedOn)
        {
            CheckedOn = modifiedOn.CheckedOn;
            CheckedBy = modifiedOn.CheckedBy;
            Log = modifiedOn.Log;
        }
        public DateTime CheckedOn { get; set; }
        public string CheckedBy { get; set; }
        public string Log { get; set; }
    }


}
