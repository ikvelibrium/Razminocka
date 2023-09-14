using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPull
{
    public class PullBase<T>
    {
        private Func<T> _preloadFunc;
        private Action<T> _getAction;
        private Action<T> _returnAction;        
        private Queue<T> _queue = new Queue<T>();
        private List<T> _activeObjects = new List<T>();

        public PullBase(Func<T> preloadFunc, Action<T> getAction, Action<T> returnAction, int preloadCount) 
        { 
            _preloadFunc = preloadFunc;
            _getAction = getAction;
            _returnAction = returnAction;
            
            if (preloadFunc == null)
            {
                return;
            }

            for (int i = 0; i < preloadCount; i++)
            {
                Return(preloadFunc());
            }
        }

        public T Get()
        {
            T item = _queue.Count > 0 ? _queue.Dequeue() : _preloadFunc();
            _getAction(item);
            return item;
        }

        public void Return(T item)
        {
            _returnAction(item);
            _queue.Enqueue(item);
        }

        public void ReturnAll()
        {
            foreach (T item in _activeObjects.ToArray())
            {
                Return(item);
            }
        }
    }
}
