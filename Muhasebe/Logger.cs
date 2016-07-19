using Muhasebe.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe
{
    public static class Logger
    {
        public static void Enqueue(Exception ex)
        {
            ErrorEventArgs m_Args = new ErrorEventArgs();
            m_Args.Exception = ex;
            m_Args.HappenedAt = DateTime.Now;

            EventSink.InvokeError("Logger", m_Args);
        }
    }
}
