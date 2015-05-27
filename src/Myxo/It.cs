using System;
using System.Threading.Tasks;
using static Myxo.Writers;

namespace Myxo
{
    public class It : Element
    {
        private static readonly Task Completed = Task.FromResult(0);

        public It(string text, Action action, Describe describe) : base(text, action)
        {
            Describe = describe;
        }

        public Describe Describe { get; }

        public override Task Run(Context context)
        {
            context.It = this;

            try
            {
                Action();
                Passed(this);
            }
            catch (AssertionException ex)
            {
                Failed(this, ex.Message);
            }
            finally
            {
                context.It = null;
            }
            
            return Completed;
        }

        public override string ToString()
        {
            return $"{Describe} {Text}";
        }
    }
}