using System;
using System.Collections;
using TMPro;
using UnityComponents.Common;
using UnityEngine;

namespace UI
{
    public class UIControl : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counterText;
        [SerializeField] private OverviewPanelUI _overviewPanel;


        private void OnEnable()
        {
            EventManager.StartListening(EventManager.EVENTS.start, StartGame);
            EventManager.StartListening(EventManager.EVENTS.win, WinGame);
            EventManager.StartListening(EventManager.EVENTS.lose, GameOver);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventManager.EVENTS.start, StartGame);
            EventManager.StopListening(EventManager.EVENTS.win, WinGame);
            EventManager.StopListening(EventManager.EVENTS.lose, GameOver);
        }

        private void Awake()
        {
            _overviewPanel.OpenStartPanel();
        }
            

        private void Start()
        {
            _counterText.SetText("---");
        }

        public void UpdateCounter(int number)
        {
            _counterText.SetText(String.Format("{0:D3}", number));
        }

        private void StartGame()
        {
            _overviewPanel.ClosePanel();
        }

        private void WinGame()
        {
            _overviewPanel.OpenEndPanel(true);
        }

        private void GameOver()
        {
            StartCoroutine(GameOverDelay());
        }

        private IEnumerator GameOverDelay()
        {
            yield return new WaitForSeconds(2f);
            _overviewPanel.OpenEndPanel(false);
        }
    }
}

