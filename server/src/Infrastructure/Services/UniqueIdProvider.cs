using System.Security.Cryptography;
using Application.Common.Interfaces.Services;

namespace Infrastructure.Services
{
    public class UniqueIdProvider : IUniqueIdProvider
    {
        const string lowerLetter = "abcdefghijklmnopqrstuvwxyz";
        const string upperLetter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string specialCharacter = "_-";
        const string number = "1234567890";
        int lowerLetterLength = lowerLetter.Length;
        int upperLetterLength = upperLetter.Length;
        int specialCharacterLength = specialCharacter.Length;
        int numberLength = number.Length;

        
        public string GetUniqueString()
        {
            int idLength = RandomNumberGenerator.GetInt32(3,10);

            Span<char> result = idLength < 1024 ? stackalloc char[idLength] : new char[idLength].AsSpan();

            var lastRandomNumberGenerated = -1;

            for (int i = 0; i < idLength ; i++)
            {
                var randomNumber = RandomNumberGenerator.GetInt32(4);

                switch (randomNumber)
                {
                    case 0 :
                        result[i] = upperLetter[RandomNumberGenerator.GetInt32(upperLetterLength)];
                        break;
                    case 1 :
                        result[i] = lowerLetter[RandomNumberGenerator.GetInt32(lowerLetterLength)];
                        break;
                    case 2 :
                        result[i] = number[RandomNumberGenerator.GetInt32(numberLength)];
                        break;
                    case 3 when i < idLength - 1 && i > 0 && lastRandomNumberGenerated == 3 :
                        result[i] = specialCharacter[RandomNumberGenerator.GetInt32(specialCharacterLength)];
                        break;
                    default:
                        result[i] = upperLetter[RandomNumberGenerator.GetInt32(upperLetterLength)];
                        break;
                }

                lastRandomNumberGenerated = randomNumber;
            }

            return result.ToString();
        }
    }
}