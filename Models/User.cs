namespace ZonkeTechAccessControlAPI.Models;


public class User{
    public string Id{get;set;}
    public string Name{get;set;}
    public string Surname{get;set;}
    public string PhoneNumber{get;set;}
    public string Email{get;set;}
    public string Password{get;set;}
    public DateTime LastLogin{get;set;}

}