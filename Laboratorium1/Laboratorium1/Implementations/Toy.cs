﻿using Laboratorium1.Interfaces;
using Laboratorium1.Structs;
using System;

namespace Laboratorium1.Implementations
{
    class Toy : IToy
    {
        public virtual string State { get; protected set; }

        public string Name { get; protected set; }

        public double Age { get; set; }

        private Value value;

        public event EventHandler ValueChanged;

        protected void OnChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        public decimal CurrentValue {
            get
            {
                decimal ageRate = new decimal(Age * 0.98);
                return Value.Price * ageRate;
            }
            private set { }
        }

        public Value Value
        {
            get { return value; }
            set
            {
                this.value = value;
                OnChanged(EventArgs.Empty);
            }
        }

        public Toy(double age, Value value)
        {
            Age = age;
            Value = value;
        }
    }
}
