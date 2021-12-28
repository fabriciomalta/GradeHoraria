using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeHoraria.Model
{
    class ProfessorModel
    {
        public ProfessorModel(string nomeProfessor, string idProfessor, string prontuário, bool sexo, string area, string n_aulasDocente, string n_aulasDia)
        {
            NomeProfessor = nomeProfessor;
            IdProfessor = idProfessor;
            Prontuário = prontuário;
            Sexo = sexo;
            Area = area;
            N_aulasDocente = n_aulasDocente;
            N_aulasDia = n_aulasDia;
        }

        public ProfessorModel()
        {
        
        }

        public string NomeProfessor { get; set; }
        public string IdProfessor { get; set; }
        public string Prontuário { get; set; }
        bool Sexo { get; set; }
        public string Area { get; set; }
        public string N_aulasDocente { get; set; }
        public string N_aulasDia { get; set; }
    }
}
