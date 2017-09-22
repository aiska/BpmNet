using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using BPMNET.Condition.ExpressionElements.Base.Literals;

using BPMNET.Condition.InternalTypes;

namespace BPMNET.Condition.ExpressionElements.Literals
{
    internal class BooleanLiteralElement : LiteralElement
    {
        private readonly bool _myValue;
        public BooleanLiteralElement(bool value)
        {
            _myValue = value;
        }

        public override void Emit(FleeILGenerator ilg, IServiceProvider services)
        {
            EmitLoad(_myValue, ilg);
        }

        public override System.Type ResultType => typeof(bool);
    }
}
