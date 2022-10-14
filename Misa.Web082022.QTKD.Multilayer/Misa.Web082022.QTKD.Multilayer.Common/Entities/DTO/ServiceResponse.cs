using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Web082022.QTKD.Multilayer.Common.Entities
{    /// <summary>
     /// Dữ liệu trả về từ taangd BL
     /// </summary>
    public class ServiceResponse
    {
        /// <summary>
        /// Đã Validate chưa
        /// </summary>
        public bool IsValidate { get; set; }

        /// <summary>
        /// Thành công hay Thất bại
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Dữ liệu đi kèm 
        /// </summary>
        public Object? Data { get; set; }
        
    }
}
