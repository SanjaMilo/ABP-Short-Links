using System;
using System.ComponentModel.DataAnnotations;

namespace LinkStore.Links;

public class CreateUpdateLinkDto
{
    [Required]
    [MinLength(100)]
    public string Original { get; set; } = string.Empty;

    [Required]
    public string Short { get; set; } = string.Empty;

    [Required]
    public string IdPart { get; set; } = string.Empty;

}