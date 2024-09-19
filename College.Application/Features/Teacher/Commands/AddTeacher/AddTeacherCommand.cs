using MediatR;

namespace College.Application.Features.Teacher.Command
{
    /// <summary>
    /// Comando para agregar un nuevo profesor.
    /// </summary>
    public class AddTeacherCommand : IRequest<AddTeacherResult>
    {
        /// <summary>
        /// Obtiene o establece el nombre del profesor.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del profesor.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Obtiene o establece el género del profesor.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AddTeacherCommand"/>.
        /// </summary>
        /// <param name="name">El nombre del profesor.</param>
        /// <param name="lastName">El apellido del profesor.</param>
        /// <param name="gender">El género del profesor.</param>
        /// <exception cref="ArgumentException">
        /// Se lanza cuando <paramref name="name"/>, <paramref name="lastName"/> o <paramref name="gender"/> son nulos o están vacíos.
        /// </exception>
        public AddTeacherCommand(string name, string lastName, string gender)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(gender))
            {
                throw new ArgumentException("Name, Last Name, and Gender cannot be null or empty.");
            }

            Name = name;
            LastName = lastName;
            Gender = gender;
        }
    }
}
