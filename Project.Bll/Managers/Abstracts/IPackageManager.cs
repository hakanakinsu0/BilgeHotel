using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// Otelde sunulan konaklama paketleri ile ilgili işlemleri tanımlayan arayüzdür.
    /// Bu arayüz, IManager arayüzünü genişleterek, paketler için genel CRUD işlemlerini sağlar.
    /// </summary>
    public interface IPackageManager : IManager<PackageDto, Package> { }
}
