using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myxo
{
    public class Describe : Element
    {
        private readonly List<Delegate> _befores = new List<Delegate>();
        private readonly List<Delegate> _beforeEaches = new List<Delegate>();
        private readonly List<Delegate> _afters = new List<Delegate>();
        private readonly List<Delegate> _afterEaches = new List<Delegate>();

        public Describe(string text, Action action, Describe parent = null) : base(text, action)
        {
            Parent = parent;
        }

        public Describe Parent { get; }

        public void Before(Action before)
        {
            _befores.Add(before);
        }

        public void Before(Func<Task> asyncBefore)
        {
            _befores.Add(asyncBefore);
        }

        public void BeforeEach(Action beforeEach)
        {
            _beforeEaches.Add(beforeEach);
        }

        public void BeforeEach(Func<Task> asyncBeforeEach)
        {
            _beforeEaches.Add(asyncBeforeEach);
        }

        public void After(Action after)
        {
            _afters.Add(after);
        }

        public void After(Func<Task> asyncAfter)
        {
            _afters.Add(asyncAfter);
        }

        public void AfterEach(Action afterEach)
        {
            _afterEaches.Add(afterEach);
        }

        public void AfterEach(Func<Task> asyncAfterEach)
        {
            _afterEaches.Add(asyncAfterEach);
        }

        protected IEnumerable<Delegate> Befores => _befores;
        protected IEnumerable<Delegate> BeforeEaches =>
            (Parent?.BeforeEaches ?? Enumerable.Empty<Delegate>()).Concat(_beforeEaches);

        protected IEnumerable<Delegate> Afters => _afters;
        protected IEnumerable<Delegate> AfterEaches =>
            (Parent?.AfterEaches ?? Enumerable.Empty<Delegate>()).Concat(_afterEaches);

        public List<Element> Children { get; } = new List<Element>();

        public override async Task Run(Context context)
        {
            context.PushDescription(this);
            Action();

            await Execute(Befores);

            foreach (var child in Children)
            {
                await Execute(BeforeEaches);
                await child.Run(context);
                await Execute(AfterEaches);
            }

            await Execute(Afters);
            context.PopDescription();
        }

        private static async Task Execute(IEnumerable<Delegate> delegates)
        {
            foreach (var d in delegates)
            {
                var asyncFunc = d as Func<Task>;
                if (asyncFunc != null)
                {
                    await asyncFunc().ConfigureAwait(false);
                }
                else
                {
                    d.DynamicInvoke();
                }
            }
        }

        public override string ToString()
        {
            return Parent == null ? Text : $"{Parent} {Text}";
        }
    }
}