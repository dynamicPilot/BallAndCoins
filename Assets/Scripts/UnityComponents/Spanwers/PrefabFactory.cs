using Systems.Spawners;
using UnityEngine;

namespace UnityComponents.Spawners
{
    public interface ISpawn
    {
        public void Spawn(PrefabToSpawn prefab);
    }

    public class PrefabFactory : MonoBehaviour, ISpawn
    {
        public void Spawn(PrefabToSpawn prefab)
        {
            //Debug.Log("PrefabFactory: spawn prefab");
            Instantiate(prefab.Prefab, prefab.Position, Quaternion.identity, prefab.Parent);
        }

    }
}

