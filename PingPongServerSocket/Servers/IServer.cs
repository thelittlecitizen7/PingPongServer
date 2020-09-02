using System;
using System.Collections.Generic;
using System.Text;

namespace User2Chat
{
    public interface IServer
    {
        int Port { get; set; }

        void Listen();

        void Close();

    }
}
