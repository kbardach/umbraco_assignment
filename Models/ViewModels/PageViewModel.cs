using System.ComponentModel;
using System.Globalization;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Models;
using umbraco_assignment.Business.Extensions;

namespace umbraco_assignment.Models.ViewModels
{
    public class ViewModelTypeConverter : TypeConverter
    {
        private readonly Type pageViewModelType;

        private readonly Type pageModelType;

        public ViewModelTypeConverter(Type type)
        {
            if (type.IsGenericType
                && type.GetGenericTypeDefinition() == typeof(IViewModel<>)
                && type.GetGenericArguments().Length == 1)
            {
                pageViewModelType = type;
                pageModelType = type.GetGenericArguments()[0];
            }
            else if (type.IsTypeDerivedFromGenericType(typeof(IViewModel<>), out var t))
            {
                pageViewModelType = type;
                pageModelType = t.GetGenericArguments()[0];
            }
            else
            {
                var typeWithGenericDefinition = type.GetTypeWithGenericDefinition(typeof(IViewModel<>));

                if (typeWithGenericDefinition != null)
                {
                    pageViewModelType = type;
                    pageModelType = typeWithGenericDefinition.GetGenericArguments()[0];
                }
            }
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (pageModelType == null)
            {
                return false;
            }

            if (pageModelType.IsAssignableToContentType(typeof(PublishedContentBase), out var _) == false)
            {
                return false;
            }

            return sourceType == typeof(IViewModel<>) || sourceType.IsAssignableToGenericType(typeof(IViewModel<>)) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is IViewModel<PublishedContentBase> viewModel)
            {
                if (pageModelType.IsInstanceOfType(viewModel.CurrentPage))
                {
                    var res = Activator.CreateInstance(pageViewModelType, pageModelType, viewModel.CurrentPage);

                    return res;
                }
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (pageModelType == null)
            {
                return false;
            }

            if (pageModelType.IsAssignableToContentType(typeof(PublishedContentBase), out var _) == false)
            {
                return false;
            }

            return destinationType == typeof(IPublishedContent);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is PublishedContentBase contentType)
            {
                return contentType;
            }

            if (value is IViewModel<PublishedContentBase> viewModel)
            {
                return viewModel.CurrentPage;
            }

            return null;
        }
    }

    [TypeConverter(typeof(ViewModelTypeConverter))]
    public interface IViewModel<out T> where T : PublishedContentBase
    {
        T CurrentPage { get; }
    }

    public class PageViewModel<T> : ContentModel, IViewModel<T>, IConvertible where T : PublishedContentBase
    {
        public PageViewModel(IPublishedContent content)
            : base(content)
        {
        }

        public PageViewModel(T currentPageModel) : base(currentPageModel)
        {
            // ToDo-8.1: Make sure this is the default constructor!
            CurrentPage = currentPageModel;
        }

        public T CurrentPage { get; }

        /// <inheritdoc />
        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        /// <inheritdoc />
        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Activator.CreateInstance(conversionType, CurrentPage);
        }
    }
}
