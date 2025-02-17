using NUnit.Framework;
using UnityEngine;

namespace SOAPlus.Core.Tests
{
    public class BaseVariableTests : BaseSetup
    {
        [TestCase(42)]
        [TestCase(0)]
        [TestCase(-1)]
        public void WhenValueChanged_IntValue_ShouldNotifySubscribers(int value)
        {
            var variable = ScriptableObject.CreateInstance<TestIntVariable>();
            var received = 0;

            variable.Subscribe(val => received = val);
            variable.Value = value;

            Assert.That(received, Is.EqualTo(value));
        }

        [TestCase("test")]
        [TestCase("")]
        public void WhenValueChanged_StringValue_ShouldNotifySubscribers(string value)
        {
            var variable = ScriptableObject.CreateInstance<TestStringVariable>();
            var received = "";

            variable.Subscribe(val => received = val);
            variable.Value = value;

            Assert.That(received, Is.EqualTo(value));
        }

        private static readonly Vector3[] _vector3Cases = {
            new Vector3(1, 2, 3),
            Vector3.zero,
            Vector3.one
        };

        [TestCaseSource(nameof(_vector3Cases))]
        public void WhenValueChanged_Vector3Value_ShouldNotifySubscribers(Vector3 value)
        {
            var variable = ScriptableObject.CreateInstance<TestVector3Variable>();
            var received = Vector3.zero;

            variable.Subscribe(val => received = val);
            variable.Value = value;

            Assert.That(received, Is.EqualTo(value));
        }
    }
}
