using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;

namespace api.Dtos.Pet
{
    public class PetDto
    {
        public int Id { get; set; } //Para que el id sea visible en el response si asi se desea.
        public string Name { get; set; }
        public string Animal { get; set; }

        public int? UserId { get; set; } //Campo opcional

        public UserDto? User { get; set; } //Para que el usuario sea visible en el response si asi se desea.
        //Campo opcional debido a que el usuario asignado a la mascota puede ser nulo.
    }
}