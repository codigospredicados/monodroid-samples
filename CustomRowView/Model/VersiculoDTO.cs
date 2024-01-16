namespace MyBible
{
    public class VersiculoDTO
    {
        public int Id { get; set; }
        public int TestamentoId { get; set; }
        public string Testamento { get; set; }
        public int LivroId { get; set; }
        public string Livro { get; set; }
        public string Abreviatura { get; set; }
        public int Capitulo { get; set; }
        public int Versiculo { get; set; }
        public string Texto { get; set; }
        public string Obs { get; set; }
    }
}