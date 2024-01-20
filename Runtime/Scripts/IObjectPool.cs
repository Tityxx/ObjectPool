using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.ObjectPool
{
    public interface IObjectPool
    {
        /// <summary>
        /// Получить объект из пула
        /// </summary>
        public GameObject GetObject(PoolableObjectData data, bool active = true, Transform parent = null);

        /// <summary>
        /// Получить объект из пула с указанной позицией
        /// </summary>
        public GameObject GetObject(PoolableObjectData data, Vector3 position, bool isGlobal, bool active = true, Transform parent = null);

        /// <summary>
        /// Получить объект из пула с указанной позицией и поворотом
        /// </summary>
        public GameObject GetObject(PoolableObjectData data, Vector3 position, bool isGlobalPosition, Vector3 eulerAngles, bool isGlobalRotation, bool active = true, Transform parent = null);

        /// <summary>
        /// Вернуть объект в пул
        /// </summary>
        public void ReturnObject(GameObject go);
    }
}