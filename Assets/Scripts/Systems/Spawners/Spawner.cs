using System.Collections;
using System.Collections.Generic;
using UnityComponents.Common;
using UnityComponents.Spawners;
using UnityEngine;

namespace Systems.Spawners
{
    public static class Spawner
    {
        public static void SpawnPrefab(ISpawn factory, PrefabToSpawn prefab)
        {
            factory.Spawn(prefab);
        }
    }
}

