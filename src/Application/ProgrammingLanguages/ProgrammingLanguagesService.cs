using Domain;
using Infrastructure;

namespace Application.ProgrammingLanguages;

internal sealed class ProgrammingLanguagesService(AppDbContext dbContext) : IProgrammingLanguagesService
{
    public IQueryable<ProgrammingLanguage> GetAll() => dbContext.ProgrammingLanguages.AsQueryable();
}