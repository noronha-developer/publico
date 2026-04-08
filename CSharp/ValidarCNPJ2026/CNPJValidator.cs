using System;

public class CNPJValidator
{
    public static bool ValidarCNPJ2026(string cnpj)
    {
        string cNum = cnpj.ToUpper()
            .Replace(".", "")
            .Replace("/", "")
            .Replace("-", "");

        if (cNum.Length != 14)
            return false;

        int[] peso1 = {5,4,3,2,9,8,7,6,5,4,3,2};
        int[] peso2 = {6,5,4,3,2,9,8,7,6,5,4,3,2};

        int soma = 0;

        // DV1
        for (int i = 0; i < 12; i++)
        {
            soma += CharToValue(cNum[i]) * peso1[i];
        }

        int dv1 = 11 - (soma % 11);
        if (dv1 >= 10)
            dv1 = 0;

        // DV2
        soma = 0;

        for (int i = 0; i < 12; i++)
        {
            soma += CharToValue(cNum[i]) * peso2[i];
        }

        soma += dv1 * peso2[12];

        int dv2 = 11 - (soma % 11);
        if (dv2 >= 10)
            dv2 = 0;

        return
            int.Parse(cNum.Substring(12,1)) == dv1 &&
            int.Parse(cNum.Substring(13,1)) == dv2;
    }

    private static int CharToValue(char c)
    {
        int nAsc = (int)c;

        // 0-9
        if (nAsc >= 48 && nAsc <= 57)
            return nAsc - 48;

        // A-Z
        if (nAsc >= 65 && nAsc <= 90)
            return nAsc - 48;

        return 0;
    }
}