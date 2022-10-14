
using Microsoft.AspNetCore.Mvc;
using Misa.Web082022.QTKD.Multilayer.BL;
using Misa.Web082022.QTKD.Multilayer.Common.Entities;
using Misa.Web082022.QTKD.Multilayer.Common.Entities.DTO;
using Misa.Web082022.QTKD.Multilayer.Common.Enums;

using MySqlConnector;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Swashbuckle.AspNetCore.Annotations;
using System.Drawing;

namespace Misa.Web082022.QTKD.Multilayer.API
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BasicController<Employee>
    {

        #region Field

        private IEmployeeBL _employeeBL;
        private ResponeErrorResult responeErrorResult;
        HandleResponeResult handleResponeResult;

        #endregion

        #region Controctor

        public EmployeesController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
            responeErrorResult = new ResponeErrorResult();
            handleResponeResult = new HandleResponeResult();
        }
        #endregion

        #region GetFilter API

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
        /// Created by: PCTUANANH(12/07/2022)
        [HttpGet("filter")]
        public IActionResult Employees([FromQuery] string? search, [FromQuery] string? sort, [FromQuery] int limit = 100, [FromQuery] int offset = 0)
        {
            try
            {

                var filterEmployee = _employeeBL.FilterEmployees(search, sort, limit, offset);
                if (filterEmployee != null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    handleResponeResult.ResponeResult(QTKDCode.Success, 200, true, "[]", filterEmployee)
                       );
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                     handleResponeResult.ResponeResult(QTKDCode.ResultDatabaseFailed, 404, false, "[]", "[]")
                  );
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                       handleResponeResult.ResponeResult(QTKDCode.Exception, 500, false, "[]", "")

                  );
            }
        }

        #endregion

        #region Get New-Code API

        /// <summary>
        /// API Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: PCTUANANH(12/07/2022)
        [HttpGet("new-code")]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                string newEmployeeCode = _employeeBL.GetNewEmployeeCode();
                // Trả về dữ liệu cho client
                return StatusCode(StatusCodes.Status200OK,
                    handleResponeResult.ResponeResult(QTKDCode.Success, 200, true, "[]", newEmployeeCode)
                      );
            }

            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                        handleResponeResult.ResponeResult(QTKDCode.Exception, 500, false, "[]", "")

                   );

            }
        }

        #endregion

        #region Deletelist Employee

        /// <summary>
        /// API xóa nhiều nhân viên
        /// </summary>
        /// <returns>Số dòng thay đổi</returns>
        /// Created by: PCTUANANH(05/10/2022)
        [HttpPost("delete-batch")]
        public IActionResult DeleteListEmployee([FromBody] List<Guid> listEmployeeID)
        {
            try
            {
                var numberOfAffectedRows = _employeeBL.DeleteListEmployee(listEmployeeID);
                if (numberOfAffectedRows > 0)
                {
                    return StatusCode(StatusCodes.Status200OK,
                    handleResponeResult.ResponeResult(QTKDCode.Success, 200, true, "[]", listEmployeeID)
                       );
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                     handleResponeResult.ResponeResult(QTKDCode.ResultDatabaseFailed, 400, false, "[]", listEmployeeID)
                     );
                }
            }
            catch (Exception exception)
            {
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                      handleResponeResult.ResponeResult(QTKDCode.Exception, 500, false, "[]", "")

                 );
            }
        }

        #endregion

        #region  Export-Excel

        /// <summary>
        /// API lấy xuất khẩu dữ liệu ra excel
        /// </summary>
        /// <returns>file excel</returns>
        /// CreatedBy Phạm Công Tuấn Anh(06-10-2022)
        [HttpGet("export-excel")]
        public IActionResult Export()
        {
            try
            {       //epplus

                IEnumerable<Employee> listEmployee = new List<Employee>();

                listEmployee = _employeeBL.GetAllRecords();

                var stream = new MemoryStream();

                using (var xlPackage = new ExcelPackage(stream))
                {
                    var worksheet = xlPackage.Workbook.Worksheets.Add("Danh_sach_nhan_vien");

                    worksheet.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                    worksheet.Row(2).Height = 18;
                    xlPackage.Workbook.Properties.Title = "DANH SÁCH NHÂN VIÊN";

                    xlPackage.Workbook.Properties.Author = " Phạm Công Tuấn Anh";
                    worksheet.Cells["A3"].Value = "STT";
                    worksheet.Cells["B3"].Value = "Mã nhân viên";
                    worksheet.Cells["C3"].Value = "Tên nhân viên";
                    worksheet.Cells["D3"].Value = "Giới tính";
                    worksheet.Cells["E3"].Value = "Ngày sinh";
                    worksheet.Cells["F3"].Value = "Số CMND";
                    worksheet.Cells["G3"].Value = "Chức danh";
                    worksheet.Cells["H3"].Value = "Tên đơn vị";
                    worksheet.Cells["I3"].Value = "Số tài khoản";
                    worksheet.Cells["J3"].Value = "Tên ngân hàng";
                    worksheet.Cells["K3"].Value = "Chi nhánh ngân hàng";

                    //format widtd and float 
                    worksheet.Cells.AutoFitColumns();
                    worksheet.Column(1).Width = 5;
                    worksheet.Column(2).Width = 16;
                    worksheet.Column(3).Width = 30;
                    worksheet.Column(4).Width = 12;
                    worksheet.Column(5).Width = 16;
                    worksheet.Column(6).Width = 20;
                    worksheet.Column(7).Width = 30;
                    worksheet.Column(8).Width = 30;
                    worksheet.Column(9).Width = 26;
                    worksheet.Column(10).Width = 26;
                    worksheet.Column(11).Width = 26;
                    worksheet.Column(5).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Cells.Style.Font.Name = "Arial";

                    var startRow = 5;

                    var row = startRow;

                    worksheet.Cells["A1"].Value = "Danh sách nhân viên";
                    worksheet.Column(5).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    using (var r = worksheet.Cells["A1:K1"])
                    {
                        r.Merge = true;

                        r.Style.Font.Color.SetColor(Color.Black);
                        r.Style.Font.Size = 16;

                        r.Style.Font.Bold = true;

                        r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

                        r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        r.Style.Fill.BackgroundColor.SetColor(Color.White);

                        r.Style.Border.Top.Style = ExcelBorderStyle.Hair;
                        r.Style.Border.Left.Style = ExcelBorderStyle.Hair;
                        r.Style.Border.Right.Style = ExcelBorderStyle.Hair;
                        r.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                    }

                    using (var r = worksheet.Cells["A2:K2"])
                    {
                        r.Merge = true;
                    }
                    using (var r = worksheet.Cells["A3:K3"])
                    {
                        // r.Style.Font.Color.SetColor(Color.B);
                        r.Style.Font.Size = 10;
                        r.Style.Font.Bold = true;
                        r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        r.Style.Fill.BackgroundColor.SetColor(Color.DarkGray);
                        r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        r.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    }
                  

                    row = 4;
                    int STT = 1;
                    int start = 4;
                    int end = 4;
                    foreach (var item in listEmployee)
                    {
                        string gender = "";
                        switch (item.Gender)
                        {
                            case Gender.Male:
                                gender = "Nam";
                                break;
                            case Gender.Female:
                                gender = "Nữ";
                                break;
                            case Gender.Other:
                                gender = "Khác";
                                break;
                        }

                        worksheet.Cells[row, 1].Value = STT++;
                        worksheet.Cells[row, 2].Value = item.EmployeeCode;
                        worksheet.Cells[row, 3].Value = item.EmployeeName;
                        worksheet.Cells[row, 4].Value = gender;
                        worksheet.Cells[row, 5].Value = item.DateOfBirth?.ToString("MM/dd/yyyy");
                        worksheet.Cells[row, 6].Value = item.IdentityNumber;
                        worksheet.Cells[row, 7].Value = item.PositionName;
                        worksheet.Cells[row, 8].Value = item.DepartmentName;
                        worksheet.Cells[row, 9].Value = item.AccountBank?.ToString();
                        worksheet.Cells[row, 10].Value = item.NameBank;
                        worksheet.Cells[row, 11].Value = item.BranchBank;

                        // tạo cell border
                        string modelRange = "A" + start++ + ":K" + end++;
                        var modelTable = worksheet.Cells[modelRange];

                        modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        row++;
                    }
                   

                    xlPackage.Save();

                }
                stream.Position = 0;

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Danh_sach_nhan_vien.xlsx");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     handleResponeResult.ResponeResult(QTKDCode.Exception, 500, false, "[]", "")

                );
            }
        }

        #endregion

    }
}
