namespace College.API.ViewModels.StudentInputs
{
    public class UpdateStudentInput
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
