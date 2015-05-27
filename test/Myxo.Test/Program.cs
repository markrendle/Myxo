using static Myxo.Methods;

namespace Myxo.Test
{
    public class Program
    {
        public static void Main()
        {
            Describe("Myxo", () =>
            {
                int n = 0;
                It("should not throw an AssertionException", () =>
                {
                    ++n;
                    Expect(42).ToEqual(42);
                });

                It("should throw an AssertionException", () =>
                {
                    ++n;
                    Expect(54).ToEqual(42);
                });

                Describe("Nested Describes", () =>
                {
                    It("should run in order", () =>
                    {
                        Expect(n).ToEqual(2);
                    });
                });
            });

            Describe("Expect.ToBeNull", () =>
            {
                string s = null;
                It("should pass when value is null", () =>
                {
                    Expect(s).ToBeNull();
                });
            });

            Describe("Expect.Not", () =>
            {
                It("should negate Expect.ToEqual(x)", () =>
                {
                    Expect(54).Not.ToEqual(42);
                });

                It("should negate Expect.ToBeNull()", () =>
                {
                    Expect("").Not.ToBeNull();
                });
            });

            Describe("Before", () =>
            {
                var x = 0;
                Before(() =>
                {
                    x++;
                });

                It("should be called", () =>
                {
                    Expect(x).ToEqual(1);
                });

                It("should only be called once", () =>
                {
                    Expect(x).ToEqual(1);
                });
            });

            Describe("BeforeEach", () =>
            {
                var x = 0;
                BeforeEach(() =>
                {
                    x++;
                });

                It("should have been called once", () => {
                    Expect(x).ToEqual(1);
                });

                It("should have been called twice", () => {
                    Expect(x).ToEqual(2);
                });
        });
        }
    }
}
