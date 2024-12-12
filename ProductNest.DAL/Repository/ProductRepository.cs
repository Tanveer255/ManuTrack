using Microsoft.Extensions.Logging;
using ProductNest.DAL.Interface;
using ProductNest.Entity;
namespace ProductNest.DAL.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(IUnitOfWork unitOfWork, ILogger<ProductRepository> logger)
            : base(unitOfWork, logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
    }
}
