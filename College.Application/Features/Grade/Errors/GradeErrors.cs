using College.Application.Common;

namespace College.Application.Features.Grade.Errors
{
    public static class GradeErrors
    {
        public static readonly Error NameAlreadyExists = new Error(
            "Grade.NameAlreadyExists", "A grade with the same name already exists.");

        public static readonly Error CreationFailed = new Error(
            "Grade.CreationFailed", "Failed to create the grade.");

        public static Error NotFound(Guid id) => new Error(
            "Grade.NotFound", $"The grade with Id '{id}' was not found.");
    }
}
