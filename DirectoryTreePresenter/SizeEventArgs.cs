using System;

namespace DirectoryTreePresenter
{

    public class SizeEventArgs : EventArgs
    {
        public readonly long size;

        public SizeEventArgs(long value)
        {
            size = value;
        }
    }

}
