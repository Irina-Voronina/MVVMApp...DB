using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMApp.Models
{
    [Table("Clients")]
    public class Client
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        public string Transaction { get; set; }
        public string Adress { get; set; }
        public string Price { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
