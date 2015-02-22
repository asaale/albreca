using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Optimization;

namespace Albreca.Web
{
    public class AsIsBundleSorter : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}