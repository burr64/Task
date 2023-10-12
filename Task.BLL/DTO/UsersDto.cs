namespace Task.BLL.DTO;

public class UsersDto
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Middlename { get; set; }
        public DateTime Birthday { get; set; }

        public string FullName
        {
            get => $"{Surname} {Name} {Middlename}";
        }
    }