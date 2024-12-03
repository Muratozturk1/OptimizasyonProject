using Optimizasyon.Core.Domain.Entities;

namespace Optimizasyon.Core.Application.Services
{
    public class MarangozOptimizationService : IMarangozOptimizationService
    {
        public OptimizationResult Optimize(MarangozModel model)
        {
            int woodPerTable = model.WoodPerTable;
            int laborPerTable = model.LaborPerTable;
            int woodPerChair = model.WoodPerChair;
            int laborPerChair = model.LaborPerChair;

            int totalWood = model.TotalWood;
            int totalLabor = model.TotalLabor;

            double profitPerTable = model.ProfitPerTable;
            double profitPerChair = model.ProfitPerChair;

            if (woodPerTable <= 0 || laborPerTable <= 0 || woodPerChair <= 0 || laborPerChair <= 0 || profitPerTable <= 0 || profitPerChair <= 0)
                return new OptimizationResult { Tables = 0, Chairs = 0, MaxProfit = 0 };

            var (tables, chairs, maxProfit) = SolveSimplex(
                woodPerTable, laborPerTable, woodPerChair, laborPerChair, 
                totalWood, totalLabor, 
                profitPerTable, profitPerChair
            );

            return new OptimizationResult
            {
                Tables = tables,
                Chairs = chairs,
                MaxProfit = maxProfit
            };
        }

        private (int Tables, int Chairs, double MaxProfit) SolveSimplex(
            int woodPerTable, int laborPerTable,
            int woodPerChair, int laborPerChair,
            int totalWood, int totalLabor,
            double profitPerTable, double profitPerChair)
        {
            int maxTables = totalWood / woodPerTable;
            int maxChairs = totalWood / woodPerChair;

            int bestTables = 0, bestChairs = 0;
            double maxProfit = 0;

            for (int tables = 0; tables <= maxTables; tables++)
            {
                for (int chairs = 0; chairs <= maxChairs; chairs++)
                {
                    int usedWood = tables * woodPerTable + chairs * woodPerChair;
                    int usedLabor = tables * laborPerTable + chairs * laborPerChair;

                    if (usedWood <= totalWood && usedLabor <= totalLabor)
                    {
                        double profit = tables * profitPerTable + chairs * profitPerChair;

                        if (profit > maxProfit)
                        {
                            maxProfit = profit;
                            bestTables = tables;
                            bestChairs = chairs;
                        }
                    }
                }
            }

            return (bestTables, bestChairs, maxProfit);
        }
    }
}
