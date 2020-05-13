using System;

namespace ViktorDataModel
{
    public class Sranec : BaseEntity
    {
        public string Name { get; set; }
        public Measure Measure { get; set; }
        public Measure MeasureLive { get; set; }
        public int? MeasureId { get; set; }
    }
}
