using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Apex.Helpers
{
    /// <summary>
    /// The AssembliesHelper helps gets assemblies and types used for brokering views and 
    /// viewmodels etc, in a consistent way across platforms.
    /// </summary>
    public static class AssembliesHelper
    {
        /// <summary>
        /// Gets the domain assemblies.
        /// </summary>
        /// <returns>Assemblies in the domain.</returns>
        public static IEnumerable<Assembly> GetDomainAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        /// <summary>
        /// Gets the domain types.
        /// </summary>
        /// <returns>Domain types.</returns>
        public static IEnumerable<Type> GetTypesInDomain()
        {
            var typesToSearch = (from a in GetDomainAssemblies()
                                 where a.GlobalAssemblyCache == false && a.IsDynamic == false
                                 from t in a.GetExportedTypes()
                                 select t).ToList();
            return typesToSearch.Distinct();
        }
    }
}