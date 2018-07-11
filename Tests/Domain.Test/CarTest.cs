using System;
using Domain.Commands.Cars;
using Domain.Shared.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Domain.Shared.EntityEnum;

namespace Domain.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExecutarComandos()
        {
            var bus = new FakeBus();

            // Registro com sucesso
            var cmd = new CreateCarCommand("Fox Rock in Rio", 19000, EStatus.Ativo, Guid.NewGuid());
            Init(cmd);
            bus.SendCommand(cmd);
            End(cmd);

            //Registro com erro
            cmd = new CreateCarCommand("Fox Rock in Rio", 19000, EStatus.Ativo, Guid.NewGuid());
            Init(cmd);
            bus.SendCommand(cmd);
            End(cmd);

            //Atualizar Car
            var cmd2 = new UpdateCarCommand(Guid.NewGuid(), "Fox Rock in Rio", 19000, EStatus.Ativo);
            Init(cmd2);
            bus.SendCommand(cmd2);
            End(cmd2);

            //Deletar Car
            var cmd3 = new DeleteCarCommand(Guid.NewGuid());
            Init(cmd3);
            bus.SendCommand(cmd3);
            End(cmd3);
        }

        public static void Init(Message msg)
        {
            Console.WriteLine("Inicio comando: " + msg.MessageType, ConsoleColor.Gray);
        }

        public static void End(Message msg)
        {
            Console.WriteLine("Fim comando: " + msg.MessageType, ConsoleColor.Yellow);
            Console.WriteLine("*********************");
        }
    }
}
