using System;
using System.Collections.Generic;
 

namespace BankAccountDio
{
    class Program
    {/* Fazer com que o usuario tenha que logar-se no Banco. Então chamar todas as funções de acordo com a conta logada */
      
       static List<Conta> listContas = new List<Conta>(); //Banco de Dados 
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X") //While que mantém o programa em funcionamento. 
            {
                switch (opcaoUsuario)
                {

                    case "1":
                    ListarConta();
                    break;

                case "2":
                    InserirConta();
                    break;

                case "3":
                    Transferir();
                    break;

                case "4":
                    Sacar();
                    break;

                case "5":
                    Depositar();
                    break;
                case "C":
                    Console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos Serviços");
            Console.ReadLine(); //Pressione uma tecla para encerrar Senão a frase de cima não será vista hehe
        }
        private static void InserirConta()
        {//Futuramente implementar o Tryparse aqui para Assegurar os tipo certos
            Console.WriteLine("Inserir nova Conta");
            Console.Write("Digite 1 para conta Fisica e 2 para conta jurídica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo atual do Cliente");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito do Cliente");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        name: entradaNome);

            listContas.Add(novaConta);

        }
        private static void Transferir()
        {//Futuramente implementar o Tryparse aqui para Assegurar os tipo certos
            Console.Write("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }
        private static void Sacar()
        {//Futuramente implementar o Tryparse aqui para Assegurar os tipo certos
            Console.WriteLine("Digite o numero da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a sacar");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }
        private static void Depositar()
        {//Futuramente implementar o Tryparse aqui para Assegurar os tipo certos
            Console.WriteLine("Digite o numero da Conta");
            int indiceconta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor a Ser depositado");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceconta].Depositar(valorDeposito);
        }

        private static void ListarConta()
        {//Futuramente implementar o Tryparse aqui para Assegurar os tipo certos
            Console.WriteLine("Listar constas");
            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta inserida");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write($"{i} - ");
                Console.WriteLine(conta);
            }



        }
            
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bank AccountDio!!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Contas ");
            Console.WriteLine("2 - Adicionar Conta ");
            Console.WriteLine("3 - Trasnferencia entre Contas ");
            Console.WriteLine("4 - Sacar quantia de Conta ");
            Console.WriteLine("5 - Depositar quantia em Conta ");
            Console.WriteLine("C - Limpar Tela ");
            Console.WriteLine("X - Encerrar aplicação ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }


    }
}
