using deneme1.DBModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace deneme1.MongoOperations
{
    public static class UserOperations
    {
        public static string connectionString = "mongodb+srv://kardanoz16:rasengan9e9e@cluster0.p0jwc.mongodb.net/<dbname>?retryWrites=true&w=majority";

        public static void CreateUser(User user)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("LiveWebDB");
            var collec = db.GetCollection<User>("UserInfo");

            collec.InsertOne(user);

            // insert database

        
        }

    }
}