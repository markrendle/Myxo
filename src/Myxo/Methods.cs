using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Myxo
{
    public static class Methods
    {
        private static readonly Context _context = new Context();

        public static void Describe(string description, Action action)
        {
            if (_context.Description == null)
            {
                new Describe(description, action).Run(_context).Wait();
            }
            else
            {
                _context.Description.Children.Add(new Describe(description, action, _context.Description));
            }
        }

        public static void It(string should, Action action)
        {
            _context.Description.Children.Add(new It(should, action, _context.Description));
        }

        public static Expect<T> Expect<T>(T value)
        {
            return new Expect<T>(value, _context.It);
        }

        public static void Before(Action beforeAction)
        {
            CheckContext();
            _context.Description.Before(beforeAction);
        }

        public static void BeforeEach(Action beforeEachAction)
        {
            CheckContext();
            _context.Description.BeforeEach(beforeEachAction);
        }

        public static void After(Action afterAction)
        {
            CheckContext();
            _context.Description.After(afterAction);
        }

        public static void AfterEach(Action afterEachAction)
        {
            CheckContext();
            _context.Description.AfterEach(afterEachAction);
        }

        public static void Before(Func<Task> beforeAction)
        {
            CheckContext();
            _context.Description.Before(beforeAction);
        }

        public static void BeforeEach(Func<Task> beforeEachAction)
        {
            CheckContext();
            _context.Description.BeforeEach(beforeEachAction);
        }

        public static void After(Func<Task> afterAction)
        {
            CheckContext();
            _context.Description.After(afterAction);
        }

        public static void AfterEach(Func<Task> afterEachAction)
        {
            CheckContext();
            _context.Description.AfterEach(afterEachAction);
        }


        private static void CheckContext([CallerMemberName]string method = "Method")
        {
            if (_context.Description == null)
            {
                throw new InvalidOperationException($"{method} may only be called within a 'Describe'.");
            }
            if (_context.It != null)
            {
                throw new InvalidOperationException($"{method} may not be called within an 'It'.");
            }
        }
    }
}
