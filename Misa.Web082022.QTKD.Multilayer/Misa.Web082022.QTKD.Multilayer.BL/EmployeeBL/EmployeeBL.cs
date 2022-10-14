using Misa.Web082022.QTKD.Multilayer.Common;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;
using Misa.Web082022.QTKD.Multilayer.DL;

namespace Misa.Web082022.QTKD.Multilayer.BL
{
    public class EmployeeBL : BaseBL<Employee>,IEmployeeBL
    {
        #region Field

        private IEmployeeDL _employeeDL;

        #endregion

        #region Controctor

        public EmployeeBL(IEmployeeDL employeeDL):base(employeeDL)
        {
            _employeeDL = employeeDL;
        }

        #endregion

        #region Method

        #region  Filter Employees

        /// <summary>
        /// API Lấy danh sách nhân viên cho phép lọc và phân trang
        /// </summary>
        /// <param name="search">Tìm kiếm theo Số điện thoại, tên, Mã nhân viên</param>
        /// <param name="sort">  Sắp xếp</param>
        /// <param name="limit">Số trang muốn lấy</param>
        /// <param name="offset">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: PCTUANANH(29/09/2022)
        public PagingData<Employee> FilterEmployees(string? search, string? sort, int limit, int offset)
        {
             return _employeeDL.FilterEmployees(search, sort, limit, offset);
            
        }

        #endregion

        #region Get NewEmployeeCode

        /// <summary>
        /// API Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: PCTUANANH(29/09/2022)
        public string GetNewEmployeeCode()
        {
            string maxEmployeeCode = _employeeDL.GetNewEmployeeCode();
            string newEmployeeCode = "";
            if (maxEmployeeCode.Substring(0, 4) == "NV00")
            {
                newEmployeeCode = "NV00" + (Int64.Parse(maxEmployeeCode.Substring(4)) + 1).ToString();

            }
            else if (maxEmployeeCode.Substring(0, 3) == "NV0")
            {
                if (Int64.Parse(maxEmployeeCode.Substring(3)) == 999)
                {
                    newEmployeeCode = "NV1000";
                }
                else
                {
                    newEmployeeCode = "NV0" + (Int64.Parse(maxEmployeeCode.Substring(3)) + 1).ToString();
                }

            }
            else if (maxEmployeeCode.Substring(0, 2) == "NV")
            {
                newEmployeeCode = "NV" + (Int64.Parse(maxEmployeeCode.Substring(2)) + 1).ToString();

            }
            return newEmployeeCode;

        }

        #endregion

        #region Deletelist Employee

        /// <summary>
        /// Hàm xóa nhiều nhân viên
        /// </summary>
        /// <returns>Số dòng thay đổi</returns>
        /// Created by: PCTUANANH(05/10/2022)
        public int DeleteListEmployee(List<Guid> listEmployeeID)
        {
            return _employeeDL.DeleteListEmployee(listEmployeeID);
        }

        #endregion

        #endregion

    }
}
