HR.LeaveManagement.Application.Reponses;
public class BaseCommandResponse{
    public int Id {get;set;}
    public bool Success {get;set;} = true;
    public string Messgae {get;set;}
    public List<string> Errors {get;set;}
}