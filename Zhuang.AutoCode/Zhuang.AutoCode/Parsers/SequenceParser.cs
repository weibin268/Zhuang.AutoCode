using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Zhuang.AutoCode.Models;
using Zhuang.AutoCode.Services;

namespace Zhuang.AutoCode.Parsers
{
    class SequenceParser : IParser
    {
        public string Name
        {
            get
            {
                return "seq";
            }
        }

        /// <summary>
        /// 参数解析，参式格式：{seq:4,0}
        /// </summary>
        /// <param name="context">context.Parameter格式：“最小长度,是否保持递增”，如：1,0</param>
        /// <returns></returns>
        public string Parse(ParserContext context)
        {
            string result = string.Empty;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result = GetSeq(context);
                scope.Complete();
            }

            return result;
        }

        private string GetSeq(ParserContext context)
        {
            var arParam = context.Parameter.Split(',');
            int minLength = 0;
            bool keepIncrease = false;
            string intFormat = "D";
            int Seq = 0;

            int.TryParse(arParam[0], out minLength);

            if (arParam.Length >= 2)
            {
                if (arParam[1] != "0")
                {
                    keepIncrease = true;
                }
            }

            string prefixCode = context.ParsedText.Split('{')[0];

            if (keepIncrease)
            {
                prefixCode = "none";
            }


            var detailModel = context.Service.GetDetailByPrefixCode(context.SysAutoCode.AutoCodeId, prefixCode);

            DateTime dtNow = DateTime.Now;

            if (detailModel != null)
            {
                detailModel.Seq = detailModel.Seq + 1;
                detailModel.ModifiedDate = dtNow;

                context.Service.SaveDetail(detailModel);
            }
            else
            {
                detailModel = new SysAutoCodeDetail();
                detailModel.AutoCodeDetailId = Guid.NewGuid().ToString();
                detailModel.AutoCodeId = context.SysAutoCode.AutoCodeId;
                detailModel.PrefixCode = prefixCode;
                detailModel.Seq = 1;
                detailModel.CreatedDate = dtNow;
                detailModel.ModifiedDate = dtNow;

                context.Service.AddDetail(detailModel);
            }

            intFormat = intFormat + (detailModel.Seq.ToString().Length > minLength ? detailModel.Seq.ToString().Length : minLength);

            if (minLength == 0)
            {
                intFormat = null;
            }

            Seq = detailModel.Seq;

            return Seq.ToString(intFormat);
        }
    }
}
