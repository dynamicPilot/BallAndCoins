using System.Collections.Generic;
using Systems.Input;
using UnityEngine;


namespace UnityComponents
{
    public class PathLines : MonoBehaviour, IAddToPath
    {
        private LineRenderer _lineRenderer;
        [SerializeField] private List<Vector3> _points;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _points = new List<Vector3>();
        }

        private void Start()
        {
            AddToPath(Vector2.zero);
        }

        public void AddToPath(Vector2 position)
        {
            _points.Add((Vector3) position);
            _lineRenderer.positionCount = _points.Count;
            _lineRenderer.SetPositions(_points.ToArray());
        }
    }
}

