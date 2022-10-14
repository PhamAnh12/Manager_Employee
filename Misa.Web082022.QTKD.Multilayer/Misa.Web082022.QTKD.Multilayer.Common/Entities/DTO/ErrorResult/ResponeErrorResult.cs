
using Microsoft.AspNetCore.Http;
using Misa.Web082022.QTKD.Multilayer.Common.Enums;
using Misa.Web082022.QTKD.Multilayer.Common;
namespace Misa.Web082022.QTKD.Multilayer.Common.Entities
{
   public class ResponeErrorResult
    {
        /// <summary>
        /// hàm  trả về  khi lấy dữ liệu không thành công
        ///  CreatedBy PCTUANANH(30/09/2022)
        /// </summary>
        public ErrorResult ErrorResultGet(string traceIdentifier)
        {
            return new ErrorResult(
                    QTKDCode.ResultDatabaseFailed,
                    Resource.DevMsg_GetFailed,
                    Resource.UserMsg_GetFailed,
                    Resource.MoreInfo_GetFailed,
                    traceIdentifier
                    );
        }

        /// <summary>
        /// hàm  trả về  khi thêm dữ liệu không thành công
        ///  CreatedBy PCTUANANH(30/09/2022)
        /// </summary>
        public ErrorResult ErrorResultInsert(string traceIdentifier)
        {
            return new ErrorResult(
                    QTKDCode.ResultDatabaseFailed,
                     Resource.DevMsg_InsertFailed,
                     Resource.UserMsg_InsertFailed,
                     Resource.MoreInfo_InsertFailed,
                     traceIdentifier
                   );
        }

        /// <summary>
        /// hàm  trả về  khi sửa dữ liệu không thành công
        ///  CreatedBy PCTUANANH(30/09/2022)
        /// </summary>
        public ErrorResult ErrorResultUpdate(string traceIdentifier)
        {
            return new ErrorResult(
                     QTKDCode.ResultDatabaseFailed,
                     Resource.DevMsg_UpdateFailed,
                     Resource.UserMsg_UpdateFailed,
                     Resource.MoreInfo_UpdateFailed,
                     traceIdentifier
                   );
        }

        /// <summary>
        /// hàm  trả về  khi xóa bản ghi  không thành công
        ///  CreatedBy PCTUANANH(30/09/2022)
        /// </summary>
        public ErrorResult ErrorResultDelete(string traceIdentifier)
        {
            return new ErrorResult(
                     QTKDCode.ResultDatabaseFailed,
                    Resource.DevMsg_DeleteFailed,
                    Resource.UserMsg_DeleteFailed,
                    Resource.MoreInfo_DeleteFailed,
                     traceIdentifier
                    );
        }

        /// <summary>
        /// hàm  trả về  khi sửa dữ liệu chưa được validate
        ///  CreatedBy PCTUANANH(30/09/2022)
        /// </summary>
        public ErrorResult ErrorResultValidate(string traceIdentifier, string strValidate)
        {
           return  new ErrorResult(
                           QTKDCode.InputValidation,
                           Resource.DevMsg_ValidateFailed,
                           Resource.UserMsg_ValidateFailed,
                           strValidate,
                           traceIdentifier
                       );
        }

        /// <summary>
        /// hàm  trả về  khi có  DuplicateCode
        ///  CreatedBy PCTUANANH(30/09/2022)
        /// </summary>
        public ErrorResult ErrorResultDuplicateCode(string traceIdentifier)
        {
            return new ErrorResult(
                      QTKDCode.DuplicateCode,
                      Resource.DevMsg_DuplicateCode,
                      Resource.UserMsg_DuplicateCode,
                      Resource.MoreInfo_DuplicateCode,
                      traceIdentifier
                     );
        }


        /// <summary>
        /// hàm  trả về  khi có Exception
        ///  CreatedBy PCTUANANH(30/09/2022)
        /// </summary>
        public ErrorResult ErrorResultException(string traceIdentifier)
        {
            return new ErrorResult(
                      QTKDCode.Exception,
                      Resource.DevMsg_Exception,
                      Resource.UserMsg_Exception,
                      Resource.MoreInfo_Exception,
                       traceIdentifier
                     );
        }
    }
}
