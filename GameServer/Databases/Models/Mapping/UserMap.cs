using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace GameServer.Databases.Models.Mapping
{
    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("users");

            Id(x => x.Id).Column("id");
            Map(x => x.Username).Column("username");
        }
    }
}
