using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeHoraria.Model
{
    class ProfessorModel
    {
        public string NomeProfessor { get; set; }
        public string Prontuário { get; set; }
        bool Sexo { get; set; }
        public string Area { get; set; }
        public string N_aulasDocente { get; set; }
        public string N_aulasDia { get; set; }
    }
}
