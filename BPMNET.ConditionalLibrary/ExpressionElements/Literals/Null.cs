using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using BPMNET.Condition.ExpressionElements.Base.Literals;
using BPMNET.Condition.ExpressionElements.Literals;
using BPMNET.Condition.InternalTypes;

namespace BPMNET.Condition.ExpressionElements.Literals
{
    internal class NullLiteralElement : LiteralElement
    {
        public override void Emit(FleeILGenerator ilg, IServiceProvider services)
        {
            ilg.Emit(OpCodes.Ldnull);
        }

        public override System.Type ResultType => typeof(Null);
    }
}
