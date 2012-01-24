using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;

using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace PressEnter.Flow
{
    public abstract class PressState : StateActivity
    {
        public PressState():base()
        {

        }
        private Type _iface;

        public Type Interface
        {
            get { return _iface; }
            set { _iface = value; }
        }
        public PressState(string name, Type iface):base()
        {
            Name = name;
            _iface = iface;
        }


        public void AddTrigger(string buttonName, string nextState) {
            EventDrivenActivity eda = new EventDrivenActivity();
            HandleExternalEventActivity heea = new HandleExternalEventActivity();
            heea.InterfaceType = _iface;
            heea.EventName = "ButtonPressed";
            SetStateActivity ssa = new SetStateActivity();
            ssa.TargetStateName = nextState;
            eda.Activities.Add(heea);
            eda.Activities.Add(ssa);
            this.CanModifyActivities = true;
            this.Activities.Add(eda);
            this.CanModifyActivities = false;
        }
    }
}
