using Grpc.Core;
using Library;
using System;
using System.Threading.Tasks;

namespace GrpcServer
{
    public class ContainerService : Service.ServiceBase
    {
        public override Task<WaterAddResponse> ShouldAdd(
            WaterRequest request, 
            ServerCallContext context
            )
        {
            return Task.FromResult(new WaterAddResponse
            {
                ShouldAdd = Program.container.waterLevel < Program.container.lowerLevel ? true : false
            });
        }

        public override Task<WaterRemoveResponse> ShouldRemove(
            WaterRequest request, 
            ServerCallContext context
            )
        {
            return Task.FromResult(new WaterRemoveResponse
            {
                ShouldRemove = Program.container.waterLevel > Program.container.upperLevel ? true : false
            });
        }

        public override Task<WaterLevelResponse> Add(
            WaterAddRequest request, 
            ServerCallContext context
            )
        {
            Program.container.waterLevel += request.Amount;

            Console.WriteLine($"Added {request.Amount} amount of water, now water level is:  {Program.container.waterLevel}");

            return Task.FromResult(new WaterLevelResponse
            {
                WaterLevel = Program.container.waterLevel
            });
        }

        public override Task<WaterLevelResponse> Remove(
            WaterRemoveRequest request, 
            ServerCallContext context
            )
        {
            Program.container.waterLevel -= request.Amount;

            Console.WriteLine($"Removed {request.Amount} amount of water, now water level is:  {Program.container.waterLevel}");

            return Task.FromResult(new WaterLevelResponse
            {
                WaterLevel = Program.container.waterLevel
            });
        }
    }
}
