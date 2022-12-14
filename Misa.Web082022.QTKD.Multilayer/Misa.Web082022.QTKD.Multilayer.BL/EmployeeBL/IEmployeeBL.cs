using Misa.Web082022.QTKD.Multilayer.Common;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;

namespace Misa.Web082022.QTKD.Multilayer.BL
{
    public interface IEmployeeBL : IBaseBL<Employee>
    {

        #region Filter Employees

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
        public PagingData<Employee> FilterEmployees(string? search, string? sort, int limit, int offset);

        #endregion

        #region Get New EmployeeCode

        /// <summary>
        /// api lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>mã nhân viên mới tự động tăng</returns>
        /// created by: pctuananh(29/09/2022)
        public string GetNewEmployeeCode();

        #endregion

        #region Deletelist Employee

        /// <summary>
        /// Hàm xóa nhiều nhân viên
        /// </summary>
        /// <returns>Số dòng thay đổi</returns>
        /// Created by: PCTUANANH(05/10/2022)
        public int DeleteListEmployee(List<Guid> listEmployeeID);

        #endregion

    }
}
