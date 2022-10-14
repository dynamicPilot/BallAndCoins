using System.Collections.Generic;
using UnityComponents.Common;
using UnityEngine;


namespace UnityComponents.Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovable : MonoBehaviour
    {
        [SerializeField] private float _pushForce = 100f;
        [SerializeField] private float _positionDelta = 0.1f;

        private Rigidbody2D _rigidBody;
        private Vector2 _targetPosition;
        private bool _pauseUpdate = true;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            EventManager.StartListening(EventManager.EVENTS.addPoint, ContinueMoving);
            EventManager.StartListening(EventManager.EVENTS.lose, Stop);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventManager.EVENTS.addPoint, ContinueMoving);
            EventManager.StopListening(EventManager.EVENTS.lose, Stop);
        }

        private void FixedUpdate()
        {
            if (_pauseUpdate) return;

            if (Mathf.Abs(_rigidBody.position.x - _targetPosition.x) < _positionDelta &&
                Mathf.Abs(_rigidBody.position.y - _targetPosition.y) < _positionDelta)
                ReachedTargetPosition();
        }

        private void ContinueMoving()
        {            
            if (TryGetNextPoint())
            {
                EventManager.StopListening(EventManager.EVENTS.addPoint, ContinueMoving);
                Move();
            }                      
        }

        private bool TryGetNextPoint()
        {
            KeyValuePair<bool, Vector2> possibleTarget = GameManager.Instance.PathContainer.GetNextPoint();

            _targetPosition = possibleTarget.Value;
            return possibleTarget.Key;
        }

        private void Move()
        {
            _rigidBody.AddForce((_targetPosition - _rigidBody.position).normalized * _pushForce, ForceMode2D.Impulse);
            _pauseUpdate = false;
        }

        private void ReachedTargetPosition()
        {
            Stop();

            if (TryGetNextPoint()) Move();
            else EventManager.StartListening(EventManager.EVENTS.addPoint, ContinueMoving);
        }

        private void Stop()
        {
            _pauseUpdate = true;
            _rigidBody.velocity = Vector2.zero;
        }
    }

}
