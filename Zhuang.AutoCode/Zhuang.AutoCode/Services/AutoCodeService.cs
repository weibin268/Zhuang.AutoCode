using System;
using System.Collections.Generic;
using System.Text;
using Zhuang.AutoCode.Models;
using Zhuang.Data;

namespace Zhuang.AutoCode.Services
{
    public class AutoCodeService : IAutoCodeService
    {
        DbAccessor _dba = DbAccessor.Get();

        public SysAutoCode GetByCode(string code)
        {
            return _dba.SelectList<SysAutoCode>(new { Code = code })[0];

        }
    }
}
