using MarketPlace.Application.Abstractions;
using MarketPlace.Infrastructure.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Test
{
    public class ServiceTest
    {
        private readonly Mock<IProductService> _prServ;
        private readonly Mock<IProductRepository> _prRepo;
        public ServiceTest()
        {
            var md = new Mock<MpDbContext>();
            _prRepo = new Mock<IProductRepository>(md);  
            _prServ = new Mock<IProductService>(_prRepo);
        }


    }
}
