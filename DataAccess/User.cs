using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int iduser { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string name { get; set; }
        public string email { get; set; }

        public string address { get; set; }
        public string phone { get; set; }

        
    }
}
