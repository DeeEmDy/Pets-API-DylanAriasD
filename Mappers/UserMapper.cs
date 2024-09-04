using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.UserDtos;
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
    }
}