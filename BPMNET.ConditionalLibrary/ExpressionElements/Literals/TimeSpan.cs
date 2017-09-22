using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Globalization;
using BPMNET.Condition.ExpressionElements.Base.Literals;
using BPMNET.Condition.InternalTypes;
using BPMNET.Condition.PublicTypes;
using BPMNET.Condition.Resources;

namespace BPMNET.Condition.ExpressionElements.Literals
{
    internal class TimeSpanLiteralElement : LiteralElement
    {
        private TimeSpan _myValue;
        public TimeSpanLiteralElement(string image)
        {
            if (TimeSpan.TryParse(image, out _myValue) == false)
            {
                base.ThrowCompileException(CompileErrorResourceKeys.CannotParseType, CompileExceptionReason.InvalidFormat, typeof(TimeSpan).Name);
            }
        }

        public override void Emit(FleeILGenerator ilg, System.IServiceProvider services)
        {
            int index = ilg.GetTempLocalIndex(typeof(TimeSpan));

            Utility.EmitLoadLocalAddress(ilg, index);

            LiteralElement.EmitLoad(_myValue.Ticks, ilg);

            ConstructorInfo ci = typeof(TimeSpan).GetConstructor(new Type[] { typeof(long) });

            ilg.Emit(OpCodes.Call, ci);

            Utility.EmitLoadLocal(ilg, index);
        }

        public override System.Type ResultType => typeof(TimeSpan);
    }
}
