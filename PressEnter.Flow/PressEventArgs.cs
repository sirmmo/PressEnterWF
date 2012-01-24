using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Activities;

namespace PressEnter.Flow
{
    [Serializable]
    public class PressEventArgs : ExternalDataEventArgs
    {
        public PressEventArgs(System.Guid InstanceId) :
            base(InstanceId) { }
        private string _buttonName;

        public string ButtonName
        {
            get { return _buttonName; }
            set { _buttonName = value; }
        }

    }
}
