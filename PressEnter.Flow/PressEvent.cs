using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Activities;

namespace PressEnter.Flow
{
    [ExternalDataExchange]
    public interface IPressEvent
    {
        public string ButtonName { get; }
    }
}
