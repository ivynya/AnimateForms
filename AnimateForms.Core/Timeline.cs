using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimateForms.Animate
{
    public class Timeline
    {
        private readonly List<ToRun> _queue = new List<ToRun>();

        internal struct ToRun
        {
            internal Func<Task<bool>> func;
            internal bool shouldAwait;
        }

        public void Add(Func<Task<bool>> func, bool shouldAwait = true)
        {
            _queue.Add(new ToRun
            {
                func = func,
                shouldAwait = shouldAwait
            });
        }

        public void Remove(int index)
        {
            _queue.RemoveAt(index);
        }

        public void Remove(int index, int count)
        {
            _queue.RemoveRange(index, count);
        }

        public async Task Execute(bool discardAfterRun = false)
        {
            foreach (ToRun action in _queue)
            {
                if (action.shouldAwait)
                    await action.func.Invoke();
                else
                    _ = action.func.Invoke();

                if (discardAfterRun) _queue.Remove(action);
            }
        }
    }
}
