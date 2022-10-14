using TMPro;
using UnityEngine;

namespace UI
{
    public class OverviewPanelUI : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private TextMeshProUGUI _winnerText;
        [SerializeField] private TextMeshProUGUI _startNewGameText;

        public void OpenStartPanel()
        {
            _panel.SetActive(true);
            _winnerText.gameObject.SetActive(false);
            _startNewGameText.gameObject.SetActive(true);
        }

        public void OpenEndPanel(bool isWinner)
        {
            _panel.SetActive(true);
            _winnerText.gameObject.SetActive(isWinner);
            _startNewGameText.gameObject.SetActive(false);
        }

        public void ClosePanel()
        {
            _panel.gameObject.SetActive(false);
        }

    }
}

