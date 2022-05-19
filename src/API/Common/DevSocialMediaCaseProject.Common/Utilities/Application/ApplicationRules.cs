using DevSocialMediaCaseProject.Common.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Common.Utilities.Application
{
    public class ApplicationRules
    {
        public static IResponse RunLogicsAsync(params Task<IResponse>[] logics)
        {
            foreach(var logic in logics)
            {
                
                if (!logic.Result.IsSuccess)
                    return logic.Result;
            }
            return null;
        }

        public static IResponse RunLogics(params IResponse[] logics)
        {
            foreach (var logic in logics)
            {

                if (!logic.IsSuccess)
                    return logic;
            }
            return null;
        }
    }
}
