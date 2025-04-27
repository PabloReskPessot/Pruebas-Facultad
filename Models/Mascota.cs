namespace Veterinaria.Models
{
    public class Mascota
    {
        public int id { get; set; }
        public string nombre {  get; set; }
        public int edad { get; set; }

        public int id_raza { get; set; }
        public int id_dueño { get; set; }

        public Raza? Raza { get; set; }
        public Dueño? Dueño { get; set; }

    }
}
