using ScriptableEventSystem.Scripts.Core;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEventSystem.Scripts.Interfaces
{
    public abstract class ScriptableEventListener : MonoBehaviour
    {
        [SerializeField] protected ScriptableEvent scriptableEvent;
        [SerializeField] protected UnityEvent unityEvent;

        private void Awake() => scriptableEvent.Register(this);

        private void OnDestroy() => scriptableEvent.Deregister(this);

        public abstract void RaiseEvent();
    }
}
