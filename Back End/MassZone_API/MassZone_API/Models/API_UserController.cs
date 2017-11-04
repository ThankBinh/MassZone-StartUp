using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MassZone_API.Models;
using Newtonsoft.Json.Linq;

namespace MassZone_API.Models
{
    public class API_UserController : ApiController
    {
        DataContext db = new DataContext();

        public JToken Get()
        {
            return JToken.FromObject(db.Users.ToList());
        }
        public JToken Get(int id)
        {
            return JToken.FromObject(db.Users.Where(x => x.userId == id));
        }
    }
}
