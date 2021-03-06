﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muhasebe.Custom;

namespace Muhasebe
{
    public partial class Device
    {
        public dynamic GetConnectionParameters()
        {
            if (this.ConnectionType != null)
            {
                switch (this.ConnectionType.Name)
                {
                    case "USB": return JsonConvert.DeserializeObject<UsbConnectionParameters>(this.Parameters);
                    case "RS-232": return JsonConvert.DeserializeObject<SerialConnectionParameters>(this.Parameters);
                    case "NETWORK": return JsonConvert.DeserializeObject<NetworkConnectionParameters>(this.Parameters);
                    default: return null;
                }
            }
            else
                return null;
        }
    }
}
