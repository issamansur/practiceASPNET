namespace practiceASPNET.Domains;

public interface IEvent
{
    public int Id { get; set; }
    public string Data { get; set; }
}