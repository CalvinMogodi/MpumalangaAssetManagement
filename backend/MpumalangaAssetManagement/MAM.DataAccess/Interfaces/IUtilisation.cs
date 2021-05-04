using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IUtilisation
    {
        bool AddUtilisations(List<Utilisation> programmes);
        List<Utilisation> GetUtilisations();
    }
}
