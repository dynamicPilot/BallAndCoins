using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UnityComponents.Common
{
    [DefaultExecutionOrder(-1)]
    public class EventManager : MonoBehaviour
    {
        public enum EVENTS { start, restart, lose, win, addPoint }
        private Dictionary<EVENTS, UnityEvent> _eventDictionary;

        private static EventManager _eventManager;

        public static EventManager instance
        {
            get
            {
                if (!_eventManager)
                {
                    _eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                    if (!_eventManager)
                    {
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                    }
                    else
                    {
                        _eventManager.Init();
                    }
                }

                return _eventManager;
            }
        }

        void Init()
        {
            if (_eventDictionary == null)
            {
                _eventDictionary = new Dictionary<EVENTS, UnityEvent>();
            }
        }

        public static void StartListening(EVENTS eventName, UnityAction listener)
        {
            UnityEvent thisEvent = null;
            if (instance._eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                instance._eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(EVENTS eventName, UnityAction listener)
        {
            if (_eventManager == null) return;
            UnityEvent thisEvent = null;
            if (instance._eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void TriggerEvent(EVENTS eventName)
        {
            UnityEvent thisEvent = null;
            if (instance._eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}
