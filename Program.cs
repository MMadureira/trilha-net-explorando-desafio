using System;
using System.Collections.Generic;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

bool continuar = true;
List<Pessoa> hospedes = new List<Pessoa>();
Suite suite = null;
Reserva reserva = null;

while (continuar)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Cadastrar nova suíte");
    Console.WriteLine("2. Adicionar hóspedes");
    Console.WriteLine("3. Criar uma reserva");
    Console.WriteLine("4. Exibir informações da reserva");
    Console.WriteLine("5. Sair");
    Console.Write("Escolha uma opção: ");

    int opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            Console.Write("Digite o tipo da suíte: ");
            string tipoSuite = Console.ReadLine();

            Console.Write("Digite a capacidade da suíte: ");
            int capacidade = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor da diária: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());

            suite = new Suite(tipoSuite, capacidade, valorDiaria);
            Console.WriteLine("Suíte cadastrada com sucesso!");
            break;

        case 2:
            Console.Write("Quantos hóspedes deseja adicionar? ");
            int quantidade = int.Parse(Console.ReadLine());

            for (int contador = 1; contador <= quantidade; contador++)
            {
                Console.Write($"Digite o nome do hóspede {contador}: ");
                string nomeHospede = Console.ReadLine();
                hospedes.Add(new Pessoa(nome: nomeHospede));
            }

            Console.WriteLine("Hóspedes cadastrados com sucesso!");
            break;

        case 3:
            if (suite == null)
            {
                Console.WriteLine("Cadastre uma suíte antes de criar uma reserva.");
            }
            else
            {
                Console.Write("Quantos dias deseja reservar? ");
                int diasReservados = int.Parse(Console.ReadLine());

                reserva = new Reserva(diasReservados);
                reserva.CadastrarSuite(suite);
                reserva.CadastrarHospedes(hospedes);

                Console.WriteLine("Reserva criada com sucesso!");
            }
            break;

        case 4:
            if (reserva == null)
            {
                Console.WriteLine("Nenhuma reserva foi criada ainda.");
            }
            else
            {
                Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
                Console.WriteLine($"Valor da diária total: {reserva.CalcularValorDiaria()}");
            }
            break;

        case 5:
            Console.WriteLine("Saindo...");
            continuar = false;
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

    Console.WriteLine();
}
