using NullMenu.Event;
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
        public EventHandler<MouseEventArgs> MouseMove { get; set; }
        public EventHandler<MouseButtonEventArgs> MouseDown { get; set; }
        public EventHandler<MouseButtonEventArgs> MouseUp { get; set; }
        public static RootControl GetTrigControl(RootControl root)
        {
            RootControl tempTrig = null;
            if (root.IsTriggered())
            {
                tempTrig = root;
                if (root.Children != null)
                {
                    foreach (var child in root.Children)
                    {
                        if (GetTrigControl(child) != null)
                        {
                            tempTrig = child;
                            break;
                        }
                    }
                }
            }
            return tempTrig;
        }
        public abstract bool IsTriggered();
    }
}
