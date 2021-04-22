namespace TPA.ApplicationArchitecture.Data.API
{
    public abstract class ILinq2SQL
    {
        public abstract void Connect();

        public static ILinq2SQL CreateLinq2SQL()
        {
            return new Linq2SQL();
        }
    }
}
