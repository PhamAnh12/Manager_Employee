
using Misa.Web082022.QTKD.Multilayer.Common.Entities;
using Misa.Web082022.QTKD.Multilayer.DL;
using System.Collections;

namespace Misa.Web082022.QTKD.Multilayer.BL
{
    public class DepartmentBL : BaseBL<Department>,IDepartmentBL
    {
        #region Feild

        private IDepartmentDL _departmentDL;

        #endregion

        #region Contractor

        public DepartmentBL(IDepartmentDL departmentDL) : base(departmentDL)
        {
            _departmentDL = departmentDL;
        }

        #endregion
    }
}
