using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.ObjectPool
{
    /// <summary>
    /// Возврат объекта в пул
    /// </summary>
    public class ObjectReturnerAtPool : MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 1f;

        [Inject] private IObjectPool _pool;

        private void OnEnable()
        {
            StartCoroutine(RemoveObjectWithDelay());
        }

        private IEnumerator RemoveObjectWithDelay()
        {
            yield return new WaitForSeconds(_lifeTime);
            _pool.ReturnObject(gameObject);
        }
    }
}