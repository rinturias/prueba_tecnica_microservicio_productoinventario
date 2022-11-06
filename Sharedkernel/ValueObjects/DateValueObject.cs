using System;
using System.Diagnostics.CodeAnalysis;
using Sharedkernel.Core;

namespace Sharedkernel.ValueObjects {
    [ExcludeFromCodeCoverage]
    public record DateValueObject {
        public DateTime Value { get; }
        public DateValueObject(string date_time) {
            //   var value = new DateTime(y);

            if (!IsValid(date_time)) {
                throw new BussinessRuleValidationException("Fecha no Valida");
            }
            Value = DateTime.Parse(date_time);
        }

        public static implicit operator DateTime(DateValueObject value) {
            return value.Value;
        }

        public static implicit operator DateValueObject(DateTime value) {
            return new DateValueObject(value);
        }

        public static bool IsValid(string date) {
            try
            {
                DateTime.Parse(date);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }

        }
    }
}
