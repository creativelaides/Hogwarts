namespace Hogwarts.Infrastructure.Identities.Models;

public static class CustomPolicies
{
    public const string SUBJECT_READ = nameof(SUBJECT_READ);
    public const string SUBJECT_CREATE = nameof(SUBJECT_CREATE);
    public const string SUBJECT_UPDATE = nameof(SUBJECT_UPDATE);
    public const string SUBJECT_DELETE = nameof(SUBJECT_DELETE);

    public const string PROFESSOR_READ = nameof(PROFESSOR_READ);
    public const string PROFESSOR_CREATE = nameof(PROFESSOR_CREATE);
    public const string PROFESSOR_UPDATE = nameof(PROFESSOR_UPDATE);
    public const string PROFESSOR_DELETE = nameof(PROFESSOR_DELETE);

    public const string STUDENT_READ = nameof(STUDENT_READ);
    public const string STUDENT_CREATE = nameof(STUDENT_CREATE);
    public const string STUDENT_UPDATE = nameof(STUDENT_UPDATE);
    public const string STUDENT_DELETE = nameof(STUDENT_DELETE);
}
