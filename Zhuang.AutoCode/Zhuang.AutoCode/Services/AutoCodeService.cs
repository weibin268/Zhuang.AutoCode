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

        public SysAutoCode Get(string id)
        {
            return _dba.Select<SysAutoCode>(id);
        }
    }
}
