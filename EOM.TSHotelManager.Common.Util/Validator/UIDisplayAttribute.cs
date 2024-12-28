using System;

namespace EOM.TSHotelManager.Common.Util
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class UIDisplayAttribute : Attribute
    {
        public string DisplayName { get; }

        public UIDisplayAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
