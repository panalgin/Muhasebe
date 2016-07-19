using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe
{
    public partial class User
    {
        public string FullName { get { return string.Format("{0} {1}", this.Name, this.Surname); } }
    }
}
