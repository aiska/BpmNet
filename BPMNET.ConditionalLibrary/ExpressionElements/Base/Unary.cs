using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using BPMNET.Condition.ExpressionElements.Base;
using BPMNET.Condition.PublicTypes;
using BPMNET.Condition.Resources;

namespace BPMNET.Condition.ExpressionElements.Base
{
    internal abstract class UnaryElement : ExpressionElement
    {

        protected ExpressionElement MyChild;

        private Type _myResultType;
        public void SetChild(ExpressionElement child)
        {
            MyChild = child;
            _myResultType = this.GetResultType(child.ResultType);

            if (_myResultType == null)
            {
                base.ThrowCompileException(CompileErrorResourceKeys.OperationNotDefinedForType, CompileExceptionReason.TypeMismatch, MyChild.ResultType.Name);
            }
        }

        protected abstract Type GetResultType(Type childType);

        public override System.Type ResultType => _myResultType;
    }

}
