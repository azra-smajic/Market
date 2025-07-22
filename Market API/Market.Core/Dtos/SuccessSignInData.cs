namespace Market.Core.Dtos
{
    public class SuccessSignInData
    {
        public Guid Id { get; set; }
        public string? Token { get; set; }
        public string? PhotoUrl { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int ExpireTime { get; set; }
        public bool IsPasswordActivated { get; set; }
        public List<ApplicationUserRoleDto> Roles { get; set; } = new List<ApplicationUserRoleDto>();
        public Guid? MarketId { get; set; }
    }
}