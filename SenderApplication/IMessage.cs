using System;
using System.Collections.Generic;
using System.Text;

namespace SenderApplication
{
    public interface IMessage
    {
        public void DisplayResponse();
        public string GetMessage();
    }
}
