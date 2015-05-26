using static Myxo.Methods;

namespace Myxo.Test
{
    public class Program
    {
        public static void Main()
        {
            Describe("Myxo", () =>
            {
                It("should not throw an AssertionException", () =>
                {
                    Expect(42).ToEqual(42);
                });

                It("should throw an AssertionException", () =>
                {
                    Expect(54).ToEqual(42);
                });
            });
        }
    }
}
