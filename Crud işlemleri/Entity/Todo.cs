namespace Crud_işlemleri.Entity
{
    public class Todo
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool IsCompleted { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
