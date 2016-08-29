using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjectDobavljac
{
    interface IDataAccessProvider
    {
        void AddDobavljac(Model.Dobavljac dobavljac);
        void UpdateDobavljac(int dobavljacdId, Model.Dobavljac dobavljac);
        void DeleteDobavljac(int dobavljacdId);
        Model.Dobavljac GetDobavljac(int dobavljacdId);
        List<Model.Dobavljac> GetDobavljaci();
    }
}
