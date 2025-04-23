using Core.Interface;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Byte[] PasswordSalt { get; set; }
        public Byte[] PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Status { get; set; }

        // Coğrafi veri alanı
        public Point Location { get; set; }
    }
    
}
