

namespace TPA.ApplicationArchitecture.Data.API
{
    public static class Factory
    {
        public static ILinq2SQL CreateLinq2SQL()
        {
            return new Linq2SQL();
        }
    }
}
