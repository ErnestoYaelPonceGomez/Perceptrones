using System;

public class XOR
{
    public static void Main(string[] args)
    {
        int fila = 0;
        double w1x1, w2x1, w1x2, w2x2, w1y1, w1y2, wBias1, wBias2, wBias3;
        double factorAprendizaje = 0.5;
        double errorDelta1, errorDelta2, errorDelta3, y1, y2, y3;
        int iteraciones = 0;

        double[][] arregloXOR = {
            new double[] {1, 1, 1},
            new double[] {1, 0, 0},
            new double[] {0, 1, 0},
            new double[] {0, 0, 1}
        };

        Random random = new Random();

        while (fila < 4)
        {
            errorDelta1 = 0;
            errorDelta2 = 0;
            errorDelta3 = 0;
            y1 = 0;
            y2 = 0;
            y3 = 0;
            iteraciones = 0;

            w1x1 = random.NextDouble();
            w2x1 = random.NextDouble();
            w1x2 = random.NextDouble();
            w2x2 = random.NextDouble();
            w1y1 = random.NextDouble();
            w1y2 = random.NextDouble();
            wBias1 = random.NextDouble();
            wBias2 = random.NextDouble();
            wBias3 = random.NextDouble();

            while (iteraciones <= 100000)
            {
                y1 = (arregloXOR[fila][0] * w1x1) + (arregloXOR[fila][1] * w1x2) + (1 * wBias1);
                y2 = (arregloXOR[fila][0] * w2x1) + (arregloXOR[fila][1] * w2x2) + (1 * wBias2);
                y1 = 1.0 / (1 + Math.Pow(Math.E, (-1) * y1));
                y2 = 1.0 / (1 + Math.Pow(Math.E, (-1) * y2));
                y3 = (y1 - w1y1) + (y2 * w1y2) + (1 * wBias3);
                y3 = 1.0 / (1 + Math.Pow(Math.E, (-1) * y3));
                errorDelta3 = (y3 * (1 - y3)) * (arregloXOR[fila][2] - y3);
                w1y1 += factorAprendizaje * errorDelta3 * y1;
                w1y2 += factorAprendizaje * errorDelta3 * y2;
                wBias3 += errorDelta3;
                errorDelta1 = (y1 * (1 - y1)) * errorDelta3 - w1y1;
                errorDelta2 = (y2 * (1 - y2)) * errorDelta3 - w1y2;
                w1x1 += factorAprendizaje * errorDelta1 * arregloXOR[fila][0];
                w1x2 += factorAprendizaje * errorDelta1 * arregloXOR[fila][1];
                wBias1 += errorDelta1;
                w2x1 += factorAprendizaje * errorDelta2 * arregloXOR[fila][0];
                w2x2 += factorAprendizaje * errorDelta2 * arregloXOR[fila][1];
                wBias2 += errorDelta2;
                iteraciones++;
            }

            if (y3 >= 0.9)
            {
                y3 = 1;
            }
            else
            {
                if (y3 <= 0.05)
                {
                    y3 = 0;
                }
            }

            Console.WriteLine($"{(int)arregloXOR[fila][0]}\tXNOR\t{(int)arregloXOR[fila][1]}\t=\t{(int)arregloXOR[fila][2]}\tCalculado: {(int)y3}");
            fila++;
        }
    }
}
