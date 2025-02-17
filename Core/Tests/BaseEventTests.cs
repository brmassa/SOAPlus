using NUnit.Framework;
using UnityEngine;

namespace SOAPlus.Core.Tests
{
    public class BaseEventTests : BaseSetup
    {
        [TestCase(42)]
        [TestCase(0)]
        [TestCase(-1)]
        public void WhenSubscribed_IntValue_ShouldReceiveValue(int value)
        {
            var testEvent = ScriptableObject.CreateInstance<TestIntEvent>();
            var received = 0;

            testEvent.Subscribe(val => received = val);
            testEvent.Raise(value);

            Assert.That(received, Is.EqualTo(value));
        }

        [TestCase("test")]
        [TestCase("")]
        public void WhenSubscribed_StringValue_ShouldReceiveValue(string value)
        {
            var testEvent = ScriptableObject.CreateInstance<TestStringEvent>();
            var received = "";

            testEvent.Subscribe(val => received = val);
            testEvent.Raise(value);

            Assert.That(received, Is.EqualTo(value));
        }

        private static readonly Vector3[] _vector3Cases = {
                    new Vector3(1, 2, 3),
                    Vector3.zero,
                    Vector3.one
                };

        [TestCaseSource(nameof(_vector3Cases))]
        public void WhenSubscribed_Vector3Value_ShouldReceiveValue(Vector3 value)
        {
            var testEvent = ScriptableObject.CreateInstance<TestVector3Event>();
            var received = Vector3.zero;

            testEvent.Subscribe(val => received = val);
            testEvent.Raise(value);

            Assert.That(received, Is.EqualTo(value));
        }
    }
}
