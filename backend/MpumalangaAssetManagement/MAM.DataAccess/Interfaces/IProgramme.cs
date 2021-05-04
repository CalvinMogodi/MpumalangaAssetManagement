using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IProgramme
    {
        void AddProgrammes(List<Programme> programmes);
        List<Programme> GetProgrammes();
    }
}
