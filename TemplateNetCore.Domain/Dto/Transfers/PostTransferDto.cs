using System.ComponentModel.DataAnnotations;

namespace TemplateNetCore.Domain.Dto.Transfers
{
    public class PostTransferDto
    {
        [Required(ErrorMessage = "O valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor não pode ser negativo")]
        public decimal Value { get; set; }

        public string FromKey { get; set; }

        [Required(ErrorMessage = "A chave do destinatário é obrigatória")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "A chave do destinatário precisa ter exatamente 11 caracteres")]
        public string ToKey { get; set; }
    }
}
