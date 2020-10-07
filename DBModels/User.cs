using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace deneme1.DBModels
{
    public class User
    {
        public MongoDB.Bson.ObjectId ID;
        public string userName;
        public string password;
        public int Age;

    }
}