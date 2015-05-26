# Myxo

Trying to do Jasmine in C#

## About

So you'll need C# 6, I'm using [DNX](https://github.com/aspnet/home) but VS2015 should work just as well.

Tests are contained in Console applications, the plan is to make them exit with a non-zero exit code if any tests fail but I haven't got that far yet.

## Basics

This sprang from an example I gave in a talk on C# 6 about the new `using static` feature, which allows you to use static methods without the `Class.Method` syntax. Tests are expressed using Jasmine BDD-style `Describe/It/Expect` constructs.

## Roadmap

* `Before`, `BeforeEach`, `After` and `AfterEach` methods should be pretty simple to implement.
* More methods on the `Myxo.Expect` type for more assertions.
* I'm really just putting this up as a PoC for now, if it floats your boat then please get stuck in.