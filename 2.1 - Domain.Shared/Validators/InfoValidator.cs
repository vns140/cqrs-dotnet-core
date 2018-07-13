using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using FluentValidation.Results;
using Domain.Shared.Entities;

namespace Domain.Shared.Validators
{
    /// <summary>
    /// Classe que representa a abstracao de uma validacao de entidades e objetos de valor
    /// </summary>
    public class InfoValidator
    {
        #region properties     
        public List<ValidationFailure> Erros {get; private set;}        
        #endregion

        #region constructors
        public InfoValidator()
        {
            Erros = new List<ValidationFailure>();
        }
        
        #endregion

        private List<ValidationFailure> getValidation<T>(T obj)
        {
            List<ValidationFailure> list = new List<ValidationFailure> { };

            if (obj == null)
                return list;

            var properties = obj.GetType().GetProperties(BindingFlags.Public |
            BindingFlags.Instance).Where(o => o != null).ToList();

            properties.ForEach(p =>
            {
                if (p.PropertyType == typeof(ValidationFailure))
                {
                    list.AddRange(obj as List<ValidationFailure>);
                }
                else if (p.PropertyType.IsClass && p.PropertyType.Namespace != "System")
                    list.AddRange(getValidation(p.GetValue(obj, null)));
            });

            return list;
        }
        private void setValidation(ValidationResult failures)
        {
            Erros.AddRange(failures.Errors);
        }

        public void ValidateNow<T>(AbstractValidator<T> validator, T instance)
        {                       
            var falhaValidacao = validator.Validate(instance);  
            setValidation(falhaValidacao);        
        }
        
        public bool IsValid()
        {
            var erros = getValidation(this);
            if(erros.Count > 0)
            {
                Erros.Clear();
                Erros.AddRange(erros);
                return false;
            }
            else
            {
                return true;
            }
        }

    }

}