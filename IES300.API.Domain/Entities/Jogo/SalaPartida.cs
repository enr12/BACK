namespace IES300.API.Domain.Entities.Jogo
{
    public class SalaPartida
    {
        public int IdSala { get; set; }

        public Jogador Jogador1 { get; set; }

        public Jogador Jogador2 { get; set; }

        public DadosPartida DadosPartida { get; set; }

        public DadosPatrocinador DadosPatrocinador { get; set; }
    }
}
