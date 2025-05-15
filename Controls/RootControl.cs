using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullMenu.Controls
{
    public abstract class RootControl
    {
        public RootControl Parent { get; set; }
        public List<RootControl>Children { get; set; }
        public abstract void Render();
        public EventHandler MouseMove { get; set; }
        public EventHandler MouseDown { get; set; }
        public EventHandler MouseUp { get; set; }

        public abstract bool IsTriggered { get; set; }
    }
}
