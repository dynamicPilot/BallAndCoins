using System.Collections;
using UnityComponents.Common;
using UnityEngine;


namespace UnityComponents.Players
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BlinkingDeathEffect : MonoBehaviour
    {        
        [SerializeField] private Color _deathColor;
        [SerializeField] private int _numberOfTimes;

        private SpriteRenderer _renderer;
        private Color _defaultColor;
        WaitForSeconds _timer;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _timer = new WaitForSeconds(2f / (_numberOfTimes * 2));
            _defaultColor = _renderer.color;
        }

        private void OnEnable()
        {
            EventManager.StartListening(EventManager.EVENTS.lose, StartDeathEffect);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventManager.EVENTS.lose, StartDeathEffect);
        }

        private void StartDeathEffect()
        {
            StartCoroutine(DeathEffect());
        }

        private IEnumerator DeathEffect()
        {
            int counter = _numberOfTimes;
            _renderer.color = _deathColor;
            while (_numberOfTimes > 0)
            {
                _renderer.enabled = !_renderer.enabled;
                yield return _timer;
            }

            _renderer.enabled = true;
            _renderer.color = _defaultColor;

        }
    }
}

