using NUnit.Framework;
using ScriptableEventSystem.Scripts.Core;
using UnityEngine;

namespace ScriptableEventSystem.Scripts.Tests.Editor
{
    public class ScriptableEventEditModeTest
    {
        private GameObject _testObject;
        private ScriptableEvent _testEvent;
        private MockScriptableEventListener _mockListener;
        
        [SetUp]
        public void InitializeScene()
        {
            _testObject = new GameObject();
            _testEvent = ScriptableObject.CreateInstance<ScriptableEvent>();
             _mockListener = _testObject.AddComponent<MockScriptableEventListener>();
             
            _mockListener.SetScriptableEvent(_testEvent);
            _mockListener.RegisterEvent();
        }

        [TearDown]
        public void CleanScene()
        {
            Object.DestroyImmediate(_testObject);
        }

        [Test]
        public void Invoke_WhenCalled_RaisesEventFromListener()
        {
            _testEvent.Invoke();
        
            Assert.AreEqual(1, _mockListener.eventsRaised);
        }
        
        [Test]
        public void Invoke_WhenCalledMultipleTimes_RaisesEventsFromListener()
        {
            var numberOfEvents = Random.Range(1, 10);

            InvokeEvents(numberOfEvents);
        
            Assert.AreEqual(numberOfEvents, _mockListener.eventsRaised);
        }

        private void InvokeEvents(int numberOfEvents)
        {
            for (int i = 0; i < numberOfEvents; i++)
            {
                _testEvent.Invoke();                
            }
        }

        private class MockScriptableEventListener : ScriptableEventListener
        {
            public int eventsRaised = 0;
        
            public override void RaiseEvent()
            {
                eventsRaised += 1;
            }
        
            public void SetScriptableEvent(ScriptableEvent newEvent)
            {
                this.scriptableEvent = newEvent;
            }

            public void RegisterEvent()
            {
                scriptableEvent.Register(this);
            }
        }
    }
}
