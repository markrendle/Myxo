using System;
using static Myxo.Writers;

namespace Myxo
{
    public class Expect<T>
    {
        private readonly T _value;
        private readonly It _it;

        public Expect(T value, It it)
        {
            _value = value;
            _it = it;
        }

        public void ToEqual(T value)
        {
            if (!Equals(value, _value))
            {
                throw new AssertionException($"Expected {_value} to equal {value}");
            }
        }

        private void Execute(Func<bool> assertion, string message)
        {
            if (!assertion())
            {
                Passed(_it);
            }
            else
            {
                Failed(_it, message);
            }
        }
    }
}