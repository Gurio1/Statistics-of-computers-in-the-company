using API_46731r.Domain.Entities.Identity;

namespace API_46731r.Domain.Entities.ComputerState
{
    public class ComputerModifiedOn : TimeStateCheckedByStaff
    {
        public string? Log { get; set; }
    }
}
