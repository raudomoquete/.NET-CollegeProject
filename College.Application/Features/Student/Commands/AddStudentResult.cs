namespace College.Application.Features.Student.Commands
{
    /// <summary>
    /// Resultado del comando para agregar un nuevo estudiante.
    /// </summary>
 
    public class AddStudentResult
    {
        /// <summary>
        /// Obtiene el ID del estudiante.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Obtiene el nombre del estudiante.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene el apellido del estudiante.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Obtiene el género del estudiante.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Obtiene la fecha de nacimiento del estudiante.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Indica si la operación fue exitosa.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensaje adicional sobre el resultado de la operación.
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}
