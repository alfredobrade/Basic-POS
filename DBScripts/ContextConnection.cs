using Microsoft.EntityFrameworkCore;
using PointOfSale.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBScripts
{
    public class ContextConnection
    {
        private readonly POSContext _context;
        private int _index;

        public ContextConnection(POSContext context)
        {
            _context = context;
        }

        //TODO: metodo donde se van a realizar todos los updates necesarios
        public int DBUpdates()
        {
            try
            {
                //init index
                _index = 0;

                //procesos a realizar
                SalesDBUpdate();


                //exposicion de la cantidad de modificaciones realizadas
                return _index;
            }
            catch (Exception)
            {

                throw;
            }
        }




        //modificacion de Sales
        public async Task SalesDBUpdate()
        {
            try
            {
                var list = _context.Sales.AsQueryable();
                foreach (var item in list)
                {
                    //se controla si el CustomerId es null
                    if (item.CustomerId == null)
                    {
                        item.CustomerId = 0;
                        _context.Sales.Update(item);
                        _index++;
                        Console.WriteLine($"SaleId {item.Id} Update CustomerId {item.CustomerId}");
                    }
                    //las ventas sin fecha no se eliminan porque son ventas abiertas
                    //if (item.DateTime == null)
                    //{
                    //    Console.WriteLine($"SaleId {item.Id} Update CustomerId {item.CustomerId}");

                    //    _context.Sales.Remove(item);
                    //    _index++;
                    //}

                }
                await _context.SaveChangesAsync();
                
            }
            catch (Exception)
            {

                throw;
            }
        }






    }
}
