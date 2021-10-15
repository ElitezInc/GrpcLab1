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
            WaterAmountRequest request, 
            ServerCallContext context
            )
        {
            Program.container.waterLevel += request.Amount;

            Console.WriteLine($"Added {request.Amount}L amount of water, now water level is:  {Math.Round(Program.container.waterLevel, 1)}L");

            return Task.FromResult(new WaterLevelResponse
            {
                WaterLevel = Program.container.waterLevel
            });
        }

        public override Task<WaterLevelResponse> Remove(
            WaterAmountRequest request, 
            ServerCallContext context
            )
        {
            Program.container.waterLevel -= request.Amount;

            Console.WriteLine($"Removed {request.Amount}L amount of water, now water level is:  {Math.Round(Program.container.waterLevel, 1)}L");

            return Task.FromResult(new WaterLevelResponse
            {
                WaterLevel = Program.container.waterLevel
            });
        }
    }
}
