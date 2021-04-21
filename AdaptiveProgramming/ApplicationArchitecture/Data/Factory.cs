using TPA.ApplicationArchitecture.Data.API;

namespace TPA.ApplicationArchitecture.Data
{
    public class Factory : IFactory
    {
        public ILinq2SQL CreateLinq2SQL()
        {
            return new Linq2SQL();
        }
    }
}
