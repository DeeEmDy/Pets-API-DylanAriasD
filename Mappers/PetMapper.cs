using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Pet;
using api.Models;


namespace api.Mappers
{
    public static class PetMapper
    {
        public static PetDto ToDto(this Pet pet)
        {
            return new PetDto
            {
                Id = pet.Id,
                Name = pet.Name,
                Animal = pet.Animal,
                UserId = pet.UserId,
                User = pet.User?.ToDto() //Para que el usuario sea visible en el response si asi se desea.
            };
        }

        public static Pet ToPetFromCreateDto(this CreatePetRequestDto petDto)
        {
            return new Pet
            {
                Name = petDto.Name,
                Animal = petDto.Animal,
                UserId = petDto.UserId
            };
        }
    }
}