using deneme1.DBModels;
using Microsoft.Ajax.Utilities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace deneme1.MongoOperations
{
    public static class UserOperations
    {
        public static string connectionString = "mongodb+srv://kardanoz16:rasengan9e9e@cluster0.p0jwc.mongodb.net/<dbname>?retryWrites=true&w=majority";


        // insert user to the database
        public static Boolean CreateUser(User user)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("LiveWebDB");
            var collec = db.GetCollection<User>("UserInfo");

            var filter = Builders<User>.Filter.Eq(x => x.userName, user.userName);
            var firstDocument = collec.Find(filter).ToList();
            // aynı kullanıcı adıyla kücük yaş gir son büyük yaş gir bug var düzelt

            if (firstDocument == null || firstDocument.Count == 0)
            {
                collec.InsertOne(user);
                return true;
            }
            else
            {
                return false;
            }

            
        }

        // is there a that user ?
        public static Boolean IsThereUser(User user)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("LiveWebDB");
            var collec = db.GetCollection<User>("UserInfo");

            var filter = Builders<User>.Filter.Eq(x => x.userName, user.userName);
            filter &= (Builders<User>.Filter.Eq(x => x.password, user.password));


            var firstDocument = collec.Find(filter).ToList();
            if(firstDocument.Count == 1)
            {
                return true;
            }
            return false;
           
        }

        // read(find) data from the database
        public static List<User> FindAllUsers()
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("LiveWebDB");
            var collec = db.GetCollection<User>("UserInfo");

            return collec.Find(_ => true).ToList();
        }


        // delete user from database
        public static Boolean DeleteUser(string userName)
        {

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("LiveWebDB");
            var collec = db.GetCollection<User>("UserInfo");
            var filter = Builders<User>.Filter.Eq(x => x.userName, userName);

            

            return collec.DeleteOne(filter).IsAcknowledged;

        }

        // update user from database
        public static Boolean UpdateUser(User user,string username)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("LiveWebDB");
            var collec = db.GetCollection<User>("UserInfo");


            var filter = Builders<User>.Filter.Eq(x => x.userName, username);
            var update = Builders<User>.Update.Set(x => x.password , user.password);
            update = update.Set(x => x.Age , user.Age);
            update = update.Set(x => x.userName , user.userName);
            UpdateResult result = collec.UpdateOne(filter, update);

            Boolean result2 = result.IsAcknowledged;

            return result2;


        }

        public static User GetUserInfo(string userName)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("LiveWebDB");
            var collec = db.GetCollection<User>("UserInfo");

            var filter = Builders<User>.Filter.Eq(x => x.userName, userName);

            return collec.Find(filter).ToList()[0];

        }
    }
}