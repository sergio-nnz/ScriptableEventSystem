using System.Collections.Generic;
using UnityEngine;

namespace ScriptableEventSystem.Scripts.Core
{
    [CreateAssetMenu(menuName = "Scriptable Event", fileName = "New scriptable event")]
    public class ScriptableEvent : ScriptableObject
    {
        HashSet<ScriptableEventListener> _listeners = new HashSet<ScriptableEventListener>();

        public void Invoke()
        {
            foreach (var listener in _listeners)
            {
                listener.RaiseEvent();
            }
        }

        public void Register(ScriptableEventListener scriptableEventListener) => _listeners.Add(scriptableEventListener);
        
        public void Deregister(ScriptableEventListener scriptableEventListener) => _listeners.Remove(scriptableEventListener);
    }
}
