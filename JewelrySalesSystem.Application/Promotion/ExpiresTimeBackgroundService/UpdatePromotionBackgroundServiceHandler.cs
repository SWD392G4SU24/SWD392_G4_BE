using JewelrySalesSystem.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Promotion.ExpiresTimeBackgroundService
{
    public class UpdatePromotionBackgroundServiceHandler : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public UpdatePromotionBackgroundServiceHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var promotionRepository = scope.ServiceProvider.GetRequiredService<IPromotionRepository>();
                    var expiredPromotions = await promotionRepository.FindAllAsync(x => x.DeletedAt == null 
                        && x.ExpiresTime <= DateTime.Now, cancellationToken);
                    if (expiredPromotions.Any())
                    {
                        foreach (var promotion in expiredPromotions)
                        {
                            promotion.Status = PromotionStatus.UNAVAILABLE;
                            promotion.DeletedAt = DateTime.UtcNow;
                            promotionRepository.Update(promotion);
                        }
                        await promotionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    }                                       
                }
                await Task.Delay(TimeSpan.FromHours(1), cancellationToken); // Run every hour
            }
        }
        
    }
}
