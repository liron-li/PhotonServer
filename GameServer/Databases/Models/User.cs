using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Databases.Models
{
    class User
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
    }
}
