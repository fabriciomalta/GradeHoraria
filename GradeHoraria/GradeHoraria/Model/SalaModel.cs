using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeHoraria.Model
{
    class SalaModel
    {
        public SalaModel(string nomeSala, string siglaSala, int quantidade, int tipo)
        {
            NomeSala = nomeSala;
            SiglaSala = siglaSala;
            Quantidade = quantidade;
            Tipo = tipo;

        }

        public SalaModel()
        {
            
        }

        public string NomeSala { get; set; }
        public string SiglaSala { get; set; }
        public int Quantidade { get; set; }
        public int Tipo { get; set; }

    }
}
