using Market.Core.Entities.BaseEntity;
using Market.Core.Entities.Identity;
using Market.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Market.Core.Entities
{
    public class Person : BaseEntity.BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gender { get; set; }
        public string? ProfilePhoto { get; set; }
        public string? ProfilePhotoThumbnail { get; set; }
        public string? Address { get; set; }
        public string? AlternativePhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid? MarketId { get; set; }
        public MarketEntity Market { get; set; }
    }
}