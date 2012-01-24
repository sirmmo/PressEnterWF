using System;
using System.Collections.Generic;
using System.Text;

namespace PressEnter.Flow
{
    public class BaseServiceImplementation
    {
        public void ButtonPressed(Guid instanceId, string buttonName)
        {
            PressEventArgs args = new
                PressEventArgs(instanceId);
            args.ButtonName = buttonName;


            MulticastDelegate eventDelagate =
                  (MulticastDelegate)this.GetType().GetField(buttonName,
                   System.Reflection.BindingFlags.Instance |
                   System.Reflection.BindingFlags.NonPublic).GetValue(this);

            Delegate[] delegates = eventDelagate.GetInvocationList();

            foreach (Delegate dlg in delegates)
            {
                dlg.Method.Invoke(dlg.Target, new object[] { this, args });
            }


        }


    }
}
