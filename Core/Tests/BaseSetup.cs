using UnityEngine;

namespace SOAPlus.Core.Tests
{
    public class BaseSetup
    {
        protected class TestIntVariable : BaseVariable<int>
        {
            public TestIntVariable() : base(0) { }
        }

        protected class TestStringVariable : BaseVariable<string>
        {
            public TestStringVariable() : base("") { }
        }

        protected class TestVector3Variable : BaseVariable<Vector3>
        {
            public TestVector3Variable() : base(Vector3.zero) { }
        }

        protected class TestIntEvent : BaseEvent<int> { }
        protected class TestStringEvent : BaseEvent<string> { }
        protected class TestVector3Event : BaseEvent<Vector3> { }

        protected class TestIntReference : BaseReference<int, TestIntVariable> { }
        protected class TestStringReference : BaseReference<string, TestStringVariable> { }
        protected class TestVector3Reference : BaseReference<Vector3, TestVector3Variable> { }
    }
}
