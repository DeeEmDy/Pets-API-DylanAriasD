using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Pet
{
    public class UpdatePetRequestDto
    {
        public string Name { get; set; }
        public string Animal { get; set; }
        public int UserId { get; set; } //Para poder asignarle un usuario al que pertenece la mascota creada.
    }
}