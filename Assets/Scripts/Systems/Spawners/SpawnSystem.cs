using UnityComponents.Common;
using UnityEngine;

namespace Systems.Spawners
{
    public class SpawnSystem : IManager
    {
        private SceneData _sceneData;
        private StaticData _staticData;

        public SpawnSystem(SceneData sceneData, StaticData staticData)
        {
            _sceneData = sceneData;
            _staticData = staticData;

            SpawnObject(_staticData.CoinsNumber, _staticData.CoinPrefab, _sceneData.CoinsParent);
            SpawnObject(_staticData.ThornsNumber, _staticData.ThornPrefab, _sceneData.ThornsParent);
        }

        public void OnStart()
        {
            SpawnPlayer();
        }

        public void OnStop()
        {

        }

        private void SpawnPlayer()
        {
            PrefabToSpawn player = new PrefabToSpawn
            {
                Prefab = _staticData.PlayerPrefab,
                Position = Vector2.zero,
                Parent = null
            };

            Spawner.SpawnPrefab(_sceneData.Factory, player);
        }

        private void SpawnObject(int number, GameObject prefab, Transform parent)
        {
            for (int i = 0; i < number; i++)
            {
                PrefabToSpawn temp = new PrefabToSpawn
                {
                    Prefab = prefab,
                    Position = GetPosition(),
                    Parent = parent
                };
                Spawner.SpawnPrefab(_sceneData.Factory, temp);
            }
        }

        private Vector2 GetPosition()
        {
            float posX = Camera.main.pixelWidth;
            float posY = Camera.main.pixelHeight;

            return Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(50f, posX-50f), Random.Range(50f, posY - 50f)));
        }
    }
}