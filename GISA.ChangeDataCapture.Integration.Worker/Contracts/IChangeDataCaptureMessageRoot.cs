using GISA.ChangeDataCapture.Worker.Enums;
using System;

namespace GISA.ChangeDataCapture.Worker.Contracts
{
    internal interface IChangeDataCaptureMessageRoot
    {
        public object After { get; set; }
        public object Before { get; set; }
        public KafkaMessageOperationEnum Operation { get; set; }
        public DateTime? CreatedOn { get; }
        public DateTime? UpdatedOn { get; }
        public DateTime? RemovedOn { get; }
    }
}
