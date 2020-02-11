using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TextGenerator
{
    public class CharWrapper : IDisposable
    {
        private static readonly ConcurrentStack<CharWrapper> Stack = new ConcurrentStack<CharWrapper>();

        public static CharWrapper Create(char c)
        {
            if (Stack.Count > 0 && Stack.TryPop(out var cw))
                return cw.Set(c);
            else
                return new CharWrapper(c);
        }
        
        public char Value { get; private set; }
        private CharWrapper(char value)
        {
            Value = value;
        }

        private CharWrapper Set(char c)
        {
            Value = c;
            return this;
        }


        public void Dispose()
        {
            Stack.Push(this);
        }
    }
}