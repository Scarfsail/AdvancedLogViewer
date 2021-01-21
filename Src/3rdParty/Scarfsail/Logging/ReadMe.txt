Referencing this .NET Standard library in a full .NET application requires to add following directive into the csproj file under <PropertyGroup>:

<RestoreProjectStyle>PackageReference</RestoreProjectStyle>

See: https://github.com/dotnet/standard/issues/481 or https://www.hanselman.com/blog/ReferencingNETStandardAssembliesFromBothNETCoreAndNETFramework.aspx