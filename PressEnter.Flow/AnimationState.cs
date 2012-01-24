using System;
using System.Collections.Generic;
using System.Text;

namespace PressEnter.Flow
{
    public class AnimationState : PressState
    {
        public AnimationState():base()
        {

        }
        private string _path;

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        private int _millis;
        private Type iface;

        public int Timeout
        {
            get { return _millis; }
            set { _millis = value; }
        }

        public AnimationState(string name, string path, int millis, Type iface)
            : base(name, iface)
        {
            Timeout = millis;
            Path = path;
            this.iface = iface;
        }
    }
}
