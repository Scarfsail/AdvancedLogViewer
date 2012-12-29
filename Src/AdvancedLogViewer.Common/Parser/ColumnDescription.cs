using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLogViewer.Common.Parser
{
    public class ColumnDescription
    {
        internal ColumnDescription(string columnName, Type columnType)
        {
            this.ColumnName = columnName;
            this.ColumnType = columnType;
        }

        public string ColumnName { get; private set; }
        public Type ColumnType { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", this.ColumnName, this.ColumnType.ToString().Replace("System.",""));
        }
    }
}
