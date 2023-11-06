namespace ShareForFuture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserGroup
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public List<User> Users { get; set; } = new();
}

