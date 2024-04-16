using System.Text;

namespace Project_MLD.Utils.GenerateCode
{
    public class GenerateCode : IGenerateCode
    {

        public string GenerateRandomCode()
        {
            const string upperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numberChars = "0123456789";

            StringBuilder code = new StringBuilder();
            Random random = new Random();

            // Generate one uppercase letter
            code.Append(upperCaseChars[random.Next(upperCaseChars.Length)]);

            // Generate one number
            code.Append(numberChars[random.Next(numberChars.Length)]);

            // Generate the rest of the code with uppercase letters and numbers
            for (int i = 0; i < 6; i++)
            {
                string allChars = upperCaseChars + numberChars;

                // Ensure that the random index is within the bounds of the combined set
                if (allChars.Length > 0)
                {
                    code.Append(allChars[random.Next(allChars.Length)]);
                }
            }

            // Shuffle the code to ensure randomness
            string shuffledCode = new string(code.ToString().OrderBy(x => random.Next()).ToArray());

            return shuffledCode;
        }
    }
}
