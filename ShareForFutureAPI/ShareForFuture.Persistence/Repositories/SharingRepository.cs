using ShareForFuture.Domain.DomainModels;
using ShareForFututre.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareForFuture.Persistence.Repositories;
public class SharingRepository : GenericRepository<Sharing>, ISharingRepository
{
}
