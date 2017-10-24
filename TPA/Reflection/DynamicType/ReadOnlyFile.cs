
using System.Dynamic;

namespace TPA.Reflection.DynamicType
{
  public class ReadOnlyFile : DynamicObject
  {
    //TODO https://github.com/mpostol/TP/issues/50
    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
      result = null;
      //TODO to be implemented.
      return true;
    }

  }
}
