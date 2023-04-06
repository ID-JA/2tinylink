using System.Security.Cryptography;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AliasProvider : IAliasProvider
    {
        private const string _lowerLetter = "abcdefghijklmnopqrstuvwxyz";
        private const string _upperLetter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string _specialCharacter = "_-";
        private const string _number = "1234567890";
        private int lowerLetterLength = _lowerLetter.Length;
        private int upperLetterLength = _upperLetter.Length;
        private int specialCharacterLength = _specialCharacter.Length;
        private int numberLength = _number.Length;
        private readonly IAppDbContext _dbContext;

        public AliasProvider(IAppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<string> GetAliasAsync()
        {
            // TODO : Require enhancement to prevent infinite loop
            string alias;
            do
            {
                alias = GenerateAlias();
            }
            while (await _dbContext.TinyLinks.AnyAsync(x => x.Alias == alias));

            return alias;
        }

        public string GenerateAlias()
        {
            int idLength = RandomNumberGenerator.GetInt32(3, 10);

            Span<char> result = idLength < 1024 ? stackalloc char[idLength] : new char[idLength].AsSpan();

            var lastRandomNumberGenerated = -1;

            for (int i = 0; i < idLength; i++)
            {
                var randomNumber = RandomNumberGenerator.GetInt32(4);

                switch (randomNumber)
                {
                    case 0:
                        result[i] = _upperLetter[RandomNumberGenerator.GetInt32(upperLetterLength)];
                        break;
                    case 1:
                        result[i] = _lowerLetter[RandomNumberGenerator.GetInt32(lowerLetterLength)];
                        break;
                    case 2:
                        result[i] = _number[RandomNumberGenerator.GetInt32(numberLength)];
                        break;
                    case 3 when i < idLength - 1 && i > 0 && lastRandomNumberGenerated == 3:
                        result[i] = _specialCharacter[RandomNumberGenerator.GetInt32(specialCharacterLength)];
                        break;
                    default:
                        result[i] = _upperLetter[RandomNumberGenerator.GetInt32(upperLetterLength)];
                        break;
                }

                lastRandomNumberGenerated = randomNumber;
            }

            return result.ToString();
        }
    }
}