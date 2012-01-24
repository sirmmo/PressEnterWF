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
using System.Collections.Generic;

namespace PressEnter.Flow
{

    public sealed class PressFlow : StateMachineWorkflowActivity
    {
        public PressFlow()
        {
            this.CanModifyActivities = true;
            this.CompletedStateName = null;
            this.DynamicUpdateCondition = null;
            this.Name = "PressFlow";
        }

        public void AddState(PressState state)
        {
            this.Activities.Add(state);
        }

        public void SetInitial(PressState state)
        {
            this.InitialStateName = state.Name;
            InitialState = state;
        }

        private HandleExternalEventActivity handleExternalEventActivity1;

        private PressState _init;

        public PressState InitialState
        {
            get { return _init; }
            set { _init = value; }
        }

        public void AddButton(string button)
        {
            _buttons.Add(button);
        }

        public static PressFlow Load(String path)
        {
            PressFlow p = new PressFlow();
            p.AddButton("b1");
            p.AddButton("b2");
            PressState ps1 = new ImageState("img.png");
            ps1.Name = "ps1";
            PressState ps2 = new AnimationState("", 123);
            ps1.Name = "ps2";

            p.AddState(ps1);
            p.AddState(ps2);
            ps1.AddTrigger("b1", "ps2");
            ps2.AddTrigger("b2", "ps1");
            p.SetInitial(ps1);
            return p;
        }


        public void StartFlow()
        {
            CanModifyActivities = false;
        }
        public void StopFlow()
        {
            CanModifyActivities = true;
        }
        private List<String> _buttons = new List<string>();
        public List<string> Buttons
        {
            get
            {
                return _buttons;
            }
            set
            {
                _buttons = value;
            }
        }

        public void SendEvent(string p)
        {
            this.
        }

        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            this.handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            // 
            // handleExternalEventActivity1
            // 
            this.handleExternalEventActivity1.Name = "handleExternalEventActivity1";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.handleExternalEventActivity1);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // PressFlow
            // 
            this.Activities.Add(this.eventDrivenActivity1);
            this.CompletedStateName = null;
            this.DynamicUpdateCondition = null;
            this.InitialStateName = null;
            this.Name = "PressFlow";
            this.CanModifyActivities = false;

        }

        private EventDrivenActivity eventDrivenActivity1;
    }

}
