using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.ObjectPool
{
    [CreateAssetMenu(menuName = "ToolsAndMechanics/Object Pool/Installer")]
    public class ObjectPoolInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IObjectPool>().To<ObjectPool>().AsSingle();
        }
    }
}