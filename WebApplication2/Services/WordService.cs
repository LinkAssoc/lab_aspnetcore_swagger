namespace WebApplication2.Services
{
    public class WordService : IWordService
    {
        /// <summary>
        /// wdwdwd
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public string[] Generate(char[] letters, int count)
        {
            var rnd = new Random();
            var words = new string[count];
            for (int i = 0; i < count; i++)
            {
                var word = "";
                while (word.Length < count)
                {
                    word += letters[rnd.Next(0, letters.Length - 1)];
                }
                words[i] = word;
            }
            return words;
        }
    }
}
