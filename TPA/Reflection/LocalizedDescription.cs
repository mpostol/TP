
using System.ComponentModel;

namespace TPA.Reflection
{
  public class LocalizedDescription : DescriptionAttribute
  {
    public LocalizedDescription(string description): base(description)
    {

    }
    public override string Description => base.Description;

  }
}
