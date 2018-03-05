using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scarfsail.SoftwareUpdates
{
    public class UpdateEventArgs : EventArgs
    {
        public UpdateEventArgs(string description, bool skipIfPeriodNotElapsed)
        {
            this.Description = description;
            this.SkipIfPeriodNotElapsed = skipIfPeriodNotElapsed;
        }

        public string Description { get; private set; }
        public bool SkipIfPeriodNotElapsed { get; private set; }
    }
}
