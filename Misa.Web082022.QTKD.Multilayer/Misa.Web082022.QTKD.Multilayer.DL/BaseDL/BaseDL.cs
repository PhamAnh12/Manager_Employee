using Dapper;
using Misa.Web082022.QTKD.Multilayer.Common;
using MySqlConnector;
using Misa.Web082022.QTKD.Multilayer.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Web082022.QTKD.Multilayer.DL
{
    public class BaseDL<T> : IBaseDL <T>
    {

        #region Base Get All DL

        /// <summary>
        /// API Lấy toàn bộ danh bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: PCTUANANH(30/09/2022)
        public IEnumerable<T> GetAllRecords()
        {
            string storedProcedureName = String.Format(Resource.Proc_GetAll, typeof(T).Name);
            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                // Thực hiện gọi vào DB để chạy câu lệnh truy vấn ở trên
                var listRecords = mySqlConnection.Query<T>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
                return listRecords;
            }

        }

        #endregion

        #region Base Get By ID DL

        /// <summary>
        ///  Lấy thông tin chi tiết của bản ghi
        /// </summary>
        /// <param name="ID">ID của bản ghi muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng bản ghi muốn lấy thông tin chi tiết</returns>
        /// Created by: PCTUANANH(30/09/2022)
        public T RecordByID(Guid ID)
        {
            string storedProcedureName = String.Format(Resource.Proc_GetByID, typeof(T).Name);
            // chuẩn bị các tham số truyền vào proc

            var parameters = new DynamicParameters();
            parameters.Add($"v_{typeof(T).Name}ID", ID);
            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                // Thực hiện gọi vào DB để chạy câu lệnh truy vấn ở trên
                var record = mySqlConnection.QueryFirst<T>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return record;
            }
        }

        #endregion

        #region Base Insert DL

        /// <summary>
        /// Thêm mới một bản ghi 
        /// <param name="record">Đối tượng bản ghi mới</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        public Guid InsertRecord(T record)
        {
            var newID = Guid.NewGuid();
            string storedProcedureName = String.Format(Resource.Proc_Insert, typeof(T).Name);
            var parameters = new DynamicParameters();

            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                string propName = prop.Name;

                object propValue;

                var primaryKeyAttribute = (Primarykey?)Attribute.GetCustomAttribute(prop, typeof(Primarykey));

                if (primaryKeyAttribute != null)
                {
                    propValue = newID;
                }
                else
                {
                    propValue = prop.GetValue(record, null);
                }
                parameters.Add("v_" + propName, propValue);
            }
            int numberOfAffectedRows = 0;
            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {

                numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            if (numberOfAffectedRows > 0)
            {
                return newID;
            }
            else
            {
                return Guid.Empty;
            }

        }

        #endregion

        #region Base Update DL

        /// <summary>
        /// Sửa một bản ghi 
        /// <param name="record">Đối tượng bản ghi cần sửa</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        public Guid UpdateRecord(Guid ID, T record)
        {
            string storedProcedureName = String.Format(Resource.Proc_Update, typeof(T).Name);
            var parameters = new DynamicParameters();

            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                string propName = prop.Name;

                object propValue;
                propValue = prop.GetValue(record, null);
                parameters.Add("v_" + propName, propValue);
            }
            int numberOfAffectedRows = 0;
            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {

                numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
            if (numberOfAffectedRows > 0)
            {
                return ID;
            }
            else
            {
                return Guid.Empty;
            }
        }

        #endregion

        #region Base delete DL

        /// <summary>
        /// Xóa một bản ghi 
        /// <param name="ID">mã bản ghi cần xóa</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// </summary>
        /// Created by: PCTUANANH(30/09/2022)
        public Guid DeleteRecord(Guid ID)
        {
            string storedProcedureName = String.Format(Resource.Proc_DeleteByID, typeof(T).Name);
            // chuẩn bị các tham số truyền vào proc
            var parameters = new DynamicParameters();
            parameters.Add($"v_{typeof(T).Name}ID", ID);
            int numberOfAffectedRows = 0;
            using (var mySqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            if (numberOfAffectedRows > 0)
            {
                return ID;
            }
            else
            {
                return Guid.Empty;
            }
        }

    } 

    #endregion
     
}
