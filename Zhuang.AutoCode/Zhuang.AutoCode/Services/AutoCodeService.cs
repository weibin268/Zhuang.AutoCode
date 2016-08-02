using System;
using System.Collections.Generic;
using System.Text;
using Zhuang.AutoCode.Models;
using Zhuang.Data;

namespace Zhuang.AutoCode.Services
{
    public class AutoCodeService : IAutoCodeService
    {
        DbAccessor _dba;

        public AutoCodeService()
        {
            _dba = DbAccessor.Get();
        }

        public void AddDetail(SysAutoCodeDetail detail)
        {
            _dba.Insert(detail);
        }

        public SysAutoCode Get(string id)
        {
            return _dba.Select<SysAutoCode>(id);
        }

        public SysAutoCodeDetail GetDetailByPrefixCode(string autoCodeId, string prefixCode)
        {
            var list = _dba.SelectList<SysAutoCodeDetail>(new { AutoCodeId = autoCodeId, PrefixCode = prefixCode });
            return list.Count > 0 ? list[0] : null;
        }

        public void SaveDetail(SysAutoCodeDetail detail)
        {
            _dba.Update(detail);
        }
    }
}
