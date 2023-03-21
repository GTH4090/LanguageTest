using System;
using System.Collections.Generic;

namespace LanguageDesktop.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int Genderid { get; set; }

    public string Phonenum { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly Regdate { get; set; }

    public virtual Gender Gender { get; set; } = null!;
}
