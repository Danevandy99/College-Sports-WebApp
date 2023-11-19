using Microsoft.EntityFrameworkCore;

namespace College_Sports_Domain.Models;

[Owned]
public class HrefWrapper
{
    public required string href { get; set; }
}