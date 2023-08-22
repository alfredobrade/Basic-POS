using PointOfSale.BL.IServices;
using PointOfSale.DAL.IRepository;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.Services
{
    public class BusinessUnitService : IBusinessUnitService
    {
        private readonly IBusinessUnitRepository _repository;

        public BusinessUnitService(IBusinessUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BusinessUnit>> GetBusinessUnits(int userId)
        {
            try
            {
                var list = await _repository.GetBusinessUnits(userId);
                var result = new List<BusinessUnit>();
                foreach (var item in list) 
                {
                    var model = new BusinessUnit()
                    {
                        Id = item.BusinessUnitId,
                        Name = item.BusinessUnit.Name
                    };
                    result.Add(model);
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BusinessUnit> NewBusinessUnit(int userId, BusinessUnit businessUnit)
        {
            try
            {
                var model = await _repository.Create(businessUnit);
                await _repository.CreateBusinessUnitRelation(userId, model.Id);

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
