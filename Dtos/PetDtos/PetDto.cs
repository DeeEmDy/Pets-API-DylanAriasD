using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.PetDtos
{
    public class PetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Animal { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }
    }
}