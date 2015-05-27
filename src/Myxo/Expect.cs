namespace Myxo
{
    public class Expect<T>
    {
        private readonly T _value;
        private readonly It _it;
        private readonly bool _negate;

        public Expect(T value, It it, bool negate = false)
        {
            _value = value;
            _it = it;
            _negate = negate;
        }

        public Expect<T> Not => new Expect<T>(_value, _it, true);

        public void ToEqual(T value)
        {
            BinaryAssert(Equals(value, _value), "to equal", value);
        }

        public void ToBeNull()
        {
            if (typeof(T).IsValueType)
            {
                throw new AssertionException($"Expected a Value Type to be null, d'oh!");
            }
            UnaryAssert((object)_value == null, "to be null");
        }

        public void UnaryAssert(bool result, string positive)
        {
            UnaryAssert(result, positive, "not " + positive);
        }

        public void UnaryAssert(bool result, string positive, string negative)
        {
            if (result == _negate)
            {
                throw new AssertionException($"Expected {Format(_value)} {(_negate ? negative : positive)}");
            }
        }

        public void BinaryAssert(bool result, string positive, T rho)
        {
            BinaryAssert(result, positive, "not " + positive, rho);
        }

        public void BinaryAssert(bool result, string positive, string negative, T rho)
        {
            if (result == _negate)
            {
                throw new AssertionException($"Expected {Format(_value)} {(_negate ? negative : positive)} {Format(rho)}");
            }
        }

        private static string Format(T value)
        {
            if (typeof(T) == typeof(string))
            {
                return $"\"{value}\"";
            }
            else
            {
                return value.ToString();
            }
        }
    }
}