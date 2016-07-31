using System;
using System.Collections.Generic;
using System.Text;

namespace Zhuang.AutoCode.Models
{
    [Zhuang.Data.Annotations.Table("Sys_AutoCode")]
    public class SysAutoCode
    {
        public string AutoCodeId { get; set; }

        public string Code { get; set; }

        public int Seq { get; set; }
        
        public string Expression { get; set; }

        public string Description { get; set; }

    }
}
