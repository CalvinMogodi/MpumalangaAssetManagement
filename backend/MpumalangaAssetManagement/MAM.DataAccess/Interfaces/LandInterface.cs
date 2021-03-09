using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface LandInterface
    {
        int AddLand(Land land);
        void UpdateLand(Land land);
        List<Land> GetLands();
        Land GetLandById(int id);
    }
}
