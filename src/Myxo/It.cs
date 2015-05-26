using System;

namespace Myxo
{
    public class It
    {
	    public It(string should, Action action)
        {
            Should = should;
            Action = action;
        }

        public string Should { get; }
        public Action Action { get; }
    }
}