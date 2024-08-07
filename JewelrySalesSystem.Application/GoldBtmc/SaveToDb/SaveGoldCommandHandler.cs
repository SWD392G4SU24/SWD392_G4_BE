﻿using JewelrySalesSystem.Application.Common.Models;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.GoldBtmc.SaveToDb
{
    public class SaveGoldCommandHandler : IRequestHandler<SaveGoldCommand, string>
    {
        private readonly IGoldService _goldService;
        private readonly IGoldRepository _goldRepository;

        public SaveGoldCommandHandler(IGoldService goldService, IGoldRepository goldRepository)
        {
            _goldService = goldService;
            _goldRepository = goldRepository;
        }

        public async Task<string> Handle(SaveGoldCommand request, CancellationToken cancellationToken)
        {
            var goldBtmc = await _goldService.GetGoldPricesAsync(cancellationToken);
            foreach (var item in goldBtmc)
            {
                var existGold = await _goldRepository.AnyAsync(x => x.Name == item.Name && x.CreatedAt == item.CreatedAt, cancellationToken);
                if (existGold)
                {
                    continue;
                }

                _goldRepository.Add(new GoldEntity
                {
                    BuyCost = item.BuyCost,
                    SellCost = item.SellCost,
                    GoldContent = item.GoldContent,
                    KaraContent = item.KaraContent,
                    Name = item.Name,
                    CreatedAt = item.CreatedAt,
                });      
            }
            var result = await _goldRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
            return result == 0 ? "Lưu Gold thất bại" : "lưu Gold thành công";
        }
    }
}
