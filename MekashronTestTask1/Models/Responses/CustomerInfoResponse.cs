namespace MekashronTestTask1.Models.Responses
{
    public class CustomerInfoResponse : ResponseBase
    {
        public int EntityId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Company { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string Zip { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool EmailConfirm { get; set; }

        public bool MobileConfirm { get; set; }

        public int CountryID { get; set; }

        public int Status { get; set; }

        public string lid { get; set; } = string.Empty;

        public string FTPHost { get; set; } = string.Empty;

        public int FTPPort { get; set; }
    }
}
