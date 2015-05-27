# Myxo

Trying to do Jasmine in C# 6

## About

So you'll need C# 6, I'm using [DNX](https://github.com/aspnet/home) but VS2015 should work just as well.

Tests are contained in Console applications, the plan is to make them exit with a non-zero exit code if any tests fail but I haven't got that far yet.

The idea for this came from a talk I gave on C# 6 at DevSum 2015, so I'm using as many of the new features as I can, including `using static`, *string interpolation*, expression-bodied properties and methods, null conditional operators and probably some other stuff.

## Basics

Tests are expressed using Jasmine BDD-style `Describe/It/Expect` constructs.

### Example

```csharp
using static Myxo.Methods;

namespace Calc.Test
{
	public class Program
	{
		public static void Main()
		{
			Describe("Calculator", () => {

				var calculator = new Calculator();

				BeforeEach(() => {
					calculator.Reset();
				});

				It("should Add 2 + 2", () {
					Expect(calculator.Add(2,2)).ToEqual(4);
				});

			});
		}
	}
}
```

One of the advantages to this code-based approach to declaring tests is that you can do meta-programmed tests, like this example which declares multiple `It`s in a loop:

```csharp
Describe("Meta-Programming", () =>
{
    var pairs = new Dictionary<string, string>
    {
        { "abc", "cba" },
        { "banana", "ananab" }
    };

    foreach (var pair in pairs)
    {
        It($"should correctly reverse '{pair.Key}'", () =>
        {
            Expect(Reverse(pair.Key)).ToEqual(pair.Value);

        	// Also notice we're taking advantage of
        	// C# 6's new closures-in-loops rules :)
        });
    }
});
```

**More examples:** [test/Myxo.Test/Program.cs](https://github.com/markrendle/Myxo/blob/master/test/Myxo.Test/Program.cs)

## Known issues

* Coloring console output isn't working on my ElementaryOS with Mono 4.01.

## Roadmap

* More methods on the `Myxo.Expect` type for more assertions.
* NuGet package.
* Pluggable "reporters".
* CoreCLR support.
* I'm really just putting this up as a PoC for now, if it floats your boat then please get stuck in.
* Hmm. You know, this would work really well with [ScriptCS](http://scriptcs.net)...
