using GISA.ChangeDataCapture.Worker.Contracts;
using GISA.ChangeDataCapture.Worker.Kafka;
using GISA.ChangeDataCapture.Worker.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GISA.ChangeDataCapture.Worker.Extensions
{
    public static class KafkaGisaPortalWorkerExtensions
    {
        public static IServiceCollection AddChangeDataCaptureConsumer(this IServiceCollection services, KafkaOptions kafkaOptions)
        {
            services.AddSingleton(_ => kafkaOptions);
            services.AddSingleton<IChangeDataCaptureSubject, KafkaGisaPortalSubject>();

            services.AddTransient<IChangeDataCaptureConsumerManager>(serviceProvider => new KafkaGisaPortalConsumerManager(serviceProvider));
            services.AddTransient<IChangeDataCaptureConsumerBuilder, KafkaGisaPortalConsumerBuilder>();
            services.AddTransient<IChangeDataCaptureDeserializeBuilder, KafkaGisaPortalDeserializeBuilder>();
            services.AddTransient<IChangeDataCaptureConsumer, KafkaGisaPortalConsumer>();

            return services;
        }
    }
}
