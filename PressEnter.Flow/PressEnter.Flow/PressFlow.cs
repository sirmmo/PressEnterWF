using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;

using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace PressEnter.Flow
{
    public sealed partial class PressFlow : StateMachineWorkflowActivity
    {
        public PressFlow()
        {
            InitializeComponent();
        }

        public void AddState(PressState state){
            this.Activities.Add(state);
        }

        public Delegate ButtonEvent(string buttonName);

        public static PressFlow Load(String path)
        {
            return null;
        }
    }

}
