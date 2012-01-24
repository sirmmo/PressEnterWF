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

using System.Reflection.Emit;
using System.Reflection;

namespace PressEnter.Flow
{

    public sealed class PressFlow : StateMachineWorkflowActivity
    {
        private Type _serviceInterface;

        public Type ServiceInterface
        {
            get { return _serviceInterface; }
            set { _serviceInterface = value; }
        }

        private StateActivity _initial;

        private SetStateActivity setStateActivity1;

        private EventDrivenActivity eventDrivenActivity1;

        private DelayActivity delayActivity1;
        private Type _serviceImplementation;

        public Type ServiceImplementation
        {
            get { return _serviceImplementation; }
            set { _serviceImplementation = value; }
        }
        public void Load(String path)
        {
            this.AddButton("b1");
            this.AddButton("b2");

            this._serviceInterface = this.CreateServiceInterface();
            this._serviceImplementation = this.CreateServiceImplementation(this._serviceInterface);
            PressState ps1 = new ImageState("ps1", "img.png", this._serviceInterface);
            PressState ps2 = new AnimationState("ps2", "", 123, this._serviceInterface);

            this.AddState(ps1);
            this.AddState(ps2);
            ps1.AddTrigger("b1", "ps2");
            ps2.AddTrigger("b2", "ps1");
            this.SetInitial(ps1);
        }

        public PressFlow()
        {
            this.CanModifyActivities = true;
            this.CompletedStateName = null;
            this.DynamicUpdateCondition = null;
            this.Name = "PressFlow";
            this.CanModifyActivities = false;
        }

        public void AddState(PressState state)
        {

            this.CanModifyActivities = true;
            this.Activities.Add(state);
            this.CanModifyActivities = false;
        }

        public void SetInitial(PressState state)
        {
            this.CanModifyActivities = true;
            this.InitialStateName = state.Name;
            InitialState = state;
            this.CanModifyActivities = false;
        }

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

        private Type CreateServiceInterface()
        {
            AssemblyName bAssemblyName = new AssemblyName();
            bAssemblyName.Name = "PressEnter.Flow.Generated";
            bAssemblyName.Version = new Version(1, 1, 1, 1);

            AssemblyBuilder bAssembly = System.AppDomain.CurrentDomain.DefineDynamicAssembly(bAssemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder bModule = bAssembly.DefineDynamicModule("PressEnter.Flow.Ifaces.dll", true);

            TypeBuilder tInterface = bModule.DefineType("IPressService", TypeAttributes.Interface | TypeAttributes.Public);
            ConstructorInfo con = typeof(ExternalDataExchangeAttribute).GetConstructor(new Type[] { typeof(string) });
            CustomAttributeBuilder cab = new CustomAttributeBuilder(con, null);
            tInterface.SetCustomAttribute(cab);
            foreach (string button in _buttons)
            {
                EventBuilder b = tInterface.DefineEvent(button, EventAttributes.None, typeof(EventHandler<PressEventArgs>));
            }


            Type tInt = tInterface.CreateType();

            return tInt;
        }


        private Type CreateServiceImplementation(Type iface)
        {
            AssemblyName bAssemblyName = new AssemblyName();
            bAssemblyName.Name = "PressEnter.Flow.Generated";
            bAssemblyName.Version = new Version(1, 1, 1, 1);

            // Define the new assembly and module
            AssemblyBuilder bAssembly = System.AppDomain.CurrentDomain.DefineDynamicAssembly(bAssemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder bModule = bAssembly.DefineDynamicModule("PressEnter.Flow.Ifaces.dll", true);

            TypeBuilder tClass = bModule.DefineType("PressService", TypeAttributes.Class | TypeAttributes.Public);
            tClass.AddInterfaceImplementation(iface);
            tClass.SetParent(typeof(BaseServiceImplementation));
            Type tCls = tClass.CreateType();

            return tCls;
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

        }



        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this._initial = new System.Workflow.Activities.StateActivity();
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "_initial";
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:00");
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.delayActivity1);
            this.eventDrivenActivity1.Activities.Add(this.setStateActivity1);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // _initial
            // 
            this._initial.Activities.Add(this.eventDrivenActivity1);
            this._initial.Name = "_initial";
            // 
            // PressFlow
            // 
            this.Activities.Add(this._initial);
            this.CompletedStateName = null;
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "_initial";
            this.Name = "PressFlow";
            this.CanModifyActivities = false;

        }
    }

}
