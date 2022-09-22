//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.AnonymousTypes
{
  [TestClass]
  public class AnonymousTypes
  {
    [TestMethod]
    public void AnonymousType()
    {
      var anonymousVariable = new { Amount = 108, Message = "Hello" };
      Assert.AreEqual(108, anonymousVariable.Amount);
      Assert.AreEqual("Hello", anonymousVariable.Message);
      //anonymousVariable = new { Amount = 108.0, Message = "Hello" }; //Cannot implicitly convert type '<anonymous type: double Amount, string Message>' to '<anonymous type: int Amount, string Message>'
      //anonymousVariable = new { Message = "Hello", Amount = 108 }; //Cannot implicitly convert type '<anonymous type: string Message, int Amount>' to '<anonymous type: int Amount, string Message>'
      //anonymousVariable.Message = ""; //Property or indexer '<anonymous type: int Amount, string Message>.Message' cannot be assigned to --it is read only
      anonymousVariable = null;
      Assert.IsNull(anonymousVariable);
      //var newAnonymousVariable = null; //Cannot assign<null > to an implicitly-typed variable
    }

    [TestMethod]
    public void AnonymousTypesCompatibilityTest()
    {
      var anonymousVariable1 = new { Amount = 108, Message = "Hello" };
      var anonymousVariable2 = new { Amount = 108, Message = "Hello" };
      Assert.AreEqual(anonymousVariable1, anonymousVariable2);
      Assert.AreNotSame(anonymousVariable1, anonymousVariable2);
      anonymousVariable1 = anonymousVariable2;
      Assert.AreSame(anonymousVariable1, anonymousVariable2);
    }

    [TestMethod]
    public void AnonymousArrayTest()
    {
      var anonymousArray = new[] {
                              new { name = "apple", diam = 4 },
                              new { name = "grape", diam = 1 },
                              //new { diam = 2, name = "plum"  }
                             };
      Assert.AreEqual(new { name = "apple", diam = 4 }, anonymousArray[0]);
      Assert.AreEqual(new { name = "grape", diam = 1 }, anonymousArray[1]);
    }

    [TestMethod]
    public void NoNewBehaviorValues()
    {
      Tuple<int, string> classTuple = new Tuple<int, string>(108, "Hello");
      Assert.AreEqual(108, classTuple.Item1);
      Assert.AreEqual("Hello", classTuple.Item2);
      //_classTuple.Item1 = 801;
      classTuple = null;

      ValueTuple<int, string> valueTupleVariable = (108, "Hello");
      ValueTuple<int, string> __ = ValueTuple.Create<int, string>(108, "Hello");
      Assert.AreEqual(108, valueTupleVariable.Item1);
      Assert.AreEqual("Hello", valueTupleVariable.Item2);
      valueTupleVariable.Item1 = 801;
      valueTupleVariable.Item2 = "";
      //valueTupleVariable = (108.0, "Hello"); //Error CS0029  Cannot implicitly convert type 'double' to 'int'
      //valueTupleVariable = ("Hello", 108); //Error CS0029  Cannot implicitly convert type 'string' to 'int'; Error CS0029  Cannot implicitly convert type 'int' to 'string'
      //valueTupleVariable = null; //Error CS0037  Cannot convert null to '(int, string)' because it is a non - nullable value type
    }

    [TestMethod]
    public void NamedFieldsValueTuple()
    {
      //(int Amount, string Message) _ = (108, "Hello");
      (int Amount, string Message) valueTupleVariable = (Amount: 108, Message: "Hello");
      Assert.AreEqual(108, valueTupleVariable.Item1);
      Assert.AreEqual(108, valueTupleVariable.Amount);
      Assert.AreEqual("Hello", valueTupleVariable.Item2);
      Assert.AreEqual("Hello", valueTupleVariable.Message);
      valueTupleVariable.Amount = 801;
      valueTupleVariable.Message = "";
    }

    [TestMethod]
    public void ValueTupleEqality()
    {
      (int Amount, string Message) valueTupleVariable1 = (108, "Hello");
      (int Amount, string Message) valueTupleVariable2 = (108, "Hello");
      Assert.IsTrue(valueTupleVariable1 == valueTupleVariable2);
      Assert.AreEqual(valueTupleVariable1, valueTupleVariable2);
      valueTupleVariable1 = valueTupleVariable2;
    }

    [TestMethod]
    public void ValueTupleMethodTest()
    {
      (int Amount, string Message) valueTupleVariable = InstrumentationTupleClass.GetValueTupleValue();
      Assert.AreEqual(108, valueTupleVariable.Item1);
      Assert.AreEqual("Hello", valueTupleVariable.Item2);
      valueTupleVariable.Amount = 801;
      valueTupleVariable.Message = "";
    }

    [TestMethod]
    public void ValueTupleDeconstructionMethodTest()
    {
      (int Amount, string Message) = InstrumentationTupleClass.GetValueTupleValue();
      Assert.AreEqual(108, Amount);
      Assert.AreEqual("Hello", Message);
      Amount = 801;
      Message = "";
    }

    private static class InstrumentationTupleClass
    {
      internal static (int Amount, string Message) GetValueTupleValue()
      {
        return (108, "Hello");
      }
    }
  }
}
