using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User user){
            return new UserDto {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                PetList = user.Pets.Select(PetMapper.ToDto).ToList()
            };
        }

        public static User ToUserFromCreateDto(this CreateUserRequestDto createUserRequest){ //Convertir un dto a un modelo.
            return new User{
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,
                Age = createUserRequest.Age
            };
        }

        //Para crear un usuario con mascotas
        public static User ToUserFromCreateWithPetsDto(this CreateUserWithPetsRequestDto createUserWithPetsRequest){
            return new User{
                FirstName = createUserWithPetsRequest.FirstName,
                LastName = createUserWithPetsRequest.LastName,
                Age = createUserWithPetsRequest.Age,
                Pets = createUserWithPetsRequest.Pets.Select(PetMapper.ToPetFromCreateDto).ToList()
            };
        }
    }
}