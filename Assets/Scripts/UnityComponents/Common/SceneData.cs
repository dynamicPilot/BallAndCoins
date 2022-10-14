using UI;
using UnityComponents.Input;
using UnityComponents.Spawners;
using UnityEngine;

namespace UnityComponents.Common
{
    public class SceneData : MonoBehaviour
    {
        [Header("Factories")]
        public PrefabFactory Factory;

        [Header("Inputs")]
        public InputContols InputContols;
        public PathLines PathLines;

        [Header("UI")]
        public UIControl UIControl;

        [Header("Parent Objects")]
        public Transform CoinsParent;
        public Transform ThornsParent;
    }
}

