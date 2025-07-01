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
    public class IssnConsultaService : IIssnConsultaService
    {
        private readonly IIssnConsultaRepository _repository;

        public IssnConsultaService(IIssnConsultaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IssnConsultaDTO>> GetAllAsync()
        {
            var consultas = await _repository.GetAllAsync();
            return consultas.Select(c => new IssnConsultaDTO
            {
                IssnConsultaId = c.IssnConsultaId,
                Issn = c.Issn,
                Nombre = c.Nombre,
                Scopus = c.Scopus,
                WoSQ = c.WoSQ,
                WoSS = c.WoSS,
                WoSEsci = c.WoSEsci,
                EsciQ = c.EsciQ,
                Ajg4 = c.Ajg4,
                Ajg = c.Ajg,
                AjgS = c.AjgS,
                Cnrs = c.Cnrs,
                CnrsS = c.CnrsS,
                Abdc = c.Abdc,
                AbdcS = c.AbdcS,
                AlMenosEnUnaLista = c.AlMenosEnUnaLista,
                SoloEnUnaLista = c.SoloEnUnaLista,
                Scielo = c.Scielo,
                WoSLatam = c.WoSLatam,
                Top50 = c.Top50,
                N = c.N,
                BeallsList = c.BeallsList,
                Mdpi = c.Mdpi,
                Insights = c.Insights,
                AjgExiste = c.AjgExiste,
                CnrsExiste = c.CnrsExiste,
                AbdcExiste = c.AbdcExiste,
                WoSTopExiste = c.WoSTopExiste,
                WoSEsciExiste = c.WoSEsciExiste,
                ScopusExiste = c.ScopusExiste,
                SoloScieloExiste = c.SoloScieloExiste,
                Especial216b = c.Especial216b,
                LatamSinEsciExiste = c.LatamSinEsciExiste,
                EsciScieloSinScopus = c.EsciScieloSinScopus,
                Multiple = c.Multiple,
                MultidisciplinaryWos = c.MultidisciplinaryWos,
                CoautoriaEsan = c.CoautoriaEsan,
                PosicionDelAutor = c.PosicionDelAutor,
                Jif = c.Jif,
                Country = c.Country,
                MultyYAlMenosUnaLista = c.MultyYAlMenosUnaLista,
                MultidisciplinaryScopus = c.MultidisciplinaryScopus,
                MultidisciplinaryWosOScopus = c.MultidisciplinaryWosOScopus
            });
        }

        public async Task<IssnConsultaDTO?> GetByIdAsync(int id)
        {
            var consulta = await _repository.GetByIdAsync(id);
            if (consulta == null)
            {
                return null;
            }

            return new IssnConsultaDTO
            {
                IssnConsultaId = consulta.IssnConsultaId,
                Issn = consulta.Issn,
                Nombre = consulta.Nombre,
                Scopus = consulta.Scopus,
                WoSQ = consulta.WoSQ,
                WoSS = consulta.WoSS,
                WoSEsci = consulta.WoSEsci,
                EsciQ = consulta.EsciQ,
                Ajg4 = consulta.Ajg4,
                Ajg = consulta.Ajg,
                AjgS = consulta.AjgS,
                Cnrs = consulta.Cnrs,
                CnrsS = consulta.CnrsS,
                Abdc = consulta.Abdc,
                AbdcS = consulta.AbdcS,
                AlMenosEnUnaLista = consulta.AlMenosEnUnaLista,
                SoloEnUnaLista = consulta.SoloEnUnaLista,
                Scielo = consulta.Scielo,
                WoSLatam = consulta.WoSLatam,
                Top50 = consulta.Top50,
                N = consulta.N,
                BeallsList = consulta.BeallsList,
                Mdpi = consulta.Mdpi,
                Insights = consulta.Insights,
                AjgExiste = consulta.AjgExiste,
                CnrsExiste = consulta.CnrsExiste,
                AbdcExiste = consulta.AbdcExiste,
                WoSTopExiste = consulta.WoSTopExiste,
                WoSEsciExiste = consulta.WoSEsciExiste,
                ScopusExiste = consulta.ScopusExiste,
                SoloScieloExiste = consulta.SoloScieloExiste,
                Especial216b = consulta.Especial216b,
                LatamSinEsciExiste = consulta.LatamSinEsciExiste,
                EsciScieloSinScopus = consulta.EsciScieloSinScopus,
                Multiple = consulta.Multiple,
                MultidisciplinaryWos = consulta.MultidisciplinaryWos,
                CoautoriaEsan = consulta.CoautoriaEsan,
                PosicionDelAutor = consulta.PosicionDelAutor,
                Jif = consulta.Jif,
                Country = consulta.Country,
                MultyYAlMenosUnaLista = consulta.MultyYAlMenosUnaLista,
                MultidisciplinaryScopus = consulta.MultidisciplinaryScopus,
                MultidisciplinaryWosOScopus = consulta.MultidisciplinaryWosOScopus
            };
        }

        public async Task<IssnConsultaDTO> CreateAsync(IssnConsultaDTO dto)
        {
            var entity = new IssnConsulta
            {
                Issn = dto.Issn,
                Nombre = dto.Nombre,
                Scopus = dto.Scopus,
                WoSQ = dto.WoSQ,
                WoSS = dto.WoSS,
                WoSEsci = dto.WoSEsci,
                EsciQ = dto.EsciQ,
                Ajg4 = dto.Ajg4,
                Ajg = dto.Ajg,
                AjgS = dto.AjgS,
                Cnrs = dto.Cnrs,
                CnrsS = dto.CnrsS,
                Abdc = dto.Abdc,
                AbdcS = dto.AbdcS,
                AlMenosEnUnaLista = dto.AlMenosEnUnaLista,
                SoloEnUnaLista = dto.SoloEnUnaLista,
                Scielo = dto.Scielo,
                WoSLatam = dto.WoSLatam,
                Top50 = dto.Top50,
                N = dto.N,
                BeallsList = dto.BeallsList,
                Mdpi = dto.Mdpi,
                Insights = dto.Insights,
                AjgExiste = dto.AjgExiste,
                CnrsExiste = dto.CnrsExiste,
                AbdcExiste = dto.AbdcExiste,
                WoSTopExiste = dto.WoSTopExiste,
                WoSEsciExiste = dto.WoSEsciExiste,
                ScopusExiste = dto.ScopusExiste,
                SoloScieloExiste = dto.SoloScieloExiste,
                Especial216b = dto.Especial216b,
                LatamSinEsciExiste = dto.LatamSinEsciExiste,
                EsciScieloSinScopus = dto.EsciScieloSinScopus,
                Multiple = dto.Multiple,
                MultidisciplinaryWos = dto.MultidisciplinaryWos,
                CoautoriaEsan = dto.CoautoriaEsan,
                PosicionDelAutor = dto.PosicionDelAutor,
                Jif = dto.Jif,
                Country = dto.Country,
                MultyYAlMenosUnaLista = dto.MultyYAlMenosUnaLista,
                MultidisciplinaryScopus = dto.MultidisciplinaryScopus,
                MultidisciplinaryWosOScopus = dto.MultidisciplinaryWosOScopus
            };

            var created = await _repository.CreateAsync(entity);

            return await GetByIdAsync(created.IssnConsultaId) ?? new IssnConsultaDTO();
        }

        public async Task<IssnConsultaDTO?> UpdateAsync(IssnConsultaDTO dto)
        {
            var entity = new IssnConsulta
            {
                IssnConsultaId = dto.IssnConsultaId,
                Issn = dto.Issn,
                Nombre = dto.Nombre,
                Scopus = dto.Scopus,
                WoSQ = dto.WoSQ,
                WoSS = dto.WoSS,
                WoSEsci = dto.WoSEsci,
                EsciQ = dto.EsciQ,
                Ajg4 = dto.Ajg4,
                Ajg = dto.Ajg,
                AjgS = dto.AjgS,
                Cnrs = dto.Cnrs,
                CnrsS = dto.CnrsS,
                Abdc = dto.Abdc,
                AbdcS = dto.AbdcS,
                AlMenosEnUnaLista = dto.AlMenosEnUnaLista,
                SoloEnUnaLista = dto.SoloEnUnaLista,
                Scielo = dto.Scielo,
                WoSLatam = dto.WoSLatam,
                Top50 = dto.Top50,
                N = dto.N,
                BeallsList = dto.BeallsList,
                Mdpi = dto.Mdpi,
                Insights = dto.Insights,
                AjgExiste = dto.AjgExiste,
                CnrsExiste = dto.CnrsExiste,
                AbdcExiste = dto.AbdcExiste,
                WoSTopExiste = dto.WoSTopExiste,
                WoSEsciExiste = dto.WoSEsciExiste,
                ScopusExiste = dto.ScopusExiste,
                SoloScieloExiste = dto.SoloScieloExiste,
                Especial216b = dto.Especial216b,
                LatamSinEsciExiste = dto.LatamSinEsciExiste,
                EsciScieloSinScopus = dto.EsciScieloSinScopus,
                Multiple = dto.Multiple,
                MultidisciplinaryWos = dto.MultidisciplinaryWos,
                CoautoriaEsan = dto.CoautoriaEsan,
                PosicionDelAutor = dto.PosicionDelAutor,
                Jif = dto.Jif,
                Country = dto.Country,
                MultyYAlMenosUnaLista = dto.MultyYAlMenosUnaLista,
                MultidisciplinaryScopus = dto.MultidisciplinaryScopus,
                MultidisciplinaryWosOScopus = dto.MultidisciplinaryWosOScopus
            };

            var updated = await _repository.UpdateAsync(entity);
            if (updated == null)
            {
                return null;
            }

            return await GetByIdAsync(updated.IssnConsultaId);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
