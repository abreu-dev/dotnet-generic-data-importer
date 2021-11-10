using System;

namespace GenericImporter.Service.Extensions
{
    public static class ObjectExtensions
    {
        public static void CallMethod(this object service, string methodName, object parameter)
        {
            var method = service.GetType().GetMethodOfInterface(methodName);
            var convertedParameter = Convert.ChangeType(parameter, parameter.GetType());
            method.Invoke(service, new object[] { convertedParameter });
        }
    }
}
