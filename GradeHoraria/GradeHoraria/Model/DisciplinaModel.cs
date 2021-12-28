using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeHoraria.Model
{
    class DisciplinaModel
    {
        public DisciplinaModel(string nomeDisciplina, string siglaDisciplina, bool tipo, string periodicidade, string n_aulasSemana, string n_aulasDia)
        {
            NomeDisciplina = nomeDisciplina;
            SiglaDisciplina = siglaDisciplina;
            Tipo = tipo;
            Periodicidade = periodicidade;
            N_aulasSemana = n_aulasSemana;
            N_aulasDia = n_aulasDia;
        }

        public DisciplinaModel()
        {
          
        }

        public string NomeDisciplina { get; set; }
        public string SiglaDisciplina { get; set; }
        bool Tipo { get; set; } 
        public string Periodicidade { get; set; }
        public string N_aulasSemana { get; set; }
        public string N_aulasDia { get; set; }
    }
}
