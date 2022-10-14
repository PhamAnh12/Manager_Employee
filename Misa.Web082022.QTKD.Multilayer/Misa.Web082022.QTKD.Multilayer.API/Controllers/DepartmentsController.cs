using Microsoft.AspNetCore.Mvc;
using Misa.Web082022.QTKD.Multilayer.BL;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;
using Misa.Web082022.QTKD.Multilayer.Common.Enums;
using Misa.Web082022.QTKD.Multilayer.Common;
using Swashbuckle.AspNetCore.Annotations;

namespace Misa.Web082022.QTKD.Multilayer.API
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : BasicController<Department>
    {
        #region Field

        private IDepartmentBL _departmentBL;
        private ResponeErrorResult responeErrorResult;
        #endregion

        #region Controctor

        public DepartmentsController(IDepartmentBL departmentBL):base(departmentBL)
        {
            _departmentBL = departmentBL;
            responeErrorResult = new ResponeErrorResult();
        }

        #endregion


    }
}
