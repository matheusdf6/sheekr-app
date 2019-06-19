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
        public IDictionary<string, object> Extras { get; set; }

        public void Sucess()
        {
            IsSucceed = true;
        }
        public void AddFailure(string failure, Exception exception = null)
        {
            if (Errors == null)
                Errors = new Dictionary<string, object>();
            Errors.Add(failure, (exception != null) ? new { Name = exception.GetType().FullName, exception.Message } : null);

            IsSucceed = false;
        }

        public void AddExtra(string key, object value)
        {
            if (Extras == null)
                Extras = new Dictionary<string, object>();
            Extras.Add(key, value);
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
