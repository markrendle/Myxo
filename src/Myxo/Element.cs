using System;
using System.Threading.Tasks;

namespace Myxo
{
    public abstract class Element
    {
	    protected Element(string text, Action action)
        {
            Text = text;
            Action = action;
        }

        public string Text { get; }
        public Action Action { get; }

        public abstract Task Run(Context context);
    }
}