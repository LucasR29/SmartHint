namespace SmartHint.Models
{
    public class ClientsModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime Cad_date { get; set; }

        public string Cpf { get; set; }

        public string Type { get; set; }

        public bool Exempt { get; set; }
        
        public bool Is_blocked { get; set; }

        public string Password { get; set; }

        public string? State_reg { get; set; }

        public string? Sex { get; set; }

        public DateTime? Birth_Date { get; set; }


    }
}
