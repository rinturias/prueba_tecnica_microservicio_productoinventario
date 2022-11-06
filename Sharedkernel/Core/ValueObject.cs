﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Sharedkernel.Core {

    [ExcludeFromCodeCoverage]
    public abstract record ValueObject {
        protected void CheckRule(IBussinessRule rule) {
            if (rule is null) {
                throw new ArgumentException("Rule cannot be null");
            }
            if (!rule.IsValid()) {
                throw new BussinessRuleValidationException(rule);
            }
        }

    }
}
