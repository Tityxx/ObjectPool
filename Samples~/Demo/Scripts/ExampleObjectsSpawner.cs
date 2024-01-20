using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.ObjectPool
{
    /// <summary>
    /// Пример спавна объектов
    /// </summary>
    public class ExampleObjectsSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay = 0.2f;

        [SerializeField] private PoolableObjectData[] _datas;
        [SerializeField] private Transform[] _positions;

        [Inject] private IObjectPool _pool;

        private IEnumerator Start()
        {
            while (enabled)
            {
                for (int i = 0; i < _datas.Length; i++)
                {
                    _pool.GetObject(_datas[i], _positions[i].position, true);
                }
                yield return new WaitForSeconds(_spawnDelay);
            }
        }
    }
}