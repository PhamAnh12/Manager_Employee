using Misa.Web082022.QTKD.Multilayer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Web082022.QTKD.Multilayer.Common.Entities.DTO
{
    public class ResponeResult
    {
        public ResponeResult(QTKDCode qTKDCode, int? status, bool? success, object? errorList, object? data)
        {
            QTKDCode = qTKDCode;
            Status = status;
            Success = success;
            ErrorList = errorList;
            Data = data;
        }



        /// <summary>
        /// Các mã lỗi 
        /// </summary>
        public QTKDCode QTKDCode { get; set; }

        /// <summary>
        /// Mã  controller trả về
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Trạng thái thành công hay không
        /// </summary>
        public bool? Success { get; set; }

        /// <summary>
        /// Danh sách lỗi
        /// </summary>
        public Object? ErrorList { get; set; }

        /// <summary>
        /// Data trả về
        /// </summary>
        public Object? Data { get; set; }

     


    }
}
