using System;
using System.Collections.Generic;
using System.Text;

namespace Zhuang.AutoCode.Models
{
    [Zhuang.Data.Annotations.Table("Sys_AutoCodeDetail")]
    public class SysAutoCodeDetail
    {
        [Zhuang.Data.Annotations.Key]
        public string AutoCodeDetailId { get; set; }

        public string AutoCodeId { get; set; }

        public string PrefixCode { get; set; }

        public int Seq { get; set; }
        
        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
