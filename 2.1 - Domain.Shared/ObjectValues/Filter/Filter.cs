using System;

namespace Domain.Shared.ObjectValues
{
    public class Filter : ObjectValue
    { 
        /// <summary>
        /// Condição da sua consulta 
        /// </summary>
        /// <returns></returns>
        public string Condition { get; set; }

        /// <summary>
        /// Campo que gostaria de ordenar
        /// </summary>
        /// <returns></returns>
        public string OrderBy { get; set; }

        /// <summary>
        /// Seleção dos campos
        /// </summary>
        /// <returns></returns>
        public string Select { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Active  { get; set; }

        /// <summary>
        /// Caso deseje ordenar decrescente, se não assumira automatico crescente.
        /// </summary>
        /// <returns></returns>
        public bool SortDesc { get; set; }

        /// <summary>
        /// Index atual
        /// </summary>
        public int Offset { get; set; }

        public string Include { get; set; }

        /// <summary>
        /// Limite de registros por página
        /// </summary>
        private int limit;
        public int Limit
        {
            get { return limit; }
            set
            {
                limit = value > 101 ? 101 : value;
            }
        }        

        /// <summary>
        /// Propriedade utilizada para habilitar o uso apenas dos 
        /// valores de Metadata (Total de Registros, Total de Páginas) sem os dados dos registros. 
        /// </summary>
        internal bool MetaOnly { get; set; }

        public string EmpresaID { get; set; }

        public string GrupoEconomicoID { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Filter()
        {
            Limit = 10;
        }

    }
}