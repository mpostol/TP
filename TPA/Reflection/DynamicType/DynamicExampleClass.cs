
namespace TPA.Reflection.DynamicType
{

    public class DynamicExampleClass
    {

        public dynamic Increment(dynamic value)
        {
            //object vs dynamic differences
            object _error = 10;
            //_error += 1; //compiler error
            dynamic _dyn = 0;
            _dyn += 1;
            return value + _dyn;
        }
        public dynamic exampleMethod(dynamic d)
        {
            dynamic local = "Local variable";
            int two = 2;
            if (d is int)
                return local;
            else
                return two;
        }

    }
}
