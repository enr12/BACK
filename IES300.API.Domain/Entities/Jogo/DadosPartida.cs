namespace IES300.API.Domain.Entities.Jogo
{
    public class DadosPartida
    {
        public DadosPartida()
        {
            int altura = 6;
            int largura = 7;

            for (int i = 0; i < (altura * largura); i++)
            {
                this.MapaTabuleiro[i] = 0;
            }
            this.VezJogador = 0;
            this.Ganhador = 0;
        }

        public int[] MapaTabuleiro { get; set; } // começa com zero e cada jogada muda para: 1 => P1 / 2 => P2

        public int VezJogador { get; set; } // 1 => P1 / 2 => P2

        public int Ganhador { get; set; } // 0 => ninguém / 1 => P1 / 2 => P2
    }
}
