using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scarfsail.Logging;

namespace Scarfsail.Logging
{
    public class BlockLoggerParams
    {
        private Log log;

        public BlockLoggerParams(Log log)
        {
            this.log = log;
        }

        public void Set(string[] paramNames, params object[] paramValues)
        {
            if (paramNames.Length != paramValues.Length)
            {
                log.Error("ParamNames and ParamValues length has to be same.");
                Text = string.Empty;
            }

            string[] items = new string[paramNames.Length];
            for (int i = 0; i < paramNames.Length; i++)
            {
                items[i] = String.Format("{0}='{1}'", paramNames[i], paramValues[i]);
            }
            Text  = string.Join(", ", items);
        }

        public void Set(string paramsFormat, params object[] args)
        {
            Text = string.Format(paramsFormat, args);
        }

        public void Set(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
