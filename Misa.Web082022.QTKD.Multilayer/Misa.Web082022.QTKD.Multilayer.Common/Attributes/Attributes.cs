using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Web082022.QTKD.Multilayer.Common.Attributes
{
    /// <summary>
    /// Attributes dùng để xác định 1 prop là khóa chính
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Primarykey : Attribute
    {

    }
    /// <summary>
    /// Atribute xác định prop không được để trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsNotNullOrEmptyAttribute : Attribute
    {
        public string Msg;

        public IsNotNullOrEmptyAttribute(string msg)
        {
            this.Msg = msg;
        }
    }

}
