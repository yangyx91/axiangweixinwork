using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace weixin.mp
{
    public static class EnumHelper
    {
        /// <summary>
        /// 获取枚举类值的描述
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum enumValue)
        {
            try
            {
                Type type = enumValue.GetType();
                MemberInfo[] memberInfos = type.GetMember(enumValue.ToString());
                if (memberInfos!=null && memberInfos.Length>0)
                {
                    object[] attrs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute),false);
                    if (attrs != null && attrs.Length > 0)
                        return ((DescriptionAttribute)attrs[0]).Description;
                }
                return enumValue.ToString();
            }
            catch (Exception)
            {
                return "UnKnown";
            }
        }
    }
}
