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
                UsersCount();
                SalesDBUpdate();


                //exposicion de la cantidad de modificaciones realizadas
                return _index;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UsersCount() //le saque al async porque me tiraba error con el context.
                                //chatgpt me dice que use un using con instancias distintas de conexion a context
        {
            try
            {
                //var list = _context.Users.ToList();
                var num = _context.Users.Count();
                Console.WriteLine($"Cantidad de usuarios {num}");
                return num;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


        //modificacion de Sales
        public void SalesDBUpdate()//le saque al async porque me tiraba error con el context.
                                   //chatgpt me dice que use un using con instancias distintas de conexion a context
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
                _context.SaveChanges();
                
            }
            catch (Exception)
            {

                throw;
            }
        }






    }
}
