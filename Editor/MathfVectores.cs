using UnityEngine;

namespace ItIsNotOnlyMe.VectorDinamico
{
    public static class MathfVectores
    {
        public static Vector Sumar(Vector vector, Vector otro)
        {
            Vector resultado = Duplicar(vector);
            resultado.Sumar(otro);
            return resultado;
        }

        public static Vector Restar(Vector vector, Vector otro)
        {
            Vector resultado = Duplicar(vector);
            resultado.Restar(otro);
            return resultado;
        }

        public static Vector Multiplicar(Vector vector, float escalar)
        {
            Vector resultado = Duplicar(vector);
            resultado.Multiplicar(escalar);
            return resultado;
        }

        public static Vector Multiplicar(Vector vector, float escalar, IIdentificador identificador)
        {
            Vector resultado = Duplicar(vector);
            resultado.Multiplicar(escalar, identificador);
            return resultado;
        }

        public static Vector Dividir(Vector vector, float escalar)
        {
            Vector resultado = Duplicar(vector);
            resultado.Dividir(escalar);
            return resultado;
        }

        public static float Distancia(Vector vector, Vector otro)
        {
            Vector direccion = Restar(vector, otro);
            return Modulo(direccion);
        }

        public static float Similitud(Vector vector, Vector otro)
        {
            return Normalizar(vector).ProductoInterno(Normalizar(otro));
        }

        public static float Multiplicdad(Vector vector, Vector otro)
        {
            Vector proyeccion = Proyeccion(vector, otro);

            float moduloPropio = Modulo(vector);
            float moduloProyeccion = Modulo(proyeccion);

            if (moduloPropio == 0f)
                return 0f;
            return Mathf.Sign(Similitud(vector, otro)) * (moduloProyeccion / moduloPropio);
        }

        public static Vector Proyeccion(Vector vector, Vector otro)
        {
            float moduloCuadrado = vector.ProductoInterno(vector);
            float escalar = (moduloCuadrado == 0f) ? 0f : vector.ProductoInterno(otro) / moduloCuadrado;
            return Multiplicar(vector, escalar);
        }

        public static Vector Normalizar(Vector vector)
        {
            float modulo = Modulo(vector);
            return Dividir(vector, modulo);
        }

        public static float Modulo(Vector vector)
        {
            return Mathf.Sqrt(vector.ProductoInterno(vector));
        }

        private static Vector Duplicar(Vector vector)
        {
            Vector resultado = Vector.Nulo();
            resultado.Sumar(vector);
            return resultado;
        }
    }
}
