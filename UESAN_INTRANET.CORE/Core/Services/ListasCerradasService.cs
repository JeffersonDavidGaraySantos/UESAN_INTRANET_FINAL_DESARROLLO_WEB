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
    public class ListasCerradasService
    {
        private readonly IListasCerradasRepository _repository;

        public ListasCerradasService(IListasCerradasRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ListasCerradasDTO>> GetAllAsync()
        {
            var listas = await _repository.GetAllAsync();
            return listas.Select(l => new ListasCerradasDTO
            {
                ListasCerradasId = l.ListasCerradasId,
                Issn = l.Issn,
                Issn2 = l.Issn2,
                Issn3 = l.Issn3,
                Nombre = l.Nombre,
                CategoriaId = l.CategoriaId,
                Puntaje = l.Puntaje,
                IncentivoUsd = l.IncentivoUsd,
                Scopus = l.Scopus,
                WoSQ = l.WoSQ,
                EsciQ = l.EsciQ,
                Ajg = l.Ajg,
                Cnrs = l.Cnrs,
                Abdc = l.Abdc,
                WoSLatam = l.WoSLatam
            });
        }

        public async Task<ListasCerradasDTO?> GetByIdAsync(int id)
        {
            var lista = await _repository.GetByIdAsync(id);
            if (lista == null)
            {
                return null;
            }

            return new ListasCerradasDTO
            {
                ListasCerradasId = lista.ListasCerradasId,
                Issn = lista.Issn,
                Issn2 = lista.Issn2,
                Issn3 = lista.Issn3,
                Nombre = lista.Nombre,
                CategoriaId = lista.CategoriaId,
                Puntaje = lista.Puntaje,
                IncentivoUsd = lista.IncentivoUsd,
                Scopus = lista.Scopus,
                WoSQ = lista.WoSQ,
                EsciQ = lista.EsciQ,
                Ajg = lista.Ajg,
                Cnrs = lista.Cnrs,
                Abdc = lista.Abdc,
                WoSLatam = lista.WoSLatam
            };
        }

        public async Task<ListasCerradasDTO> CreateAsync(ListasCerradasDTO dto)
        {
            var entity = new ListasCerradas
            {
                Issn = dto.Issn,
                Issn2 = dto.Issn2,
                Issn3 = dto.Issn3,
                Nombre = dto.Nombre,
                CategoriaId = dto.CategoriaId,
                Puntaje = dto.Puntaje,
                IncentivoUsd = dto.IncentivoUsd,
                Scopus = dto.Scopus,
                WoSQ = dto.WoSQ,
                EsciQ = dto.EsciQ,
                Ajg = dto.Ajg,
                Cnrs = dto.Cnrs,
                Abdc = dto.Abdc,
                WoSLatam = dto.WoSLatam
            };

            var created = await _repository.CreateAsync(entity);

            return new ListasCerradasDTO
            {
                ListasCerradasId = created.ListasCerradasId,
                Issn = created.Issn,
                Issn2 = created.Issn2,
                Issn3 = created.Issn3,
                Nombre = created.Nombre,
                CategoriaId = created.CategoriaId,
                Puntaje = created.Puntaje,
                IncentivoUsd = created.IncentivoUsd,
                Scopus = created.Scopus,
                WoSQ = created.WoSQ,
                EsciQ = created.EsciQ,
                Ajg = created.Ajg,
                Cnrs = created.Cnrs,
                Abdc = created.Abdc,
                WoSLatam = created.WoSLatam
            };
        }

        public async Task<ListasCerradasDTO?> UpdateAsync(ListasCerradasDTO dto)
        {
            var entity = new ListasCerradas
            {
                ListasCerradasId = dto.ListasCerradasId,
                Issn = dto.Issn,
                Issn2 = dto.Issn2,
                Issn3 = dto.Issn3,
                Nombre = dto.Nombre,
                CategoriaId = dto.CategoriaId,
                Puntaje = dto.Puntaje,
                IncentivoUsd = dto.IncentivoUsd,
                Scopus = dto.Scopus,
                WoSQ = dto.WoSQ,
                EsciQ = dto.EsciQ,
                Ajg = dto.Ajg,
                Cnrs = dto.Cnrs,
                Abdc = dto.Abdc,
                WoSLatam = dto.WoSLatam
            };

            var updated = await _repository.UpdateAsync(entity);
            if (updated == null)
            {
                return null;
            }

            return new ListasCerradasDTO
            {
                ListasCerradasId = updated.ListasCerradasId,
                Issn = updated.Issn,
                Issn2 = updated.Issn2,
                Issn3 = updated.Issn3,
                Nombre = updated.Nombre,
                CategoriaId = updated.CategoriaId,
                Puntaje = updated.Puntaje,
                IncentivoUsd = updated.IncentivoUsd,
                Scopus = updated.Scopus,
                WoSQ = updated.WoSQ,
                EsciQ = updated.EsciQ,
                Ajg = updated.Ajg,
                Cnrs = updated.Cnrs,
                Abdc = updated.Abdc,
                WoSLatam = updated.WoSLatam
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
