﻿using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    /// <summary>
    /// Package işlemleri için iş mantığını yöneten manager sınıfıdır.
    /// Temel CRUD işlemleri BaseManager üzerinden sağlanır.
    /// </summary>
    public class PackageManager : BaseManager<PackageDto, Package>, IPackageManager
    {
        readonly IPackageRepository _repository;
        public PackageManager(IPackageRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
    }
}
