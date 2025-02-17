using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SOAPlus.Core
{
    public abstract class BaseEvent<T> : ScriptableObject
    {
        [FormerlySerializedAs("OnEventRaised")]
        public UnityEvent<T> onEventRaised = new UnityEvent<T>();

        // Event for value changes
        public event Action<T> OnValueChanged;

        [ContextMenu("Raise")]
        [UsedImplicitly]
        public void Raise(T value)
        {
            onEventRaised.Invoke(value);
            OnValueChanged?.Invoke(value); // Invoke the Action<T> event
        }

        // Subscribe to the Action<T> event
        public void Subscribe(Action<T> callback) => OnValueChanged += callback;

        // Unsubscribe from the Action<T> event
        public void Unsubscribe(Action<T> callback) => OnValueChanged -= callback;
    }
}
