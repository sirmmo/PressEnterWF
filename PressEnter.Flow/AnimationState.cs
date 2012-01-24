using System;
using System.Collections.Generic;
using System.Text;

namespace PressEnter.Flow
{
    public class AnimationState:PressState
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

        public int Timeout
        {
            get { return _millis; }
            set { _millis = value; }
        }
        public AnimationState(string path, int millis)
        {
            Timeout = millis;
            Path = path;
        }
    }
}
