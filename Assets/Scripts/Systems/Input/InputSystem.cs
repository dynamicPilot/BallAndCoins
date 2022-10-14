using System.Drawing;
using UnityComponents.Common;
using UnityComponents.Input;
using UnityEngine;

namespace Systems.Input
{
    public interface IClick
    {
        public delegate void Click(Vector2 position);
        public event Click OnClick;
    }

    public interface IAddToPath
    {
        public abstract void AddToPath(Vector2 point);
    }

    public class InputSystem : IManager
    {
        private IClick _inputControls;
        private IAddToPath[] _addToPath;

        public InputSystem(SceneData sceneData, IAddToPath[] addToPath)
        {
            _inputControls = sceneData.InputContols;
            _addToPath = addToPath;
        }

        public void OnStart()
        {
            _inputControls.OnClick += OnClick;
        }

        public void OnStop()
        {
            _inputControls.OnClick -= OnClick;
        }

        public void OnClick(Vector2 position)
        {
            for (int i = 0; i < _addToPath.Length; i++)
                _addToPath[i].AddToPath(position);
        }
    }
}
