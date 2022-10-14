using UnityEngine;

namespace UnityComponents.Common
{
    [CreateAssetMenu(menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        [Header("Player")]
        public GameObject PlayerPrefab;

        [Header("Coins And Thorns")]
        public GameObject CoinPrefab;
        public int CoinsNumber;
        public GameObject ThornPrefab;
        public int ThornsNumber;
    }
}
