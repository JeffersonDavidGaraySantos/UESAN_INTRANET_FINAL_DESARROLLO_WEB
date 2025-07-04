﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Infrastructure.Data;

namespace UESAN_INTRANET.CORE.Infrastructure.Repositories
{
    public class AccesosRepository : IAccesosRepository
    {

        private readonly VdiIntranet2Context _context;
        public AccesosRepository(VdiIntranet2Context context)
        {
            _context = context;
        }

        //get all accesos
        public async Task<IEnumerable<Accesos>> GetAllAccesosAsync()
        {
            return await _context.Accesos.ToListAsync();
        }

        // Get access by id async
        public async Task<Accesos?> GetAccesoByIdAsync(int id)
        {
            return await _context.Accesos.FindAsync(id);
        }

        //create access async
        public async Task<Accesos> CreateAccesoAsync(Accesos acceso)
        {
            _context.Accesos.Add(acceso);
            await _context.SaveChangesAsync();
            return acceso;
        }

        //delete access async
        public async Task<bool> DeleteAccesoAsync(int id)
        {
            var acceso = await _context.Accesos.FindAsync(id);
            if (acceso == null)
            {
                return false;
            }
            _context.Accesos.Remove(acceso);
            await _context.SaveChangesAsync();
            return true;
        }
        //update access async
        public async Task<Accesos?> UpdateAccesoAsync(Accesos acceso)
        {
            var exists = await _context.Accesos.AnyAsync(a => a.AccesoId == acceso.AccesoId);
            if (!exists)
            {
                return null;
            }

            _context.Accesos.Update(acceso);
            await _context.SaveChangesAsync();
            return acceso;
        }


    }
}
