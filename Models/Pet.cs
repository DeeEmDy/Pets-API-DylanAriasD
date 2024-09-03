using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Animal { get; set; }
        public int? UserId { get; set; } //El ? es un atributo opcional es decir que puede ser nulo
        public User? User { get; set; } //Para que el usuario sea visible en el response si asi se desea.
    }
}