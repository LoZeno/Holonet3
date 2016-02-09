using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Holonet3.Utilities
{
	public enum encryptables
	{
		account,
		holodisk,
		notizia,
		rubrica,
		missioni,
		altro,
		nulla,
		files,
	}

    public static class Encryption
    {
        public static string ReturnEncryptedText(string inputText)
        {
            StringBuilder res = new StringBuilder();
            Random randomizer = new Random();
            for (long i = 0; i < inputText.Length; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * randomizer.NextDouble() + 65)));
				if (i % 25 == 0)
				{
					res.AppendLine(ch.ToString());
				}
				else
				{
					res.Append(ch);
				}
            }

            return res.ToString();
        }

        public static bool DecyrptMessage(long livelloDecrittatore, long livelloDifficolta)
        {
            bool res = false;

            long chances = 10 + (livelloDecrittatore * 20);
            chances -= (livelloDifficolta * 10);
            if (chances < 1)
            {
                chances = 1;
            }
            Random randomizer = new Random();
            int tentativo = randomizer.Next(0, 99);
            if (tentativo <= chances)
            {
                res = true;
            }

            return res;
        }


    }
}