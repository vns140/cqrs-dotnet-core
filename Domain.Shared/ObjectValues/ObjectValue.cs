using System;
using Domain.Shared.Validators;

namespace Domain.Shared.ObjectValues
{
    /// <summary>
    /// Classe que representa a abstracao de um objeo de valor
    /// </summary>
    public abstract class ObjectValue : InfoValidator, ICloneable
    {
        protected ObjectValue() { }
                
        public object Clone()
        {
             return this.MemberwiseClone();
        }
    }
}