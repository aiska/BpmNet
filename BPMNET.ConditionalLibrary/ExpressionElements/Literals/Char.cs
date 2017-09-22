using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using BPMNET.Condition.ExpressionElements.Base.Literals;

using BPMNET.Condition.InternalTypes;


namespace BPMNET.Condition.ExpressionElements.Literals
{
    internal class CharLiteralElement : LiteralElement
    {
        private readonly char _myValue;
        public CharLiteralElement(char value)
        {
            _myValue = value;
        }

        public override void Emit(FleeILGenerator ilg, IServiceProvider services)
        {
            int intValue = Convert.ToInt32(_myValue);
            EmitLoad(intValue, ilg);
        }

        public override System.Type ResultType => typeof(char);
    }
}
