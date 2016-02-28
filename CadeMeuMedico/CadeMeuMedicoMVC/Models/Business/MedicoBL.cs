using AutoMapper;
using CadeMeuMedicoMVC.Models.WebAPI;
using CadeMeuMedicoMVC.Util;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadeMeuMedicoMVC.Models.Business
{
    public class MedicoBL
    {
        public static void InserirMedico(MedicoViewModel medicoViewModel)
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MedicoViewModel, Medico>();
                });
            var mapper = config.CreateMapper();
            var medico = mapper.Map<MedicoViewModel, Medico>(medicoViewModel);
            medico.Especialidade = new Especialidade { IDEspecialidade = medicoViewModel.IDEspecialidade };
            medico.Cidade = new Cidade { IDCidade = medicoViewModel.IDCidade };

            MedicoAPI.Post(medico, "api/medico");
           // MedicoDTO.InserirMedico(medico);
        }

        public static ICollection<Cidade> BuscaCidades()
        {
            return CidadeAPI.Get("api/cidade");//MedicoDTO.BuscaCidades();
        }

        public static ICollection<Especialidade> BuscaEspecialidades()
        {
            return EspecialidadeAPI.Get("api/especialidade");//MedicoDTO.BuscaEspecialidades();
        }

        public static ICollection<Medico> BuscaMedicos()
        {
            return MedicoAPI.Get("api/medico");//MedicoDTO.BuscaMedicos();
        }

        public static Medico BuscaMedicoPorId(int id)
        {
            return MedicoAPI.Get("api/medico", id).First<Medico>();//MedicoDTO.BuscaMedicoPorId(id);
        }

        public static MedicoViewModel BuscaMedicoViewModelPorId(int id)
        {
            var medico = MedicoAPI.Get("api/medico", id).First<Medico>();//MedicoDTO.BuscaMedicoPorId(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Medico,MedicoViewModel>();
            });
            var mapper = config.CreateMapper();
            var medicoViewModel = mapper.Map<Medico, MedicoViewModel>(medico);
            medicoViewModel.IDEspecialidade = medico.Especialidade.IDEspecialidade;
            medicoViewModel.IDCidade = medico.Cidade.IDCidade;

            return medicoViewModel;
        }

        public static void AtualizaMedico(MedicoViewModel medicoViewModel)
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MedicoViewModel, Medico>();
                });
            var mapper = config.CreateMapper();
            var medico = mapper.Map<MedicoViewModel, Medico>(medicoViewModel);
            medico.Especialidade = new Especialidade { IDEspecialidade = medicoViewModel.IDEspecialidade };
            medico.Cidade = new Cidade { IDCidade = medicoViewModel.IDCidade };

            MedicoAPI.Put(medico, "api/medico");

            //MedicoDTO.AtualizaMedico(medico);
        }

        public static void DeletaMedico(int id)
        {
            MedicoAPI.Delete(id, "api/medico");
            //MedicoDTO.DeletaMedico(id);
        }
    }
}