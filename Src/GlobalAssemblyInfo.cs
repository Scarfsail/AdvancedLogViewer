using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyProduct("Advanced Log Viewer")]
[assembly: AssemblyCopyright("Copyright © Ondrej Salplachta 2015")]
[assembly: AssemblyCompany("Ondrej Salplachta")]
[assembly: AssemblyProductUrl("www.salplachta.net/alv")]

[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]


// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("7.6.0")]
[assembly: AssemblyFileVersion("7.6.0")]


[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
[ComVisible(true)]
class AssemblyProductUrlAttribute : Attribute
{
    public AssemblyProductUrlAttribute(string productUrl)
    {
        this.ProductUrl = productUrl;
    }

    public string ProductUrl { get; private set; }
}