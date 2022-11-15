namespace WebApplication2.Services
{
    public interface IWordService
    {
        string[] Generate(char[] letters, int count);
    }
}
