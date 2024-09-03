using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Mappers;
using api.Dtos.Pet;

namespace api.Controllers
{

    [Route("api/pet")]
    [ApiController]

    public class PetController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PetController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet] //Método para obtener todos los pets.
        public async Task<IActionResult> GetAllPets()
        {
            /*NOTA: El Include es para acceder a la información del usuario de la mascota por la relación entre ellos
            en la misma consulta sin necesidad de hacer llamadas adicionales a la base de datos.*/
            var pets = await _context.Pets.Include(pet => pet.User).ToListAsync(); //Obtener todos los pets de la base de datos.
            var petsDto = pets.Select(pet => pet.ToDto()); //Convertir los pets a DTO.
            return Ok(petsDto); //Devolver un 200 Ok y la información de los pets.
        }

        [HttpGet("{id}")] //Método para obtener un pet en específico.
        public async Task<IActionResult> getPetById([FromRoute] int id)
        {
            var pet = await _context.Pets.Include(pet => pet.User).FirstOrDefaultAsync(pet => pet.Id == id); //Obtener el pet de la base de datos.
            if (pet == null) //Si el pet no existe, devolver un error 404.
            {
                return NotFound(); //Devolver un error 404.
            }
            return Ok(pet.ToDto()); //Devolver un 200 Ok y la información del pet.
        }

        [HttpPost] //Método para crear un nuevo pet.
        public async Task<IActionResult> CreatePet([FromBody] CreatePetRequestDto petDto)
        {
            var petModel = petDto.ToPetFromCreateDto(); //Le asignamos al modelo del Pet, lo que contiene el pet de dto. Ya que lo que se envia a la base de datos es el modelo Pet.
            await _context.Pets.AddAsync(petModel); //Agregar el pet a la base de datos.
            await _context.SaveChangesAsync(); //Guardar los cambios realizados en la base de datos.
            return CreatedAtAction(nameof(getPetById), new { id = petModel.Id }, petModel.ToDto()); //Devolver un 201 Created y la información del pet creado pero se devuelve el DTO.
        }

        [HttpPut("{id}")] //Método para editar un registro de pet.
        public async Task<IActionResult> UpdatePet([FromRoute] int id, [FromBody] UpdatePetRequestDto petDto)
        {
            var petModel = await _context.Pets.FirstOrDefaultAsync(pet => pet.Id == id); //Obtener el pet de la base de datos.
            if (petModel == null) //Si el pet no existe, devolver un error 404.
            {
                return NotFound(); //Devolver un error 404.
            }
            //Si el pet fue encontrado, se actualizan los datos del pet de los que vienen del DTO.
            petModel.Name = petDto.Name;
            petModel.Animal = petDto.Animal;
            petModel.UserId = petDto.UserId;
            await _context.SaveChangesAsync(); //Guardar los cambios realizados en la base de datos.
            return NoContent(); //Devolver un 204 No Content.
        }

        [HttpDelete("{id}")] //Método para eliminar un registro de pet mediante su ID.
        public async Task<IActionResult> DeletePet([FromRoute] int id)
        {
            var petModel = await _context.Pets.FirstOrDefaultAsync(pet => pet.Id == id); //Obtener el pet de la base de datos.
            if (petModel == null) //Si el pet no existe, devolver un error 404.
            {
                return NotFound(); //Devolver un error 404.
            }
            _context.Pets.Remove(petModel); //Eliminar el pet de la base de datos.
            await _context.SaveChangesAsync(); //Guardar los cambios realizados en la base de datos.
            return NoContent(); //Devolver un 204 No Content.
        }
    }
}