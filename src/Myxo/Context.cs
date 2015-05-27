using System.Collections.Generic;

namespace Myxo
{
    public class Context
    {
        private readonly Stack<Describe> _descriptions = new Stack<Describe>();

        public Describe Description => _descriptions.Count == 0 ? null : _descriptions.Peek();
        public It It { get; set; }

        public void PushDescription(Describe describe) => _descriptions.Push(describe);

        public Describe PopDescription() => _descriptions.Pop();
    }
}