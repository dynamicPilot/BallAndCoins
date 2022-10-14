using UnityComponents.Common;
using UnityEngine;

namespace UnityComponents.Objects
{
    public class GameplayObject : MonoBehaviour
    {
        [SerializeField] private int _code;
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                GameManager.Instance.ObjectsSystem.OnGameplayObjectTrgger(_code);
            }
        }
    }
}

