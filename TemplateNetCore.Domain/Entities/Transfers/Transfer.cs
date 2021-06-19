using System;
using TemplateNetCore.Domain.Entities.Users;
using TemplateNetCore.Domain.Enums.Transfers;

namespace TemplateNetCore.Domain.Entities.Transfers
{
    public class Transfer : BaseEntity
    {
        public decimal Value { get; set; }
        public Guid FromId { get; set; }
        public User From { get; set; }
        public Guid ToId { get; set; }
        public User To { get; set; }
        public TransferStatus Status { get; set; }
    }
}
