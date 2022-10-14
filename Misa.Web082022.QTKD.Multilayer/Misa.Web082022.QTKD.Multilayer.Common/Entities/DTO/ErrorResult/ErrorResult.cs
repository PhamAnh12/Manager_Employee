using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Misa.Web082022.QTKD.Multilayer.Common.Enums;

namespace Misa.Web082022.QTKD.Multilayer.Common.Entities
{
    public class ErrorResult
    {
        public ErrorResult(QTKDCode errorCode, string devMsg, string userMsg, string moreInfo, string traceId)
        {
            ErrorCode = errorCode;
            DevMsg = devMsg;
            UserMsg = userMsg;
            MoreInfo = moreInfo;
            TraceId = traceId;
        }
        /// <summary>
        /// Các mã lỗi 
        /// </summary>
        public QTKDCode ErrorCode { get; set; }

        /// <summary>
        /// Lỗi thông báo  cho Dev
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Lỗi thông báo cho  người dùng
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Thông tin chi tiết hơn về vấn đề.
        /// </summary>
        public string? MoreInfo { get; set; }

        /// <summary>
        /// Mã để tra cứu thông tin log
        /// </summary>
        public string? TraceId { get; set; }



    }
}
