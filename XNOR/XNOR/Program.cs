using System;

namespace com.mycompany.neurona
{
    public class XNOR
    {
        public static void Main(string[] args)
        {
            double[][] arregloXNOR = {
                new double[] {1, 1, 1},
                new double[] {1, 0, 0},
                new double[] {0, 1, 0},
                new double[] {0, 0, 1}
            };

            double factorAprendizaje = 0.5;
            int fila = 0;

            while (fila < 4)
            {
                double[] pesos = GenerarPesosAleatorios();

                for (int iteraciones = 1; iteraciones <= 500; iteraciones++)
                {
                    double y1 = CalcularSalidaNeuronaOculta(arregloXNOR[fila], pesos[0], pesos[1], pesos[6]);
                    double y2 = CalcularSalidaNeuronaOculta(arregloXNOR[fila], pesos[2], pesos[3], pesos[7]);
                    y1 = AplicarFuncionSigmoide(y1);
                    y2 = AplicarFuncionSigmoide(y2);
                    double y3Calculado = CalcularSalidaNeuronaSalida(y1, y2, pesos[4], pesos[5], pesos[8]);
                    y3Calculado = AplicarFuncionSigmoide(y3Calculado);

                    double errorDelta3 = (y3Calculado * (1 - y3Calculado)) * (arregloXNOR[fila][2] - y3Calculado);
                    pesos[4] += factorAprendizaje * errorDelta3 * y1;
                    pesos[5] += factorAprendizaje * errorDelta3 * y2;
                    pesos[8] += errorDelta3;

                    double errorDelta1 = (y1 * (1 - y1)) * errorDelta3 - pesos[4];
                    double errorDelta2 = (y2 * (1 - y2)) * errorDelta3 - pesos[5];
                    pesos[0] += factorAprendizaje * errorDelta1 * arregloXNOR[fila][0];
                    pesos[1] += factorAprendizaje * errorDelta1 * arregloXNOR[fila][1];
                    pesos[6] += errorDelta1;
                    pesos[2] += factorAprendizaje * errorDelta2 * arregloXNOR[fila][0];
                    pesos[3] += factorAprendizaje * errorDelta2 * arregloXNOR[fila][1];
                    pesos[7] += errorDelta2;
                }

                double y3Final = CalcularSalidaFinal(arregloXNOR[fila], pesos);
                Console.WriteLine($"{(int)arregloXNOR[fila][0]}\tXNOR\t{(int)arregloXNOR[fila][1]}\t=\t{(int)arregloXNOR[fila][2]}\tCalculado: {(int)y3Final}");
                fila++;
            }
        }

        public static double[] GenerarPesosAleatorios()
        {
            double[] pesos = new double[9];
            Random random = new Random();
            for (int i = 0; i < pesos.Length; i++)
            {
                pesos[i] = random.NextDouble();
            }
            return pesos;
        }

        public static double CalcularSalidaNeuronaOculta(double[] entrada, double w1, double w2, double wBias)
        {
            return (entrada[0] * w1) + (entrada[1] * w2) + (1 * wBias);
        }

        public static double AplicarFuncionSigmoide(double x)
        {
            return 1.0 / (1 + Math.Pow(Math.E, (-1) * x));
        }

        public static double CalcularSalidaNeuronaSalida(double y1, double y2, double w1y1, double w1y2, double wBias)
        {
            return (y1 * w1y1) + (y2 * w1y2) + (1 * wBias);
        }

        public static double CalcularSalidaFinal(double[] entrada, double[] pesos)
        {
            double y1 = CalcularSalidaNeuronaOculta(entrada, pesos[0], pesos[1], pesos[6]);
            double y2 = CalcularSalidaNeuronaOculta(entrada, pesos[2], pesos[3], pesos[7]);
            y1 = AplicarFuncionSigmoide(y1);
            y2 = AplicarFuncionSigmoide(y2);
            return CalcularSalidaNeuronaSalida(y1, y2, pesos[4], pesos[5], pesos[8]);
        }
    }
}
