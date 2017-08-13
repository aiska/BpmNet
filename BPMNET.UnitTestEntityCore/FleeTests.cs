using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ciloci.Flee;
using BPMNET.EntityCore;
using System.Collections.Generic;

namespace BPMNET.UnitTestEntityCore
{
    [TestClass]
    public class FleeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            ExpressionContext context = new ExpressionContext();

            // Use string.format
            context.Imports.AddType(typeof(string));
            context.Imports.AddType(typeof(ProcessInstance));
            context.Imports.AddType(typeof(Dictionary<string, object>));
            context.Variables.Add("nextCode", "COMPLETE");

            ProcessInstance pi = new ProcessInstance() { ProcessInstanceName = "Aiska", SuspensionState = ESuspensionState.ACTIVE };
            Dictionary<string, int> g = new Dictionary<string, int>();
            g.Add("gaji", 10000000);
            context.Variables.Add("gaji", 10000000);
            context.Variables.Add("processInstance", pi);
            context.Variables.Add("g", g);
            context.Variables.Add("index", 0);

            IDynamicExpression exp = context.CompileDynamic("nextCode.Equals(\"COMPLETE\")");
            var result = exp.Evaluate();

            exp = context.CompileDynamic("gaji > 1000000");
            result = exp.Evaluate();

            exp = context.CompileDynamic("processInstance.ProcessInstanceName.Equals(\"Aiska\") AND processInstance.ProcessInstanceName.Equals(1)");
            result = exp.Evaluate();

            exp = context.CompileDynamic("g[\"gaji\"] > 1000000");
            result = exp.Evaluate();
        }
    }
}
