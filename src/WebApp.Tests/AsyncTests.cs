namespace WebApp.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Xunit;

    public class AsyncTests
    {
        [Fact]
        public void AllAsyncMethodsReturnATask()
        {
            // Avoid async void methods
            // (ref.: http://haacked.com/archive/2014/11/11/async-void-methods/)
            AssertNoAsyncVoidMethods(typeof(MvcApplication).Assembly);
        }

        #region /// internal ///////////////////////////////////////////////////

        private static void AssertNoAsyncVoidMethods(Assembly assembly)
        {
            var messages = GetAsyncVoidMethods(assembly)
                .Select(
                    method => // ReSharper disable once PossibleNullReferenceException
                    string.Format("'{0}.{1}' is an async void method.", method.DeclaringType.Name, method.Name))
                .ToList();

            Assert.False(
                messages.Any(),
                "Async void methods found!" + Environment.NewLine + string.Join(Environment.NewLine, messages));
        }

        private static IEnumerable<MethodInfo> GetAsyncVoidMethods(Assembly assembly)
        {
            return GetLoadableTypes(assembly)
                .SelectMany(
                    type =>
                    type.GetMethods(
                        BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static |
                        BindingFlags.DeclaredOnly))
                .Where(HasAttribute<AsyncStateMachineAttribute>)
                .Where(method => method.ReturnType == typeof(void));
        }

        private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        private static bool HasAttribute<TAttribute>(MethodInfo method) where TAttribute : Attribute
        {
            return method.GetCustomAttributes(typeof(TAttribute), false)
                         .Any();
        }

        #endregion
    }
}
