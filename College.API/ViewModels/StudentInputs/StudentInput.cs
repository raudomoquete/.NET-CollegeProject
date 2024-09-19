namespace College.API.ViewModels.StudentInputs
{
    public record StudentInput(
        string StudentName,
        string StudentLastName,
        string StudentGender,
        DateTime StudentBirthDate
    );
}
