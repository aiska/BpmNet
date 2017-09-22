using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using BPMNET.Condition.ExpressionElements.Base.Literals;
using BPMNET.Condition.InternalTypes;


namespace BPMNET.Condition.ExpressionElements.Literals
{
    internal class StringLiteralElement : LiteralElement
    {
        private readonly string _myValue;
        public StringLiteralElement(string value)
        {
            _myValue = value;
        }

        public override void Emit(FleeILGenerator ilg, IServiceProvider services)
        {
            ilg.Emit(OpCodes.Ldstr, _myValue);
        }

        public override System.Type ResultType => typeof(string);
    }
}
