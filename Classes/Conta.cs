using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountDio
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private string Name { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        public Conta(TipoConta tipoConta, string name, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Name = name;
            this.Saldo = saldo;
            this.Credito = credito;
        }
        public bool Sacar (double valorSaque)
        { //valida saque
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine($"O valor do saldo Atual na conta {this.Name} é: {this.Saldo}");
            return true;
        }
        public void Depositar (double valorDeposito)
        {//Implementar demonstração do saldo Antes e depois do deposito.
            this.Saldo += valorDeposito;
            Console.WriteLine($"O valor do saldo Atual na conta {this.Name} é: {this.Saldo}");
        }
        public void Transferir (double valorTransferencia, Conta contaDestino)
        {//Impelementar demonstralção de Saldo antes e depois da Transferencia. Confirmar transferencia e dados.
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        public override string ToString()
        {
            string retorno = " ";
            retorno += $"Tipoconta {this.TipoConta} |";
            retorno += $"Nome {this.Name} |";
            retorno += $"Saldo {this.Saldo} |";
            retorno += $"Credito {this.Credito} |";
            return retorno;
        }

    }
}
