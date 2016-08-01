using System;
using System.Collections.Generic;
using System.Text;

namespace Zhuang.AutoCode.Models
{
    [Zhuang.Data.Annotations.Table("Sys_AutoCode")]
    public class SysAutoCode
    {
        [Zhuang.Data.Annotations.Key]
        public string AutoCodeId { get; set; }

        public int Seq { get; set; }
        
        public string Expression { get; set; }

        public string Description { get; set; }

    }
}
