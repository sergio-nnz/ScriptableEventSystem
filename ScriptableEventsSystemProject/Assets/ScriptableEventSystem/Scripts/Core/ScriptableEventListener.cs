using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEventSystem.Scripts.Core
{
    public class ScriptableEventListener : MonoBehaviour
    {
        [SerializeField] protected ScriptableEvent scriptableEvent;
        [SerializeField] protected UnityEvent unityEvent;

        private void Awake() => scriptableEvent.Register(this);

        private void OnDestroy() => scriptableEvent.Deregister(this);

        public virtual void RaiseEvent() => unityEvent.Invoke();
    }
}