using ScriptableEventSystem.Scripts.Core;
using ScriptableEventSystem.Scripts.Interfaces;
using UnityEngine;

namespace ScriptableEventSystem.Scripts.MonoControllers
{
    public class EventFollowupScriptableEventListener : ScriptableEventListener
    {
        [SerializeField] private ScriptableEvent followupEvent;
    
        public override void RaiseEvent()
        {
            unityEvent.Invoke();
            followupEvent.Invoke();
        }
    }
}
