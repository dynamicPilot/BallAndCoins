using Systems.Input;
using UnityComponents.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityComponents.Input
{

    public class InputContols : MonoBehaviour, IClick
    {
        private Controllers _controllers;
        private Camera _mainCamera;

        public event IClick.Click OnClick;

        private void Awake()
        {
            _controllers = new Controllers();
            _mainCamera = Camera.main;
        }

        private void Start()
        {
            _controllers.Player.Click.performed += ctx => MakeClick(ctx);
        }

        private void OnEnable()
        {
            StartControls();
        }

        private void OnDisable()
        {
            EndControls();
        }

        private void StartControls()
        {
            _controllers.Enable();
        }

        private void EndControls()
        {
            _controllers.Disable();
        }

        private void MakeClick(InputAction.CallbackContext ctx)
        {
            Vector2 position = _mainCamera.ScreenToWorldPoint(_controllers.Player.Point.ReadValue<Vector2>());
            if (OnClick != null) OnClick.Invoke(position);
        }

    }
}

