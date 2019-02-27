using System;
using System.Collections.Generic;
using System.Text;

namespace Sheekr.Application
{
    public class RequestInfo
    {
        public bool IsSucceed { get; set; }
        //public IList<string> Failures { get; set; }
        //public IList<Exception> Exceptions { get; set; }

        public IDictionary<string, object> Errors { get; set; }

        public void Sucess()
        {
            IsSucceed = true;
        }
        public void AddFailure(string failure, Exception exception = null)
        {
            /*
            if (Failures == null)
                Failures = new List<string>();
            Failures.Add(failure);

            if(exception != null)
            {
                if (Exceptions == null)
                    Exceptions = new List<Exception>();
                Exceptions.Add(exception);
            }*/

            if (Errors == null)
                Errors = new Dictionary<string, object>();
            Errors.Add(failure, (exception!=null) ? new { Name = exception.GetType().FullName, exception.Message} : null);

            IsSucceed = false;            
        }
    }

    public class RequestInfo<TResponse> : RequestInfo
    {
        public TResponse Response { get; set; }

        public void AddResponde(TResponse response)
        {
            this.Response = response;
        }
    }
}
