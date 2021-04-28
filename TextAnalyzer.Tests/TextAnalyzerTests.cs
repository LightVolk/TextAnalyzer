using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAnalyzer.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Text.Tests
{
    [TestClass()]
    public class TextAnalyzerTests
    {
        [TestMethod()]
        public void AnalyzeTest()
        {
            var textAnalyzer = new TextAnalyzer();
            var result = textAnalyzer.ModifyText("ГЛАВ123РЫБА56", 60);
            if(!result.Equals("ГЛАВ183РЫБА16")) Assert.Fail();

            result = textAnalyzer.ModifyText("ГАЗ4ПРОМ5БАНК97", 15);
            if(!result.Equals("ГАЗ9ПРОМ0БАНК12")) Assert.Fail();

            result = textAnalyzer.ModifyText("ГАЗ4ПРОМ5БАНК97", -100);
            if(!string.IsNullOrEmpty(result)) Assert.Fail();

            result = textAnalyzer.ModifyText(null, -100);
            if (!string.IsNullOrEmpty(result)) Assert.Fail();

            result = textAnalyzer.ModifyText(null, 100);
            if (!string.IsNullOrEmpty(result)) Assert.Fail();
        }
    }
}