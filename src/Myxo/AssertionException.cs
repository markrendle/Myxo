using System;

namespace Myxo
{
    public class AssertionException : Exception
    {
	    public AssertionException(string message) : base(message)
        {

        }
    }
}