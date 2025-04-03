using Project.Bll.DtoClasses;
using Project.Entities.Models;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// Ekstra hizmetlere ilişkin işlemleri tanımlayan arayüzdür.
    /// Bu arayüz, IManager arayüzünü genişleterek, ekstra hizmetlerle ilgili genel CRUD işlemlerini sağlar.
    /// </summary>
    public interface IExtraServiceManager : IManager<ExtraServiceDto, ExtraService> { }
}
