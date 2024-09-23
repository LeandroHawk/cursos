using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MVC_Curso.Program;

namespace MVC_Curso
{
    internal class Program
    {


        public class Aluno
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            private List<Disciplina> disciplinasMatriculadas = new List<Disciplina>();

            public bool PodeMatricular(Curso curso)
            {
                return disciplinasMatriculadas.Count < 6;
            }

            public void MatricularDisciplina(Disciplina disciplina)
            {
                if (PodeMatricular(disciplina.Curso))
                {
                    disciplinasMatriculadas.Add(disciplina);
                    disciplina.MatricularAluno(this);
                }
            }

            public void DesmatricularDisciplina(Disciplina disciplina)
            {
                disciplinasMatriculadas.Remove(disciplina);
                disciplina.DesmatricularAluno(this);
            }

            public List<Disciplina> DisciplinasMatriculadas => disciplinasMatriculadas;
        }

        public class Disciplina
        {
            public int Id { get; set; }
            public string Descricao { get; set; }
            private List<Aluno> alunos = new List<Aluno>();

            public Curso Curso { get; set; }

            public bool MatricularAluno(Aluno aluno)
            {
                if (alunos.Count < 15 && !alunos.Contains(aluno))
                {
                    alunos.Add(aluno);
                    return true;
                }
                return false;
            }

            public bool DesmatricularAluno(Aluno aluno)
            {
                return alunos.Remove(aluno);
            }

            public List<Aluno> AlunosMatriculados => alunos;
        }

        public class Curso
        {
            public int Id { get; set; }
            public string Descricao { get; set; }
            private List<Disciplina> disciplinas = new List<Disciplina>();

            public bool AdicionarDisciplina(Disciplina disciplina)
            {
                if (disciplinas.Count < 12)
                {
                    disciplinas.Add(disciplina);
                    disciplina.Curso = this;
                    return true;
                }
                return false;
            }

            public Disciplina PesquisarDisciplina(int id)
            {
                return disciplinas.Find(d => d.Id == id);
            }

            public bool RemoverDisciplina(Disciplina disciplina)
            {
                if (!disciplina.AlunosMatriculados.Any())
                {
                    return disciplinas.Remove(disciplina);
                }
                return false;
            }

            public List<Disciplina> Disciplinas => disciplinas;
        }

        public class Escola
        {
            private List<Curso> cursos = new List<Curso>();

            public bool AdicionarCurso(Curso curso)
            {
                if (cursos.Count < 5)
                {
                    cursos.Add(curso);
                    return true;
                }
                return false;
            }

            public Curso PesquisarCurso(int id)
            {
                return cursos.Find(c => c.Id == id);
            }

            public bool RemoverCurso(Curso curso)
            {
                if (!curso.Disciplinas.Any())
                {
                    return cursos.Remove(curso);
                }
                return false;
            }
        }


        public static void Main(string[] args)
        {
            Escola escola = new Escola();
            int opcao;



            do
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar curso");
                Console.WriteLine("2. Pesquisar curso");
                Console.WriteLine("3. Remover curso");
                Console.WriteLine("4. Adicionar disciplina no curso");
                Console.WriteLine("5. Pesquisar disciplina");
                Console.WriteLine("6. Remover disciplina do curso");
                Console.WriteLine("7. Matricular aluno na disciplina");
                Console.WriteLine("8. Remover aluno da disciplina");
                Console.WriteLine("9. Pesquisar aluno");

                opcao = int.Parse(Console.ReadLine());

                // Implementar lógica para cada opção aqui...

            } while (opcao != 0);
        }

    

    }
}


