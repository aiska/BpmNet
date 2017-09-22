using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using BPMNET.Condition.Parsing.grammatica_1._5.alpha2.PerCederberg.Grammatica.Runtime;
using BPMNET.Condition.PublicTypes;

namespace BPMNET.Condition.Parsing
{
    internal abstract class CustomTokenPattern : TokenPattern
    {
        protected CustomTokenPattern(int id, string name, PatternType type, string pattern) : base(id, name, type, pattern)
        {
        }

        public void Initialize(int id, string name, PatternType type, string pattern, ExpressionContext context)
        {
            this.ComputeToken(id, name, type, pattern, context);
        }

        protected abstract void ComputeToken(int id, string name, PatternType type, string pattern, ExpressionContext context);
    }

    internal class RealPattern : CustomTokenPattern
    {
        public RealPattern(int id, string name, PatternType type, string pattern) : base(id, name, type, pattern)
        {
        }

        protected override void ComputeToken(int id, string name, PatternType type, string pattern, ExpressionContext context)
        {
            ExpressionParserOptions options = context.ParserOptions;

            char digitsBeforePattern = (options.RequireDigitsBeforeDecimalPoint ? '+' : '*');

            pattern = string.Format(pattern, digitsBeforePattern, options.DecimalSeparator);

            this.SetData(id, name, type, pattern);
        }
    }

    internal class ArgumentSeparatorPattern : CustomTokenPattern
    {
        public ArgumentSeparatorPattern(int id, string name, PatternType type, string pattern) : base(id, name, type, pattern)
        {
        }

        protected override void ComputeToken(int id, string name, PatternType type, string pattern, ExpressionContext context)
        {
            ExpressionParserOptions options = context.ParserOptions;
            this.SetData(id, name, type, options.FunctionArgumentSeparator.ToString());
        }
    }
}
