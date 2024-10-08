﻿using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly PersonaDbContext _context;

        public TelefonoRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Telefono>> GetAllAsync()
        {
            return await _context.Telefonos.ToListAsync();
        }

        public async Task<Telefono> GetByIdAsync(string numero)
        {
            return await _context.Telefonos.FindAsync(numero);
        }

        public async Task AddAsync(Telefono telefono)
        {
            await _context.Telefonos.AddAsync(telefono);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Telefono telefono)
        {
            _context.Telefonos.Update(telefono);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string numero)
        {
            var telefono = await _context.Telefonos.FindAsync(numero);
            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
                await _context.SaveChangesAsync();
            }
        }
    }
}
