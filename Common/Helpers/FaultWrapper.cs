using System;

namespace Common.Helpers
{
    public class FaultWrapper
    {
        private FaultWrapper()
        { }

        public static T Do<T>(Func<T> action)
        {
            var result = default(T);
            
            try { result = action(); }
            catch { /*Ignore exceptions*/ }

            return result;
        }
    }
}