using System;
using System.Linq;

public class PerceptronOR
{
    public static void Main(string[] args)
    {
        Random random = new Random();

        float[,] tabla = {
            { 1f, -1f, -1f },
            { 1f, -1f,  1f },
            { 1f,  1f, -1f },
            { 1f,  1f,  1f }
        };

        int[] resultados = { -1, 1, 1, 1 };

        double w0 = random.NextDouble();
        double w1 = random.NextDouble();
        double w2 = random.NextDouble();

        double a = random.Next(2, 10) / 10.0;

        double y = 0.0;
        double error = 0.0;
        int fila = 0;
        int repeticion = 1;

        Console.WriteLine("Iteracion 1");
        while (fila < 4)
        {
            y = w0 * tabla[fila, 0] + w1 * tabla[fila, 1] + w2 * tabla[fila, 2];

            Console.WriteLine("y: " + y);

            if (y >= 0)
                y = 1;
            else if (y < 0)
                y = -1;

            Console.WriteLine("y: " + y);

            error = resultados[fila] - y;
            Console.WriteLine("Error: " + error);

            if (error == 0)
                fila++;
            else
            {
                if (error != 0)
                {
                    w0 = w0 + (a * error * tabla[fila, 0]);
                    w1 = w1 + (a * error * tabla[fila, 1]);
                    w2 = w2 + (a * error * tabla[fila, 2]);
                }
                fila = 0;
                repeticion++;

                Console.WriteLine("Iteracion " + repeticion);
            }
        }

        Console.WriteLine("Pesos:");
        Console.WriteLine("Peso 0: " + w0);
        Console.WriteLine("Peso 1: " + w1);
        Console.WriteLine("Peso 2 " + w2);
        Console.WriteLine("OR");
        Console.WriteLine("Ingrese las entradas (Solo se puede ingresar 1 y -1)");
        Console.WriteLine("Entrada 1: ");
        int x1 = Convert.ToInt32(Console.ReadLine());
        while (x1 == 0 || x1 > 1 || x1 < -1)
        {
            Console.WriteLine("Error solo se puede ingresar '1' y '-1'");
            x1 = Convert.ToInt32(Console.ReadLine());
        }

        Console.Write("Entrada 2: ");
        int x2 = Convert.ToInt32(Console.ReadLine());
        while (x2 == 0 || x2 > 1 || x2 < -1)
        {
            Console.WriteLine("Error solo se puede ingresar '1' y '-1'");
            x2 = Convert.ToInt32(Console.ReadLine());
        }

        y = (w0 * 1) + (w1 * x1) + (w2 * x2);

        if (y >= 0)
            Console.WriteLine("Salida: 1");
        else if (y < 0)
            Console.WriteLine("Salida -1");
    }
}
