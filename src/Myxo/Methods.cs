using System;
using System.Collections.Generic;

namespace Myxo
{
    public static class Methods
    {
        private static readonly Stack<Describe> _describes = new Stack<Describe>();

        public static void Describe(string description, Action action)
        {
            var describe = new Describe(description, action);
            _describes.Push(describe);
            action();
            describe = _describes.Peek();
            foreach (var it in describe.Its)
            {
                try
                {
                    it.Action();
                }
                catch (AssertionException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            _describes.Pop();
        }

        public static void It(string should, Action action)
        {
            _describes.Peek().Its.Push(new It(should, action));
        }

        public static Expect<T> Expect<T>(T value)
        {
            return new Expect<T>(value, _describes.Peek());
        }
    }
}
