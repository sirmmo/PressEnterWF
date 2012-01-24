using System;
using System.Collections.Generic;
using System.Text;

namespace PressEnter.Flow
{
    public class ImageState : PressState
    {
        public ImageState():base()
        {

        }
        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public ImageState(string image)
        {
            _image = image;
        }

    }
}
