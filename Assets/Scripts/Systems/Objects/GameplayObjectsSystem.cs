using UI;
using UnityComponents.Common;

namespace Systems.GameplayObjects
{
    public class GameplayObjectsSystem
    {
        private int _coinsCounter;
        private int _maxCoins;
        private UIControl _uiControl;

        public GameplayObjectsSystem(int coinsCounter, UIControl uIControl)
        {
            _maxCoins = coinsCounter;
            _coinsCounter = 0;
            _uiControl = uIControl;
        }

        public void OnGameplayObjectTrgger(int code)
        {
            if (code == 0) OnCoinTrigger();
            else OnThornTrigger();
        }

        private void OnCoinTrigger()
        {
            _coinsCounter++;
            _uiControl.UpdateCounter(_coinsCounter);
            if (_coinsCounter == _maxCoins) EventManager.TriggerEvent(EventManager.EVENTS.win);
        }

        public void OnThornTrigger()
        {
            EventManager.TriggerEvent(EventManager.EVENTS.lose);
        }
    }

}

