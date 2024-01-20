using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.ObjectPool
{
    /// <summary>
    /// Source: https://gitlab.com/syhodyb99/tools-and-mechanics
    /// Контроллер пула объектов
    /// </summary>
    public class ObjectPool : IObjectPool
    {
        [Inject] private IInstantiator _instantiator;

        private Dictionary<PoolableObjectData, Queue<GameObject>> _queue = new Dictionary<PoolableObjectData, Queue<GameObject>>();

        public GameObject GetObject(PoolableObjectData data, bool active = true, Transform parent = null)
        {
            GameObject go = CreateObject(data);           

            go.transform.SetParent(parent);
            go.SetActive(active);

            return go;
        }

        public GameObject GetObject(PoolableObjectData data, Vector3 position, bool isGlobal, bool active = true, Transform parent = null)
        {
            var go = GetObject(data, false, parent);

            if (isGlobal) go.transform.position = position;
            else go.transform.localPosition = position;

            go.SetActive(active);

            return go;
        }

        public GameObject GetObject(PoolableObjectData data, Vector3 position, bool isGlobalPosition, Vector3 eulerAngles, bool isGlobalRotation, bool active = true, Transform parent = null)
        {
            var go = GetObject(data, false, parent);

            if (isGlobalPosition) go.transform.position = position;
            else go.transform.localPosition = position;
            if (isGlobalRotation) go.transform.eulerAngles = eulerAngles;
            else go.transform.localEulerAngles = eulerAngles;

            go.SetActive(active);
            return go;
        }

        public void ReturnObject(GameObject go)
        {
            go.SetActive(false);
            go.transform.SetParent(null);

            if (go.TryGetComponent(out PoolableObjectInfo info))
            {
                if (_queue.ContainsKey(info.Data))
                {
                    if (!_queue[info.Data].Contains(go))
                        _queue[info.Data].Enqueue(go);
                }
                else
                {
                    _queue.Add(info.Data, new Queue<GameObject>(new[] { go }));
                }
            }
        }

        private GameObject CreateObject(PoolableObjectData data)
        {
            GameObject go;

            if (_queue.ContainsKey(data))
            {
                if (_queue[data].Count > 0)
                {
                    go = _queue[data].Dequeue();
                }
                else
                {
                    go = _instantiator.InstantiatePrefab(data.Prefab);
                    AddInfoComponent(data, go);
                }
            }
            else
            {
                _queue.Add(data, new Queue<GameObject>());
                go = _instantiator.InstantiatePrefab(data.Prefab);
                AddInfoComponent(data, go);
            }

            return go;
        }

        private void AddInfoComponent(PoolableObjectData data, GameObject go)
        {
            go.AddComponent<PoolableObjectInfo>().Data = data;
        }
    }
}