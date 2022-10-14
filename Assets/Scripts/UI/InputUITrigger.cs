using UnityComponents.Common;
using UnityEngine;

namespace UI
{
    public enum MODE { end, game, start }
    public class InputUITrigger : MonoBehaviour
    {
        private MODE _mode;
        private void Awake()
        {
            _mode = MODE.start;
        }

        public void PressStartButton()
        {
            if (_mode == MODE.game) RestartGameTrigger();
            else StartGameTrigger();
        }
        public void StartGameTrigger()
        {
            EventManager.TriggerEvent(EventManager.EVENTS.start);
            _mode = MODE.game;
        }

        public void RestartGameTrigger()
        {
            EventManager.TriggerEvent(EventManager.EVENTS.restart);
            _mode = MODE.start;
        }
    }
}
