using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace Migrate.Domain.Helper.Adapter
{
    public static class DataReaderExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static IEnumerable<TModel> Adapter<TModel>(this IDataReader dr) where TModel : class, new()
        {
            List<TModel> result = new List<TModel>();
            while (dr.Read())
            {
                TModel e = new TModel();
                SetObjectProperty(e, dr);
                result.Add(e);
            }

            if (!dr.IsClosed) dr.Close();

            return result;
        }

        private static void SetObjectProperty<TModel>(TModel m, IDataReader dr) where TModel : class, new()
        {
            foreach (PropertyInfo info in m.GetType().GetProperties())
            {
                try
                {
                    PropertyAttribute attr = info.GetCustomAttribute<PropertyAttribute>();
                    if (attr != null)
                    {
                        object value = ToEntityValue(info.PropertyType, dr[attr.Field]);
                        if (value != null)
                        {
                            info.SetValue(m, value, null);
                        }
                    }
                }
                // 捕获 dr 不存在 Field 的异常
                catch (KeyNotFoundException) { }
                catch (IndexOutOfRangeException) { }
            }
        }

        private static object ToEntityValue(Type type, object data)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (Convert.IsDBNull(data) || data == null)
                    return null;

                type = new System.ComponentModel.NullableConverter(type).UnderlyingType;
            }
            if (type.IsEnum)
                return System.Enum.Parse(type, data.ToString());

            if (data is System.Guid)
            {
                if (type.FullName == "System.String")
                    return Convert.ChangeType(((Guid)data).ToString(), type);
            }
            if (Convert.IsDBNull(data) || data == null)
                return null;

            //#region Array
            //if (type.IsArray && type == typeof(char[]))
            //{
            //    char[] result = Convert.ChangeType(data, typeof(String)).ToString().ToCharArray();
            //    return result;
            //}
            //if ((type.IsArray && type != typeof(byte[])) || (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(List<>))))
            //{
            //    if (type == typeof(int[]) || type == typeof(List<int>))
            //    {
            //        List<int> result = ASoft.Text.StringUtils.SplitIntNumber(data.ToString());
            //        if (type == typeof(int[]))
            //            return result.ToArray();
            //        return result;
            //    }
            //    if (type == typeof(long[]) || type == typeof(List<long>))
            //    {
            //        List<long> result = ASoft.Text.StringUtils.SplitLongNumber(data.ToString());
            //        if (type == typeof(long[]))
            //            return result.ToArray();
            //        return result;
            //    }
            //    if (type == typeof(string[]) || type == typeof(List<string>))
            //    {
            //        List<string> result = ASoft.Text.StringUtils.SplitStrictString(data.ToString());
            //        if (type == typeof(string[]))
            //            return result.ToArray();
            //        return result;
            //    }
            //    if (type == typeof(char[]))
            //    {
            //        char[] result = null;
            //        if (data != null)
            //            result = data.ToString().ToCharArray();
            //        return result;
            //    }
            //}
            //#endregion
            return Convert.ChangeType(data, type);
        }
    }
}
