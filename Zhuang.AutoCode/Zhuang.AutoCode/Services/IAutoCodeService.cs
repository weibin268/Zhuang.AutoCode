using System;
using System.Collections.Generic;
using System.Text;
using Zhuang.AutoCode.Models;

namespace Zhuang.AutoCode.Services
{
    public interface IAutoCodeService
    {

        SysAutoCode GetByCode(string code);
        

    }
}
