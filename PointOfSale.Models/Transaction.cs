﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int BusinessUnitId { get; set; }
        [Required(ErrorMessage = "Por favor, indique una Caja.")]
        public int? CashRegisterId { get; set; }
        public CashRegister? CashRegister { get; set; }
        public BusinessUnit? BusinessUnit { get; set; }

        public DateTime? DateTime { get; set; }
        [Required(ErrorMessage = "Por favor, escriba una Descripción.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "El monto del movimiento no puede ser nulo.")]
        public decimal? Amount { get; set; }
        public bool? IsExpense { get; set; }


        public int? OperationTypeId { get; set; }
        public OperationType? OperationType { get; set; }


        public int? UserId { get; set; }
    }
}
