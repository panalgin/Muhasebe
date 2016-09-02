using Muhasebe.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe.Scripts
{
    public static class GuiManipulator
    {
        public static bool CanShowStatistics
        {
            get
            {
                Settings.Default.Reload();
                return Settings.Default.CanShowStatistics;
            }
            set
            {
                Settings.Default.CanShowStatistics = value;
                Settings.Default.Save();
            }
        }
    }
}
