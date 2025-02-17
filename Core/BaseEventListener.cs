using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SOAPlus.Core
{
    public abstract class BaseListener<T> : MonoBehaviour
    {
        [FormerlySerializedAs("_event")]
        [SerializeField] private BaseEvent<T> @event = null!;
        [SerializeField] private UnityEvent<T> onEventRaised = null!;

        private void OnEnable()
        {
            if (@event != null)
            {
                @event.Subscribe(OnValueChanged);
                if (@event is BaseVariable<T> variable)
                {
                    OnValueChanged(variable.Value);
                }
            }
        }

        private void OnDisable()
        {
            if (@event != null)
            {
                @event.Unsubscribe(OnValueChanged);
            }
        }

        private void OnValueChanged(T value) => onEventRaised?.Invoke(value);
    }
}
