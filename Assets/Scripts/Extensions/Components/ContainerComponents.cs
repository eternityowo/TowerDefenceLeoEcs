using System.Collections.Generic;
using TowerDefenceLeoEcs.Pooling;

namespace TowerDefenceLeoEcs.Extensions.Components
{
    internal struct ContainerComponents<T> 
        where T : struct
    {
        public List<T> List => _list ?? (_list = new List<T>());
        private List<T> _list;
    }

    internal struct ContainerStack<T>
    where T : struct
    {
        public FastStack<T> Stack => _stack ?? (_stack = new FastStack<T>());
        private FastStack<T> _stack;
    }

    internal struct ContainerQueue<T>
    where T : struct
    {
        public Queue<T> Queue => _queue ?? (_queue = new Queue<T>());
        private Queue<T> _queue;
    }
}