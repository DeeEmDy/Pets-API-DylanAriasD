using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Pet
{
    public class CreatePetRequestDto
    {
        public required string Name { get; set; }
        public required string Animal { get; set; }
        public required int UserId { get; set; }
    }
}