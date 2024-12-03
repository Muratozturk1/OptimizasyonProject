using Optimizasyon.Core.Domain.Entities;

namespace Optimizasyon.Core.Application.Services;

public interface IMarangozOptimizationService
    {
       OptimizationResult Optimize(MarangozModel model);
    } 