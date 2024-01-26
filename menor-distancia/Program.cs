using System;

class Program
{
    static void Main()
    {
        Console.Write("Informe os números do primeiro array (separados por espaço): ");
        int[] array1 = LerArrayDoUsuario();

        Console.Write("Informe os números do segundo array (separados por espaço): ");
        int[] array2 = LerArrayDoUsuario();

        (int indiceArr1, int indiceArr2, int menorDistancia) = MenorDistancia(array1, array2);

        Console.WriteLine($"A menor distância entre os arrays é: {menorDistancia}");
        Console.WriteLine($"Os números nos índices {indiceArr1} e {indiceArr2} têm a menor distância.");
        Console.WriteLine($"Número do primeiro array: {array1[indiceArr1]}");
        Console.WriteLine($"Número do segundo array: {array2[indiceArr2]}");
    }

    static int[] LerArrayDoUsuario()
    {
        string input = Console.ReadLine();
        string[] numerosString = input.Split(' ');

        // Converte os números de string para int
        int[] array = new int[numerosString.Length];
        for (int i = 0; i < numerosString.Length; i++)
        {
            if (int.TryParse(numerosString[i], out int numero))
            {
                array[i] = numero;
            }
            else
            {
                Console.WriteLine($"O caracter '{numerosString[i]}' não é um número. Tente novamente.");
                Environment.Exit(1);
            }
        }

        return array;
    }

    static (int, int, int) MenorDistancia(int[] arr1, int[] arr2)
    {
        Array.Sort(arr1);
        Array.Sort(arr2);

        int i = 0; // Índice para percorrer arr1
        int j = 0; // Índice para percorrer arr2
        int menorDistancia = int.MaxValue;
        int indiceArr1 = -1;
        int indiceArr2 = -1;

        while (i < arr1.Length && j < arr2.Length)
        {
            int diff = Math.Abs(arr1[i] - arr2[j]);

            // Atualiza a menor distância se encontrarmos uma distância menor
            if (diff < menorDistancia)
            {
                menorDistancia = diff;
                indiceArr1 = i;
                indiceArr2 = j;
            }

            // Avança o índice do array cujo elemento é menor
            if (arr1[i] < arr2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return (indiceArr1, indiceArr2, menorDistancia);
    }
}
