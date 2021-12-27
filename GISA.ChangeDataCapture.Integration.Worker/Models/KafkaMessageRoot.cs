using GISA.ChangeDataCapture.Worker.Contracts;
using GISA.ChangeDataCapture.Worker.Enums;
using System;

namespace GISA.ChangeDataCapture.Worker.Models
{
    internal class KafkaMessageRoot : IChangeDataCaptureMessageRoot
    {
        public object After { get; set; }
        public object Before { get; set; }
        public KafkaMessageOperationEnum Operation { get; set; }
        public DateTime? CreatedOn => IsInsert ? DateTime.Now : null;
        public DateTime? UpdatedOn => IsUpdate ? DateTime.Now : null;
        public DateTime? RemovedOn => IsRemove ? DateTime.Now : null;

        private bool IsInsert => Operation == KafkaMessageOperationEnum.Insert;
        private bool IsUpdate => Operation == KafkaMessageOperationEnum.Update;
        private bool IsRemove => Operation == KafkaMessageOperationEnum.Delete;

        public KafkaMessageRoot(Type mapperTo)
        {
            After = Activator.CreateInstance(mapperTo);
            Before = Activator.CreateInstance(mapperTo);
        }

        public KafkaMessageRoot()
        {

        }
    }
}
