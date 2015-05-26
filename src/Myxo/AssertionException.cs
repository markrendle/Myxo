using System;

namespace Myxo
{
    public class AssertionException : Exception
    {
        private readonly Describe _describe;
        private readonly It _it;
        public AssertionException(string message, Describe describe, It it) : base(message)
        {
            _describe = describe;
            _it = describe.Its.Peek();
        }
    }
}