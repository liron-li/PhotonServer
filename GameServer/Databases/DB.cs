using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace GameServer.Databases
{
    class DB
    {
        private static string host = "127.0.0.1";
        private static string database = "nhibernate";
        private static string user = "root";
        private static string password = "";
        private static string charSet = "utf8";

        private static ISessionFactory sessionFactory = null;

        private static void InitSessionFactory()
        {

            MySQLConfiguration config = MySQLConfiguration.Standard.ConnectionString(c => c.Is(String.Format("Server={0};Database={1};User={2};Password={3};CharSet={4}", host, database, user, password, charSet)));

            sessionFactory = Fluently.Configure().Database(config).Mappings(x => x.FluentMappings.AddFromAssemblyOf<DB>()).BuildSessionFactory();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    InitSessionFactory();
                }
                return sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
