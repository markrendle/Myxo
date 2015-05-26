namespace Myxo
{
    public class Expect<T>
    {
        private readonly T _value;
        private readonly Describe _describe;

        public Expect(T value, Describe describe)
        {
            _value = value;
            _describe = describe;
        }

        public void ToEqual(T value)
        {
            if (!Equals(value, _value))
            {
                throw new AssertionException($"Expected {_value} to equal {value}", _describe, _describe.Its.Peek());
            }
        }
    }
}