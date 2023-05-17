using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMApp.Models
{
    public class ClientRepository
    {
        SQLiteConnection database;

        public ClientRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Client>();
        }

        public IEnumerable<Client> GetItems()
        {
            return database.Table<Client>().ToList();
        }

        public Client GetItem(int id)
        {
            return database.Get<Client>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<Client>(id);
        }

        public int SaveItem(Client item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
