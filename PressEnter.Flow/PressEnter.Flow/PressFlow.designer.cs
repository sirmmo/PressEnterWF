using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace PressEnter.Flow
{
    partial class PressFlow
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("", "")]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            this.setStateActivity4 = new System.Workflow.Activities.SetStateActivity();
            this.setStateActivity3 = new System.Workflow.Activities.SetStateActivity();
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.setStateActivity2 = new System.Workflow.Activities.SetStateActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity3 = new System.Workflow.Activities.EventDrivenActivity();
            this.stateInitializationActivity1 = new System.Workflow.Activities.StateInitializationActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.stateActivity2 = new System.Workflow.Activities.StateActivity();
            this.stateActivity1 = new System.Workflow.Activities.StateActivity();
            this.Workflow1InitialState = new System.Workflow.Activities.StateActivity();
            // 
            // setStateActivity4
            // 
            this.setStateActivity4.Name = "setStateActivity4";
            this.setStateActivity4.TargetStateName = "Workflow1InitialState";
            // 
            // setStateActivity3
            // 
            this.setStateActivity3.Name = "setStateActivity3";
            this.setStateActivity3.TargetStateName = "stateActivity2";
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "stateActivity2";
            // 
            // setStateActivity2
            // 
            this.setStateActivity2.Name = "setStateActivity2";
            this.setStateActivity2.TargetStateName = "stateActivity1";
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.setStateActivity4);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity3
            // 
            this.eventDrivenActivity3.Activities.Add(this.setStateActivity3);
            this.eventDrivenActivity3.Name = "eventDrivenActivity3";
            // 
            // stateInitializationActivity1
            // 
            this.stateInitializationActivity1.Activities.Add(this.setStateActivity1);
            this.stateInitializationActivity1.Name = "stateInitializationActivity1";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.setStateActivity2);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // stateActivity2
            // 
            this.stateActivity2.Activities.Add(this.eventDrivenActivity2);
            this.stateActivity2.Name = "stateActivity2";
            // 
            // stateActivity1
            // 
            this.stateActivity1.Activities.Add(this.eventDrivenActivity3);
            this.stateActivity1.Name = "stateActivity1";
            // 
            // Workflow1InitialState
            // 
            this.Workflow1InitialState.Activities.Add(this.eventDrivenActivity1);
            this.Workflow1InitialState.Activities.Add(this.stateInitializationActivity1);
            this.Workflow1InitialState.Name = "Workflow1InitialState";
            // 
            // PressFlow
            // 
            this.Activities.Add(this.Workflow1InitialState);
            this.Activities.Add(this.stateActivity1);
            this.Activities.Add(this.stateActivity2);
            this.CompletedStateName = null;
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "Workflow1InitialState";
            this.Name = "PressFlow";
            this.CanModifyActivities = false;

        }

        #endregion

        private SetStateActivity setStateActivity4;

        private SetStateActivity setStateActivity3;

        private SetStateActivity setStateActivity1;

        private SetStateActivity setStateActivity2;

        private EventDrivenActivity eventDrivenActivity2;

        private EventDrivenActivity eventDrivenActivity3;

        private StateInitializationActivity stateInitializationActivity1;

        private EventDrivenActivity eventDrivenActivity1;

        private StateActivity stateActivity2;

        private StateActivity stateActivity1;

        private StateActivity Workflow1InitialState;


    }
}
