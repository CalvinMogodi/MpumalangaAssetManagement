using MAM.BusinessLayer.Models;
using MAM.BusinessLayer.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAM.API.Services
{
    public interface IUAMPService
    {
        bool AddProgrammes(List<Programme> programmes);
        bool AddFunctionalPerformances(List<FunctionalPerformance> functionalPerformances);
        bool AddUtilisations(List<Utilisation> utilisations);
        List<Programme> GetProgrammes();
        List<FunctionalPerformance> GetFunctionalPerformances();
        List<Utilisation> GetUtilisations();
    }

    public class UAMPService : IUAMPService
    {
        private readonly AppSettings _appSettings;

        public UAMPService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public bool AddFunctionalPerformances(List<FunctionalPerformance> functionalPerformances)
        {
            using (var _functionalPerformanceRepository = new FunctionalPerformanceRepository(_appSettings))
            {
                return _functionalPerformanceRepository.AddFunctionalPerformances(functionalPerformances);
            }
        }

        public bool AddProgrammes(List<Programme> programmes)
        {
            using (var _programmeRepository = new ProgrammeRepository(_appSettings))
            {
               return _programmeRepository.AddProgrammes(programmes);
            }
        }

        public List<FunctionalPerformance> GetFunctionalPerformances()
        {
            using (var _functionalPerformanceRepository = new FunctionalPerformanceRepository(_appSettings))
            {
                return _functionalPerformanceRepository.GetFunctionalPerformances();
            }
        }

        public List<Programme> GetProgrammes()
        {
            using (var _programmeRepository = new ProgrammeRepository(_appSettings))
            {
                return _programmeRepository.GetProgrammes();
            }
        }

        public bool AddUtilisations(List<Utilisation> utilisations)
        {
            using (var _utilisationRepository = new UtilisationRepository(_appSettings))
            {
                return _utilisationRepository.AddUtilisations(utilisations);
            }
        }

        public List<Utilisation> GetUtilisations()
        {
            using (var _utilisationRepository = new UtilisationRepository(_appSettings))
            {
                return _utilisationRepository.GetUtilisations();
            }
        }
    }
}
