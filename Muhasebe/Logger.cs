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

            try
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Event m_Event = new Event();
                    m_Event.AuthorID = Program.User.ID;
                    m_Event.CreatedAt = DateTime.Now;
                    m_Event.Description = string.Format("{0} - {1}", ex.Message, ex.StackTrace);
                    m_Event.CategoryID = 3; //Hata
                    m_Context.Events.Add(m_Event);
                    m_Context.SaveChanges();
                }
            }
            catch (Exception exp)
            {

            }
        }
    }
}
