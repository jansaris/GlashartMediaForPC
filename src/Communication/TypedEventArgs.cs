using System;

namespace Communication
{
    public class TypedEventArgs<T> : EventArgs
    {
        public T Data { get; private set; }
        public TypedEventArgs(T data)
        {
            Data = data;
        } 
    }
}