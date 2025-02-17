using SOAPlus.Core;
using UnityEngine;

namespace SOAPlus.Builtin.DotNetTypes
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "SOAPlus/Builtin/StringVariable")]
    public class StringVariable : BaseVariable<string>
    {
        public StringVariable() : base("") { }
    }
}