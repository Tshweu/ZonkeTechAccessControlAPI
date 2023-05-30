namespace ZonkeTechAccessControlAPI.Services;

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ZonkeTechAccessControlAPI.Models;

public class UserMongoDBService{
    private readonly IMongoCollection<User> _userCollection;

    public UserMongoDBService(IMongoClient mongoClient){
        
    }

    
}