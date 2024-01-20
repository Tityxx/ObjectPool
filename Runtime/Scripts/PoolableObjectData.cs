using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.ObjectPool
{
    /// <summary>
    /// Данные объекта для пула
    /// </summary>
    [CreateAssetMenu(menuName = "ToolsAndMechanics/Object Pool/Poolable Object Data", fileName = "New ObjectData")]
    public class PoolableObjectData : ScriptableObject
    {
        public GameObject Prefab => _prefab;

        [SerializeField] private GameObject _prefab;
    }
}