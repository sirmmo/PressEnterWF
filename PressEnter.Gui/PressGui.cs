using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PressEnter.Flow;
using System.Workflow.Runtime;
using System.Workflow.Activities;

namespace PressEnter.Gui
{
    public partial class PressGui : Form
    {
        private PressFlow _flow;
        private WorkflowRuntime _workflowRuntime;
        private WorkflowInstance _instance;
        private BaseServiceImplementation _eventService;
        public PressGui()
        {
            InitializeComponent();
            _workflowRuntime = new WorkflowRuntime();
            _instance = _workflowRuntime.CreateWorkflow(typeof(PressFlow));
            _flow = _instance.GetWorkflowDefinition() as PressFlow;
            InitFlow();
            InitUI();
            RunUI();
        }

        private void RunUI()
        {
            _stateLabel.Text = _flow.InitialStateName;
            ExternalDataExchangeService externalDataSvc = new ExternalDataExchangeService();
            _workflowRuntime.AddService(externalDataSvc);
            BaseServiceImplementation _eventService = Activator.CreateInstance(_flow.ServiceImplementation) as BaseServiceImplementation;
            externalDataSvc.AddService(_eventService);

            _instance.Start();
            
        }

        private void InitUI()
        {
            List<string> _buttons = _flow.Buttons;
            foreach (var button in _buttons)
            {
                Button b = new Button();
                b.Text = button;
                b.Click+=new EventHandler(b_Click);
                _buttonPanel.Controls.Add(b);
            }

        }

        void b_Click(object sender, EventArgs e)
        {
            _eventService.ButtonPressed(_instance.InstanceId, (sender as Button).Text);
        }

        private void InitFlow()
        {
            _flow.Load("config.xml");
            _flow.StartFlow();
        }


       
    }
}
