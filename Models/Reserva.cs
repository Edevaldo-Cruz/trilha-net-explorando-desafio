namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public string descricaoErro = "";
        public string Mensagem = "";


        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            bool capacidadeSuite = hospedes.Count <= Suite.Capacidade;
            if (capacidadeSuite == true)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A suíte não é adequada para a quantidade de hospedes");
            }

        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*

            int quantidadeHospedes = 0;
            if (Hospedes != null)
            {
                quantidadeHospedes = Hospedes.Count;
            }
            return quantidadeHospedes;
        }

        public decimal CalcularValorDiaria()
        {

            decimal valor = 0;
            if (Hospedes != null)
            {
                valor = Suite.ValorDiaria * DiasReservados;
                bool promocao10dias = DiasReservados >= 10;

                if (promocao10dias == true)
                {
                    decimal valorComDesconto = Decimal.Multiply(valor, 0.1M);
                    valor = valor - valorComDesconto;
                }
            }


            return valor;
        }
    }
}