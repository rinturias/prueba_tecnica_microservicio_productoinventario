
using System.Product.Domain.ValueObjects;
using Sharedkernel.Core;
using System.ComponentModel;
using System.Data.Common;

namespace System.Product.Domain.ValueObjects
{
    public record CantidadValueConCero : ValueObject
    {
        public int Value { get; }
        public CantidadValueConCero(int value)
        {
            if (value < 0)
            {
                throw new BussinessRuleValidationException("El valor no puede ser menor a 0");
            }
            Value = value;
        }

        public static implicit operator int(CantidadValueConCero value){
            return value.Value;
        }

        public static implicit operator CantidadValueConCero(int value){
            return new CantidadValueConCero(value);
        }
    }
}
