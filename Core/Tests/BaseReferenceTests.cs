using NUnit.Framework;
using UnityEngine;

namespace SOAPlus.Core.Tests
{
    public class BaseReferenceTests : BaseSetup
    {
        [TestCase(42)]
        [TestCase(0)]
        [TestCase(-1)]
        public void WhenUsingConstant_IntValue_ShouldReturnConstantValue(int value)
        {
            var reference = new TestIntReference { useConstant = true, constantValue = value };
            Assert.That(reference.Value, Is.EqualTo(value));
        }

        [TestCase("test")]
        [TestCase("")]
        [TestCase(null)]
        public void WhenUsingConstant_StringValue_ShouldReturnConstantValue(string value)
        {
            var reference = new TestStringReference { useConstant = true, constantValue = value };
            Assert.That(reference.Value, Is.EqualTo(value));
        }

        private static readonly Vector3[] _vector3Cases = {
                    new Vector3(1, 2, 3),
                    Vector3.zero,
                    Vector3.one
                };

        [TestCaseSource(nameof(_vector3Cases))]
        public void WhenUsingConstant_Vector3Value_ShouldReturnConstantValue(Vector3 value)
        {
            var reference = new TestVector3Reference { useConstant = true, constantValue = value };
            Assert.That(reference.Value, Is.EqualTo(value));
        }

        [TestCase(42)]
        [TestCase(0)]
        [TestCase(-1)]
        public void WhenUsingVariable_IntValue_ShouldReturnVariableValue(int value)
        {
            var variable = ScriptableObject.CreateInstance<TestIntVariable>();
            variable.Value = value;
            var reference = new TestIntReference { useConstant = false, variable = variable };
            Assert.That(reference.Value, Is.EqualTo(value));
        }
    }
}
