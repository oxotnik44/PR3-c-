using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using PR3._1Console.Module;

namespace PR3._1Console
{
    class Halper
    {
        private static LibraryEntities s_libraryBaseEntities;
        public static LibraryEntities GetContext()
        {
            if (s_libraryBaseEntities == null)
            {
                s_libraryBaseEntities = new LibraryEntities();
            }
            return s_libraryBaseEntities;
        }
        public bool SearchUsers(string login)
        {
            var users = s_libraryBaseEntities.Client.Where(x => x.Login == login).FirstOrDefault();
            using (MySqlConnection)
            if (users == null) return false;
            else return true;
        }
        public bool CreateUsers(Client client)
        {
            if (SearchUsers(client.Login))
            {
                return false;
            }
            else
            {
                s_libraryBaseEntities.Client.Add(client);
                s_libraryBaseEntities.SaveChanges();
                return true;
            }
        }

    }
}
