
using Sharedkernel.Core;

namespace System.Product.Domain.ValueObjects {
    public record StringEmptyValue {
        public string Value { get; }
        public StringEmptyValue(string value) {
            if (string.IsNullOrEmpty(value)) {
                throw new BussinessRuleValidationException("El valor no puede ser Vacio");
            }
            Value = value;
        }

        public static implicit operator string(StringEmptyValue value) {
            return value.Value;
        }

        public static implicit operator StringEmptyValue(string value) {
            return new StringEmptyValue(value);
        }




    }
}
