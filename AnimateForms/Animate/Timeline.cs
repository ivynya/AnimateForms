using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimateForms.Animate
{
    public class Timeline
    {
        private readonly List<Func<Task<bool>>> _queue = new List<Func<Task<bool>>>();

        public void Add(Func<Task<bool>> func)
        {
            _queue.Add(func);
        }

        public void Remove(int index)
        {
            _queue.RemoveAt(index);
        }

        public void Remove(int index, int count)
        {
            _queue.RemoveRange(index, count);
        }

        public async Task Execute()
        {
            for (int i = 0; i < _queue.Count; i++)
                await _queue[i].Invoke();
        }
    }
}
