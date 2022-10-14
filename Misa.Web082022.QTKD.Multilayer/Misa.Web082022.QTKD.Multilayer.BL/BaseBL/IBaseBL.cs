using Misa.Web082022.QTKD.Multilayer.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Web082022.QTKD.Multilayer.BL
{
   public interface IBaseBL <T>
    {
        #region IBase GetAll BL

        /// <summary>
        /// API Lấy toàn bộ danh bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: PCTUANANH(30/09/2022)
        public IEnumerable<T> GetAllRecords();

        #endregion

        #region IBase Get By ID BL
        /// <summary>
        ///  Lấy thông tin chi tiết của bản ghi
        /// </summary>
        /// <param name="ID">ID của bản ghi muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng bản ghi muốn lấy thông tin chi tiết</returns>
        /// Created by: PCTUANANH(30/09/2022)
        public T RecordByID(Guid ID);

        #endregion

        #region IBase Insert BL

        /// <summary>
        /// Thêm mới một bản ghi 
        /// <param name="record">Đối tượng bản ghi mới</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        public ServiceResponse InsertRecord(T record);

        #endregion

        #region IBase Update BL 

        /// <summary>
        /// Sửa một bản ghi 
        /// <param name="record">Đối tượng bản ghi cần sửa</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        public ServiceResponse UpdateRecord(Guid ID, T record);

        #endregion

        #region IBase Delete BL

        /// <summary>
        /// Xóa một bản ghi 
        /// <param name="ID">mã bản ghi cần xóa</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        public Guid DeleteRecord(Guid ID);

        #endregion


    }
}
