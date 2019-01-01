using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Databases.Models;

namespace GameServer.Databases.Repositories
{
    class UserRepository : RepositoryBase
    {
        public IList<User> All()
        {
            using (var session = DB.OpenSession())
            {
                var res = session.QueryOver<User>();
                return res.List();
            }
        }

        public IList<User> GetUserByUsername(string username)
        {
            using (var session = DB.OpenSession())
            {
                var res = session.QueryOver<User>().Where(user => user.Username == username);
                return res.List();
            }
        }

        public void Save(User user)
        {
            using (var session = DB.OpenSession())
            {
                session.Save(user);
            }
        }

        public void Update(User user)
        {
            using (var session = DB.OpenSession())
            {
                session.Update(user);
            }
        }

        public void Delete(User user)
        {
            using (var session = DB.OpenSession())
            {
                session.Delete(user);
            }
        }
    }
}
