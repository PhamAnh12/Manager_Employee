using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Web082022.QTKD.Multilayer.DL
{
    public interface IBaseDL<T>
    {
        #region IBase Get All DL

        /// <summary>
        /// API Lấy toàn bộ danh bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: PCTUANANH(30/09/2022)
        public IEnumerable<T> GetAllRecords();

        #endregion

        #region IBase Get By ID  DL

        /// <summary>
        ///  Lấy thông tin chi tiết của bản ghi
        /// </summary>
        /// <param name="ID">ID của bản ghi muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng bản ghi muốn lấy thông tin chi tiết</returns>
        /// Created by: PCTUANANH(30/09/2022)
        public T RecordByID(Guid ID);

        #endregion

        #region IBase Insert DL

        /// <summary>
        /// Thêm mới một bản ghi 
        /// <param name="record">Đối tượng bản ghi mới</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        public Guid InsertRecord(T record);

        #endregion

        #region IBase Update Dl

        /// <summary>
        /// Sửa một bản ghi 
        /// <param name="record">Đối tượng bản ghi cần sửa</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        public Guid UpdateRecord(Guid ID, T record);

        #endregion

        #region IBase Delete DL

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
