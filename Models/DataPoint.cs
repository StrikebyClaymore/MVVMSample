using OxyPlot;

namespace MVVMSample.Models
{
    internal struct DataPoint// : IDataPointProvider
    {
        public double X { get; set; }
        public double Y { get; set; }

        /*public OxyPlot.DataPoint GetDataPoint()
        {
            return new OxyPlot.DataPoint(X, Y);
        }*/
    }
}
