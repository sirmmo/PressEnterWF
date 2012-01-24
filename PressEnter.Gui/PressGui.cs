using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PressEnter.Flow;

namespace PressEnter.Gui
{
    public partial class PressGui : Form
    {
        private PressFlow _flow;
        public PressGui()
        {
            InitializeComponent();
            InitFlow();
            InitUI();
            RunUI();
        }

        private void RunUI()
        {
            //throw new NotImplementedException();
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
            _stateLabel.Text = _flow.InitialStateName;

        }

        void b_Click(object sender, EventArgs e)
        {
            _flow.SendEvent((sender as Button).Text);
        }

        private void InitFlow()
        {
            _flow = PressFlow.Load("config.xml");
            _flow.StartFlow();
        }


       
    }
}
