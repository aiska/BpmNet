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
    internal class DateTimeLiteralElement : LiteralElement
    {
        private DateTime _myValue;
        public DateTimeLiteralElement(string image, ExpressionContext context)
        {
            ExpressionParserOptions options = context.ParserOptions;

            if (DateTime.TryParseExact(image, options.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _myValue) == false)
            {
                base.ThrowCompileException(CompileErrorResourceKeys.CannotParseType, CompileExceptionReason.InvalidFormat, typeof(DateTime).Name);
            }
        }

        public override void Emit(FleeILGenerator ilg, IServiceProvider services)
        {
            int index = ilg.GetTempLocalIndex(typeof(DateTime));

            Utility.EmitLoadLocalAddress(ilg, index);

            LiteralElement.EmitLoad(_myValue.Ticks, ilg);

            ConstructorInfo ci = typeof(DateTime).GetConstructor(new Type[] { typeof(long) });

            ilg.Emit(OpCodes.Call, ci);

            Utility.EmitLoadLocal(ilg, index);
        }

        public override System.Type ResultType => typeof(DateTime);
    }
}
