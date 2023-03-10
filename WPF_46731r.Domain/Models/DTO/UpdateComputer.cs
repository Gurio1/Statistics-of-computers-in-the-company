using WPF_46731r.Domain.Models.Computer;

namespace WPF_46731r.Domain.Models.DTO;

public class UpdateComputer
{
    public int Id { get; set; }
    public int InventoryNumber { get; set; }
    public string HostName { get; set; }
    public string Mac { get; set; }
        
    public State State { get; set; }
    public Characteristics Characteristics { get; set; }

    public UpdateComputer(int id,int inventoryNumber,string hostName, string mac, Characteristics characteristics,State state)
    {
        Id = id;
        InventoryNumber = inventoryNumber;
        HostName = hostName;
        Mac = mac;
        Characteristics = characteristics;
        State = state;
    }
}