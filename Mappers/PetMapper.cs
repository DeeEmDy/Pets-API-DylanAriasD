using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PetDtos;
using api.Dtos.UserDtos;
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
                User = pet.User != null ? new UserDto
                {
                    Id = pet.User.Id,
                    FirstName = pet.User.FirstName,
                    LastName = pet.User.LastName,
                    Age = pet.User.Age
                } : null
            };
        }

        public static Pet ToPetFromCreateDto(this CreatePetRequestDto createPetRequest)
        {
            return new Pet
            {
                Name = createPetRequest.Name,
                Animal = createPetRequest.Animal,
                UserId = createPetRequest.UserId,
            };
        }
    }
}