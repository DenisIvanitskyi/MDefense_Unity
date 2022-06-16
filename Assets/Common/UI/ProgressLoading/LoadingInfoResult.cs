using System;
using System.Collections.Generic;

namespace Assets.Common.UI.ProgressLoading
{
    public class LoadingInfoResult
    {
        public LoadingInfoResult(List<Exception> exceptions)
        {
            if(exceptions != null || exceptions.Count > 0)
                Exceptions = new List<Exception>(exceptions);
        }

        public IReadOnlyList<Exception> Exceptions { get; }

        public bool IsSuccess => Exceptions == null || Exceptions.Count == 0;

    }
}
