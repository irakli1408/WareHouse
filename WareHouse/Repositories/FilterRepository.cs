using System.Collections.Generic;
using System.Linq;
using WareHouse.Interfaces;
using WareHouseDb.Entities;
using WareHouseDb.WareHouseDateBaseContext;
using WareHouseDB.Entities;

namespace WareHouse.Repositories
{
    public class FilterRepository : IFilter
    {
        private readonly WareHouseDBContext context;
        
        public FilterRepository(WareHouseDBContext context)
        {
            this.context = context;
          
        }
        public IQueryable<ExportModel> ExportModel(FilterModel model)
        {

            var quary = from p in context.Products
                        join r in context.Requisites
                        on p.Id equals r.ProductId
                        select r;

            if (model.Description != null)
            {
                quary = DescriptionDefining(model, quary);
            }
            if (model.StartPrice != null || model.EndPrice != null)
            {
                quary = StartPriceDefining(model, quary);
            }
            if (model.SellStartPrice != null || model.SellEndPrice != null)
            {
                quary = SellPriceDefining(model, quary);
            }

            var res = quary.Select(r => new ExportModel
            {
                PartId = r.Product.ProductCode,
                StartPrice = r.Product.StartPrice,
                SellPrice = r.Product.SellPrice,
                Warehouse = r.Product.Warehouse,
                Brand = r.Brand,
                Number = r.Number,
                VehicleDesc = r.VehicleDescription,
                Description = r.Description
            });
            return res;
        }
        public IQueryable<Requisite> StartPriceDefining(FilterModel model, IQueryable<Requisite> quary)
        {

            if (model.StartPrice == null)
            {
                quary = quary.Where(x => x.Product.StartPrice <= model.EndPrice);
            }
            else if (model.EndPrice == null)
            {
                quary = quary.Where(x => x.Product.StartPrice >= model.StartPrice);
            }
            else
            {
                quary = quary.Where(x => x.Product.StartPrice >= model.StartPrice && x.Product.StartPrice <= model.EndPrice);
            }

            return quary;
        }
        public IQueryable<Requisite> SellPriceDefining(FilterModel model, IQueryable<Requisite> quary)
        {

            if (model.SellStartPrice == null)
            {
                quary = quary.Where(x => x.Product.SellPrice <= model.SellEndPrice);
            }
            else if (model.SellEndPrice == null)
            {
                quary = quary.Where(x => x.Product.SellPrice >= model.SellStartPrice);
            }
            else
            {
                quary = quary.Where(x => x.Product.SellPrice >= model.SellStartPrice && x.Product.SellPrice <= model.SellEndPrice);
            }

            return quary;
        }
        public IQueryable<Requisite> DescriptionDefining(FilterModel model, IQueryable<Requisite> quary)
        {
            quary = quary.Where(x =>
            (x.Product.ProductCode != null && x.Product.ProductCode.Contains(model.Description)) ||
            (x.Brand != null && x.Brand.Contains(model.Description)) ||
            (x.Number != null && x.Number.Contains(model.Description)) ||
            (x.Product.Warehouse != null && x.Product.Warehouse.Contains(model.Description)) ||
            (x.Description != null && x.Description.Contains(model.Description)) ||
            (x.VehicleDescription != null && x.VehicleDescription.Contains(model.Description)));
            return quary;
        }
    }
}
