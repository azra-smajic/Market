using Market.Core.Dtos;

namespace Market.Core.Dto
{
    public class PersonDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public byte[] Image { get; set; }
        public string ProfilePhoto { get; set; }
        public string ProfilePhotoThumbnail { get; set; }
        public string Address { get; set; }
        public string AlternativePhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid ApplicationUserId { get; set; }
        public Guid? MarketId { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}