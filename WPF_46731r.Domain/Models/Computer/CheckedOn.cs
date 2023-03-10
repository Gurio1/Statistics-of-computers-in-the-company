namespace WPF_46731r.Domain.Models.Computer
{
    public class CheckedOn
    {
        public CheckedOn()
        {
            
        }

        public CheckedOn(CheckedOn checkedOn)
        {
            this.checkedOn = checkedOn.checkedOn;
            CheckedBy = checkedOn.CheckedBy;
        }
        public DateTime checkedOn { get; set; }
        public string CheckedBy { get; set; }
    }


}
