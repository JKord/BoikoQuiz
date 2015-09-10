using System;
using System.Collections.Generic;

namespace BoikoQuiz.Core.Event
{
    public class DBEventArgs<T> : EventArgs
    {
        public List<T> Result { get; set; }
    }
}