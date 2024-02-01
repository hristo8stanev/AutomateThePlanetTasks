using System;
using System.Reflection;

class Program
{

    static void Main(string[] args)
    {

        //   var type = typeof(Worker);
        //   var propertyInfos = type.GetProperties();
        //  
        //   foreach(PropertyInfo propertyInfo in propertyInfos)
        //   {
        //       Console.WriteLine(propertyInfo.Name);
        //       var accessors = propertyInfo.GetAccessors();
        //  
        //       foreach(var accessor in accessors)
        //       {
        //          Console.WriteLine(accessor.Name);
        //          Console.WriteLine("========================");
        //      }
        //   }
        //
        //  MethodInfo[] methods = typeof(Worker).GetMethods(BindingFlags.Instance | BindingFlags.Public);
        //
        //  foreach (MethodInfo info in methods)
        //  {
        //      Console.WriteLine(info.Name);
        //  }

        var assembly = Assembly.GetExecutingAssembly();

        if (assembly.GetName().Name.StartsWith("Work"))
        {
            Console.WriteLine("Assembly Name: " + assembly.GetName().Name);
        }
        else
        {
            Console.WriteLine("Namespace start with work doesn't exist");
        }
    }
}

 