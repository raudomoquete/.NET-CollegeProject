using MediatR;

namespace College.Application.Features.Student.Commands
{
    /// <summary>
    /// Comando para agregar un nuevo estudiante.
    /// </summary>
    public class AddStudentCommand : IRequest<AddStudentResult>
    {
        /// <summary>
        /// Obtiene o establece el nombre del estudiante.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del estudiante.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Obtiene o establece el género del estudiante.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del estudiante.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AddStudentCommand"/>.
        /// </summary>
        /// <param name="name">El nombre del estudiante.</param>
        /// <param name="lastName">El apellido del estudiante.</param>
        /// <param name="gender">El género del estudiante.</param>
        /// <param name="birthDate">La fecha de nacimiento del estudiante.</param>
        /// <exception cref="ArgumentException">
        /// Se lanza cuando <paramref name="name"/>, <paramref name="lastName"/> o <paramref name="gender"/> son nulos o están vacíos.
        /// </exception>
        public AddStudentCommand(string name, string lastName, string gender, DateTime birthDate)
        {
            //Validaciones
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(lastName)) 
                throw new ArgumentException("Last Name cannot be null or empty.", nameof(lastName));
            if (string.IsNullOrWhiteSpace(gender))
                throw new ArgumentException("Gender cannot be null or empty.", nameof(gender));


            Name = name;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate.Date;
        }
    }
}
 