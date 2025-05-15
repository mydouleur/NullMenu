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
        public List<RootControl> Children { get; set; }
        public virtual void Render()
        {
            if (Children != null)
            {
                foreach (var child in Children)
                {
                    child.Render();
                }
            }
        }
        public EventHandler MouseMove { get; set; }
        public EventHandler MouseDown { get; set; }
        public EventHandler MouseUp { get; set; }

        public abstract bool IsTriggered();
    }
}
