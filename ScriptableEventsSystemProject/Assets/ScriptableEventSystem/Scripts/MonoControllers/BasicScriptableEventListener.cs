using ScriptableEventSystem.Scripts.Core;
using ScriptableEventSystem.Scripts.Interfaces;

namespace ScriptableEventSystem.Scripts.MonoControllers
{
    public class BasicScriptableEventListener : ScriptableEventListener
    {
        public override void RaiseEvent()
        {
            unityEvent.Invoke();
        }
    }
}
