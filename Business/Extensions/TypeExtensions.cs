namespace umbraco_assignment.Business.Extensions
{
    public static class TypeExtensions
    {
        internal static Type GetTypeWithGenericDefinition(this Type type, Type definition)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (definition == null)
            {
                throw new ArgumentNullException("definition");
            }

            if (!definition.IsGenericTypeDefinition)
            {
                throw new ArgumentException("The definition needs to be a GenericTypeDefinition", "definition");
            }

            if (definition.IsInterface)
            {
                foreach (var interfaceType in type.GetInterfaces())
                {
                    if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == definition)
                    {
                        return interfaceType;
                    }
                }
            }

            for (Type t = type; t != null; t = t.BaseType)
            {
                if (t.IsGenericType && t.GetGenericTypeDefinition() == definition)
                {
                    return t;
                }
            }

            return null;
        }

        internal static bool IsTypeDerivedFromGenericType(this Type typeToCheck, Type genericType, out Type type)
        {
            type = null;

            if (typeToCheck == typeof(object))
            {
                return false;
            }
            else if (typeToCheck == null)
            {
                return false;
            }
            else if (typeToCheck.IsGenericType && typeToCheck.GetGenericTypeDefinition() == genericType)
            {
                type = typeToCheck;

                return true;
            }
            else
            {
                return IsTypeDerivedFromGenericType(typeToCheck.BaseType, genericType, out type);
            }
        }

        internal static bool IsAssignableToContentType(this Type givenType, Type contenType, out Type contentTypeType)
        {
            contentTypeType = null;
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == contenType)
                {
                    return true;
                }
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == contenType)
            {
                return true;
            }

            if (contenType.IsAssignableFrom(givenType))
            {
                return true;
            }

            if (givenType.IsGenericType)
            {
                var genericArgs = givenType.GetGenericArguments();

                foreach (var arg in genericArgs)
                {
                    var isArgAssignable = IsAssignableToContentType(arg, contenType, out contentTypeType);

                    if (isArgAssignable)
                    {
                        contentTypeType = arg;
                        return true;
                    }
                }
            }

            Type baseType = givenType.BaseType;

            if (baseType == null)
            {
                return false;
            }

            return IsAssignableToContentType(baseType, contenType, out contentTypeType);
        }

        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            Type baseType = givenType.BaseType;

            if (baseType == null)
            {
                return false;
            }

            return IsAssignableToGenericType(baseType, genericType);
        }
    }
}
