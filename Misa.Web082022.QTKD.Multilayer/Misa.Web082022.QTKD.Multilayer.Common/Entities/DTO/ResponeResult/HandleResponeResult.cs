using Misa.Web082022.QTKD.Multilayer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Web082022.QTKD.Multilayer.Common.Entities.DTO
{
    public class HandleResponeResult
    {

        /// <summary>
        /// hàm  trả về xử lý dữ liệu trả về
        ///  CreatedBy PCTUANANH(30/09/2022)
        /// </summary>
        public ResponeResult ResponeResult(QTKDCode qTKDCode, int status, bool success, Object? errorList, Object data)
        {

            return new ResponeResult(
                qTKDCode,
                status,
                success,
                errorList,
                data
                );
        }



    }
}
