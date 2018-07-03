using System;
using System.Collections.Generic;
using Domain.Shared.Interfaces.Repositories;
using FluentValidation.Results;

namespace Domain.Shared.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;

        public CommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void NotificationValidationError(List<ValidationFailure> erros)
        {
            foreach (var error in erros)
            {
                Console.WriteLine(error.ErrorMessage, ConsoleColor.Red);
            }
        }

        protected bool Commit()
        {
            //TODO: Validar se a alguma validação de negócio com erro!
            
            var commandResponse =  _uow.Commit();
            if(commandResponse.Success) return true;

            Console.WriteLine("Ocorreu um erro ao salvar os dados no banco", ConsoleColor.Red);
            return false;
        }
    }
}