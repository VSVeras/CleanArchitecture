using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Dominio.Padroes
{
    //Uma solução ao invés do Pattern Null Object
    //https://blog.ploeh.dk/2018/03/26/the-maybe-functor/
    public struct Talvez<T>
    {
        readonly IEnumerable<T> _valores;

        public static Talvez<T> Algum(T value)
        {
            if (value == null)
            {
                throw new InvalidOperationException();
            }

            return new Talvez<T>(new[] { value });
        }

        public static Talvez<T> Nenhum => new Talvez<T>(new T[0]);

        private Talvez(IEnumerable<T> valores)
        {
            _valores = valores;
        }

        public bool Achou => _valores != null && _valores.Any();

        public T Valor
        {
            get
            {
                if (!Achou)
                {
                    throw new InvalidOperationException("Talvez não tenha um valor");
                }

                return _valores.Single();
            }
        }
    }
}
