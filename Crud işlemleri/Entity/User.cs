using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Crud_işlemleri.Entity
{
    public class User:IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
       
        public ICollection<Todo> Todos { get; set; }
    }
}
