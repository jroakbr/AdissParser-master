using System;

namespace Gldd.AdissParser
{
    public static class ExceptionExtensions
    {
        public static Exception GetInnerMostException(this Exception exception)
        {
            //https://stackoverflow.com/questions/3876456/find-the-inner-most-exception-without-using-a-while-loop
            while (exception.InnerException != null)
                exception = exception.InnerException;

            return exception;
        }
    }
}
