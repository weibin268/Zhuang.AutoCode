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

            using (var dba = DbAccessorFactory.CreateDbAccessor())
            {

                dba.BeginTran();

                try
                {


                    AutoCodeService service = new AutoCodeService(dba);

                    var detailModel = service.GetDetailByPrefixCode(context.SysAutoCode.AutoCodeId, prefixCode);

                    if (detailModel != null)
                    {
                        detailModel.Seq = detailModel.Seq + 1;

                        service.SaveDetail(detailModel);
                    }
                    else
                    {
                        detailModel = new SysAutoCodeDetail();
                        detailModel.AutoCodeDetailId = Guid.NewGuid().ToString();
                        detailModel.AutoCodeId = context.SysAutoCode.AutoCodeId;
                        detailModel.PrefixCode = prefixCode;
                        detailModel.Seq = 1;

                        service.AddDetail(detailModel);
                    }

                    intFormat = intFormat + (detailModel.Seq.ToString().Length > minLength ? detailModel.Seq.ToString().Length : minLength);

                    if (minLength == 0)
                    {
                        intFormat = null;
                    }

                    Seq = detailModel.Seq;

                    dba.CommitTran();
                }
                catch (Exception)
                {
                    dba.RollbackTran();
                    throw;
                }

            }

            return Seq.ToString(intFormat);
        }
    }
}
