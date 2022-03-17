using System;
using System.Collections.Generic;

namespace ItIsNotOnlyMe.VectorDinamico
{

    public class Vector
    {
        private IComponente _cadena;

        public Vector(IComponente componente)
        {
            _cadena = componente;
        }

        public Vector(List<IComponente> componentes)
        {
            _cadena = componentes[0];
            for (int i = 1; i < componentes.Count; i++)
                _cadena.Sumar(componentes[i]);
        }

        public bool EsIgual(Vector vector)
        {
            Vector diferencia = MathfVectores.Restar(this, vector);
            return (float)Math.Round(diferencia.ProductoInterno(diferencia), 4) == 0f;
        }

        public void Sumar(Vector vector)
        {
            _cadena.Sumar(vector.NuevaCadna());
        }

        public void Restar(Vector vector)
        {
            _cadena.Restar(vector._cadena);
        }

        public void Multiplicar(float escalar)
        {
            _cadena.Multiplicar(escalar);
        }

        public void Multiplicar(float escalar, IIdentificador identificador)
        {
            _cadena.Multiplicar(escalar, identificador);
        }

        public void Dividir(float escalar)
        {
            _cadena.Dividir(escalar);
        }

        public float ProductoInterno(Vector vector)
        {
            return _cadena.ProductoInterno(vector._cadena);
        }

        private IComponente NuevaCadna()
        {
            return _cadena.Copia();
        }

        public static Vector Nulo()
        {
            return new Vector(new ComponenteNulo());
        }
    }
}
