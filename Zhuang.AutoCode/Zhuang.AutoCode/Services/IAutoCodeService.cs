using System;
using System.Collections.Generic;
using System.Text;
using Zhuang.AutoCode.Models;

namespace Zhuang.AutoCode.Services
{
    public interface IAutoCodeService
    {
        SysAutoCode Get(string id);

        SysAutoCodeDetail GetDetailByPrefixCode(string autoCodeId ,string prefixCode);

        void AddDetail(SysAutoCodeDetail detail);

        void SaveDetail(SysAutoCodeDetail detail);
    }
}
