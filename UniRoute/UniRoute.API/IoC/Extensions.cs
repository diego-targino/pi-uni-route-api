using FluentValidation;
using UniRoute.API.ModelValidators.Student;

namespace UniRoute.API.IoC;

public static class Extensions
{
    public static void AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateStudentModelValidator>();
    }

    public static void AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
