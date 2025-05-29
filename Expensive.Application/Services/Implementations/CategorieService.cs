using Expensive.Application.Repository.Contract;
using Expensive.Application.Services.Contracts;
using Expensive.Domain.Entities;

namespace Expensive.Application.Services.Implementations;

public class CategorieService(IUnitOfWork unitOfWork) : Service<Categories>(unitOfWork), ICategorieService
{
}