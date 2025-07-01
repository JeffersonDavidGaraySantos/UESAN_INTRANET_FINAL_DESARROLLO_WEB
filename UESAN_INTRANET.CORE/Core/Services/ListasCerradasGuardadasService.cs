using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.DTOs;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;

namespace UESAN_INTRANET.CORE.Core.Services
{
    public class ListasCerradasGuardadasService
    {
        private readonly IListasCerradasGuardadasRepository _repository;

        public ListasCerradasGuardadasService(IListasCerradasGuardadasRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ListasCerradasGuardadasDTO>> GetAllAsync()
        {
            var listas = await _repository.GetAllAsync();
            return listas.Select(l => new ListasCerradasGuardadasDTO
            {
                ListasCerradasGuardadasId = l.ListasCerradasGuardadasId,
                UsuarioId = l.UsuarioId,
                ListasCerradasId = l.ListasCerradasId,
                FechaGuardado = l.FechaGuardado
            });
        }

        public async Task<ListasCerradasGuardadasDTO?> GetByIdAsync(int id)
        {
            var lista = await _repository.GetByIdAsync(id);
            if (lista == null)
            {
                return null;
            }

            return new ListasCerradasGuardadasDTO
            {
                ListasCerradasGuardadasId = lista.ListasCerradasGuardadasId,
                UsuarioId = lista.UsuarioId,
                ListasCerradasId = lista.ListasCerradasId,
                FechaGuardado = lista.FechaGuardado
            };
        }

        public async Task<ListasCerradasGuardadasDTO> CreateAsync(ListasCerradasGuardadasDTO dto)
        {
            var entity = new ListasCerradasGuardadas
            {
                UsuarioId = dto.UsuarioId,
                ListasCerradasId = dto.ListasCerradasId,
                FechaGuardado = dto.FechaGuardado
            };

            var created = await _repository.CreateAsync(entity);

            return new ListasCerradasGuardadasDTO
            {
                ListasCerradasGuardadasId = created.ListasCerradasGuardadasId,
                UsuarioId = created.UsuarioId,
                ListasCerradasId = created.ListasCerradasId,
                FechaGuardado = created.FechaGuardado
            };
        }

        public async Task<ListasCerradasGuardadasDTO?> UpdateAsync(ListasCerradasGuardadasDTO dto)
        {
            var entity = new ListasCerradasGuardadas
            {
                ListasCerradasGuardadasId = dto.ListasCerradasGuardadasId,
                UsuarioId = dto.UsuarioId,
                ListasCerradasId = dto.ListasCerradasId,
                FechaGuardado = dto.FechaGuardado
            };

            var updated = await _repository.UpdateAsync(entity);
            if (updated == null)
            {
                return null;
            }

            return new ListasCerradasGuardadasDTO
            {
                ListasCerradasGuardadasId = updated.ListasCerradasGuardadasId,
                UsuarioId = updated.UsuarioId,
                ListasCerradasId = updated.ListasCerradasId,
                FechaGuardado = updated.FechaGuardado
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
