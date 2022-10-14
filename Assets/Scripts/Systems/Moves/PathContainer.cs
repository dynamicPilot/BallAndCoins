using System.Collections.Generic;
using Systems.Input;
using UnityComponents.Common;
using UnityEngine;


namespace Systems.Moves
{
    public class PathContainer : IAddToPath
    {
        private Queue<Vector2> _queue;

        public PathContainer()
        {
            _queue = new Queue<Vector2>();
        }

        public void AddToPath(Vector2 point)
        {
            _queue.Enqueue(point);
            EventManager.TriggerEvent(EventManager.EVENTS.addPoint);
        }

        public KeyValuePair<bool, Vector2> GetNextPoint()
        {
            if (_queue.Count == 0) return new KeyValuePair<bool, Vector2> (false, Vector2.zero);
            else return new KeyValuePair<bool, Vector2>(true, _queue.Dequeue());
        }
    }
}

