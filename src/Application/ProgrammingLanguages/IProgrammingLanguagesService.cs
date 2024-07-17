using Domain;

namespace Application.ProgrammingLanguages;

public interface IProgrammingLanguagesService
{
    IQueryable<ProgrammingLanguage> GetAll();
}