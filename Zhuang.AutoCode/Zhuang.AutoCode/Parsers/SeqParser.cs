using System;
using System.Collections.Generic;
using System.Text;
using Zhuang.AutoCode.Models;
using Zhuang.AutoCode.Services;
using Zhuang.Data;

namespace Zhuang.AutoCode.Parsers
{
    class SeqParser : IParser
    {

        private IAutoCodeService _autoCodeService = new AutoCodeService();

        public string Name
        {
            get
            {
                return "seq";
            }
        }

        public string Parse(ParserContext context)
        {
            var arParam = context.Parameter.Split(',');
            int minLength = 0;
            bool keepIncrease = false;

            int.TryParse(arParam[0],out minLength);

            if (arParam.Length >= 2)
            {
                if (arParam[1] != "0") { 
                    keepIncrease = true;
                }
            }

            DbAccessor dba = DbAccessor.Get();

            string prefixCode = context.ParsedText.Split('{')[0];

            if (keepIncrease)
            {
                prefixCode = null;
            }

            var detailModel = _autoCodeService.GetDetailByPrefixCode(context.SysAutoCode.AutoCodeId, prefixCode);

            if (detailModel != null)
            {
                detailModel.Seq = detailModel.Seq + 1;

                _autoCodeService.SaveDetail(detailModel);
            }
            else
            {
                detailModel = new SysAutoCodeDetail();
                detailModel.AutoCodeDetailId = Guid.NewGuid().ToString();
                detailModel.AutoCodeId = context.SysAutoCode.AutoCodeId;
                detailModel.PrefixCode = prefixCode;
                detailModel.Seq = 1;

                _autoCodeService.AddDetail(detailModel);
            }


            var intFormat = "D" + (detailModel.Seq.ToString().Length > minLength ? detailModel.Seq.ToString().Length : minLength);
            if (minLength == 0)
            {
                intFormat = null;
            }

            return detailModel.Seq.ToString(intFormat);
        }
    }
}
