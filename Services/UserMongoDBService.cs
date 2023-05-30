namespace ZonkeTechAccessControlAPI.Services;

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ZonkeTechAccessControlAPI.Models;

public class UserMongoDBService{
    private readonly IMongoCollection<User> _userCollection;

    public UserMongoDBService(IMongoClient mongoClient){
        var database = mongoClient.GetDatabase("ZonkeTechDemo");
        _userCollection = database.GetCollection<User>("Users");
    }
    public async Task<List<User>> GetAsync() {
        return await _userCollection.Find(_ => true).ToListAsync();
    }
    public async Task<User?> GetAsync(string id){
        return await _userCollection.Find(user => user.Id == id).FirstOrDefaultAsync();
    }
    public async Task CreateAsync(User user){
        await _userCollection.InsertOneAsync(user);
    }
    public async Task UpdateAsync(string id,User updatedBook) {
        await _userCollection.ReplaceOneAsync(x => x.Id == id,updatedBook);
    }
    public async Task DeleteAsync(string id) {
        await _userCollection.DeleteOneAsync(x => x.Id == id);
    } 
}