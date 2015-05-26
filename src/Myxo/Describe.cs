using System;
using System.Collections.Generic;

namespace Myxo
{
    public class Describe
    {
	    public Describe(string description, Action action)
        {
            Description = description;
            Action = action;
        }

        public string Description { get; }

        public Action Action { get; }

        public Stack<It> Its { get; } = new Stack<It>();
    }
}