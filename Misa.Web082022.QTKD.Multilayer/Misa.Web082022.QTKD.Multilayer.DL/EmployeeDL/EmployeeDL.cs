using Dapper;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;
using Misa.Web082022.QTKD.Multilayer.Common;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Common;

namespace Misa.Web082022.QTKD.Multilayer.DL
{
    public class EmployeeDL : BaseDL<Employee>, IEmployeeDL
    {
       
        #region  Filter Employee DL

        /// <summary>
        ///  Lấy danh sách nhân viên cho phép lọc và phân trang
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
            // Chuẩn bị tên Stored procedure
            string storedProcedureName = Resource.Proc_Filter_Employee;

            // Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            parameters.Add("v_Offset", offset);
            parameters.Add("v_Limit", limit);
            parameters.Add("v_Sort", sort);
            string whereCondition = "";
            if (search != null)
            {
                whereCondition = $" EmployeeCode LIKE   \'%{search}%\' OR EmployeeName LIKE  \'%{search}%\'";
            }
            parameters.Add("v_Where", whereCondition);
            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
               
                // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                var multipleResults = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (multipleResults != null)
                {
                    var employees = multipleResults.Read<Employee>();
                    var totalCount = multipleResults.Read<long>().Single();
                    return (new PagingData<Employee>()
                    {
                        Data = employees.ToList(),
                        TotalCount = totalCount
                    });
                }
                else
                {
                    return null;
                }
            }

         
        }

        #endregion

        #region Get New EmployeeCode  DL

        /// <summary>
        ///  Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: PCTUANANH(29/09/2022)
        public string GetNewEmployeeCode()

        {
            // Chuẩn bị tên stored procedure
            string storedProcedureName = Resource.Proc_GetMaxEmpCode_Employee;

            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
               
                // Thực hiện gọi vào DB để chạy stored procedure ở trên
                string maxEmployeeCode = mySqlConnection.QueryFirstOrDefault<string>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
                return maxEmployeeCode;
            }

        }

        #endregion

        #region Deletelist Employee

        /// <summary>
        /// Hàm xóa nhiều nhân viên
        /// </summary>
        /// <returns>Số dòng thay đổi</returns>
        /// Created by: PCTUANANH(05/10/2022)
        public int DeleteListEmployee( List<Guid> listEmployeeID)
        {

                // Chuẩn bị tên stored procedure
                string storedProcedureName = "Proc_DeleteListID_Employee";
            var parameters = new DynamicParameters();
                parameters.Add("v_listID", string.Join(",",listEmployeeID));
              using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                    mySqlConnection.Open();
                    using(var mysqlTransaction = mySqlConnection.BeginTransaction())
                {
                    try {
                        var numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, mysqlTransaction, commandType: System.Data.CommandType.StoredProcedure);
                        mysqlTransaction.Commit();
                        mySqlConnection.Close();
                        return numberOfAffectedRows;
                    } 
                    catch
                    {
                        mysqlTransaction.Rollback();
                        mySqlConnection.Close();
                        return 0;
                    }
                }  
                   


                
                

               
              }
            
            
        }

        #endregion
    }
}
