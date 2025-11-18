namespace gestor_notas.DTO
{
    public class NotaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdMateria { get; set; }
        public int IdEstudiante { get; set; }
        public decimal Valor { get; set; }
        public string MateriaNombre { get; set; }
        public string EstudianteNombre { get; set; }
    }
}