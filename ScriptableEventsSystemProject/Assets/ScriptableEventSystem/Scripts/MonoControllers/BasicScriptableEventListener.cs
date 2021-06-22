using ScriptableEventSystem.Scripts.Core;

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
