using Organizations.Contracts.Models.Abstractions;

namespace Organizations.Contracts.Models
{
    /// <summary>
    /// Класс с информацией о перемещении организации
    /// </summary>
    public class OrganizationMoveDto : IEntry<Guid>
    {
        /// <summary>
        /// Идентификатор организации
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Код на который организацию переместили
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Вышестоящая организация на которую переместили
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}
