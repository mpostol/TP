
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Reflection.CodeGeneration.SampleCodeDom;

namespace TPA.Reflection.UnitTest.CodeGeneration
{
    [TestClass]
    public class CSharpCodeFactoryUnitTest
    {
        [TestCleanup]
        public void TestCleanupMethod()
        {
            if (File.Exists(_outputFileName))
                File.Delete(_outputFileName);
        }
        [TestMethod]
        public void GenerateCSharpCodeTest()
        {
            Assert.IsFalse(File.Exists(_outputFileName));
            /// <summary>
            /// Create the CodeDOM graph and generate the code.
            /// </summary>
            CSharpCodeFactory _sample = new CSharpCodeFactory();
            _sample.AddFields();
            _sample.AddProperties();
            _sample.AddMethod();
            _sample.AddConstructor();
            _sample.AddEntryPoint();
            _sample.GenerateCSharpCode(_outputFileName);
            FileInfo _createdFile = new FileInfo(_outputFileName);
            Assert.IsTrue(_createdFile.Exists);
            Assert.AreEqual<long>(1948, _createdFile.Length);
            using (StreamReader _reader = new StreamReader(_createdFile.Name))
                Console.Write(_reader.ReadToEnd());
        }
        /// <summary>
        /// The name of the file to contain the source code.
        /// </summary>
        const string _outputFileName = "SampleCode.cs";

    }
}
