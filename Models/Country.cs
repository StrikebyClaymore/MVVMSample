using System.Collections.Generic;
using System.Text;

namespace MVVMSample.Models
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCoutns { get; set; }
    }
}
