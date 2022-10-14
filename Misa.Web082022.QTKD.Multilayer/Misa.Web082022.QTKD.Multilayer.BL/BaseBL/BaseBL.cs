using Misa.Web082022.QTKD.Multilayer.Common;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;
using Misa.Web082022.QTKD.Multilayer.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Web082022.QTKD.Multilayer.BL
{
    public class BaseBL<T> : IBaseBL <T>
    {
        #region Field

        private IBaseDL<T> _recordDL;

        #endregion

        #region Controctor

        public BaseBL(IBaseDL <T> recordDL)
        {
            _recordDL = recordDL;
        }

        #endregion

        #region Method

        /// <summary>
        /// API Lấy toàn bộ danh bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: PCTUANANH(30/09/2022)
        public IEnumerable<T> GetAllRecords()
        {
            return _recordDL.GetAllRecords();
        }

        /// <summary>
        ///  Lấy thông tin chi tiết của bản ghi
        /// </summary>
        /// <param name="ID">ID của bản ghi muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng bản ghi muốn lấy thông tin chi tiết</returns>
        /// Created by: PCTUANANH(30/09/2022)
        public T RecordByID(Guid ID)
        {
            return _recordDL.RecordByID(ID);
        }

        /// <summary>
        /// Thêm mới một bản ghi 
        /// <param name="record">Đối tượng bản ghi mới</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        public ServiceResponse InsertRecord(T record)
        {
            // validate dữ liệu đầu vào
            List<string> validateErrors = Validation<T>.Validate(record);
            if (validateErrors.Count > 0)
            {

                return new ServiceResponse
                {
                    IsValidate = false,
                    Success = false,
                    Data = validateErrors
                };
            }
            else
            {
               var id = _recordDL.InsertRecord(record);
                if (id != null)
                {
                    return new ServiceResponse
                    {
                        IsValidate = true,
                        Success = true,
                        Data = id
                    };
                }
                else
                {
                    return new ServiceResponse
                    {
                        IsValidate = true,
                        Success = false,
                        Data = "",
                    };
                }

            }

        }

        /// <summary>
        /// Sửa một bản ghi 
        /// <param name="record">Đối tượng bản ghi cần sửa</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        public ServiceResponse UpdateRecord(Guid ID,T record)
        {
            // validate dữ liệu đầu vào
            List<string> validateErrors = Validation<T>.Validate(record);
            if (validateErrors.Count > 0)
            {
               
                return new ServiceResponse
                {
                    IsValidate = false, 
                    Success = false,
                    Data = validateErrors
                };
            }
            else
            {
                var id = _recordDL.UpdateRecord(ID,record);
                if (id != null)
                {
                    return new ServiceResponse
                    {
                        IsValidate = true,
                        Success = true,
                        Data = id
                    };
                }
                else
                {
                    return new ServiceResponse
                    {
                        IsValidate = true,
                        Success = false,
                        Data = "",
                    };
                }

            }
        }


        /// <summary>
        /// Xóa một bản ghi 
        /// <param name="ID">mã bản ghi cần xóa</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        public Guid DeleteRecord(Guid ID)
        {
            return _recordDL.DeleteRecord(ID);
        } 

        #endregion
    }
}
