using System;
using System.IO;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Teatro : Evento
    {
        public string[] Elenco { get; set; }
        public string Diretor { get; set; }

        public Teatro(){}

        public Teatro(string Titulo, string Local, int Lotacao, string Duracao, int Classificacao, DateTime Data, string[] Elenco, string Diretor)
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;

            this.Elenco = Elenco;
            this.Diretor = Diretor;
        }
        public override bool Cadastrar(){
            bool efetuadoTeatro = false;
            StreamWriter arquivoTeatro = null;
            try{
                arquivoTeatro = new StreamWriter("Teatro.csv", true);

                string VariavelElenco = "";

                for(int i=0; i<Elenco.Length; i++){
                    VariavelElenco += Elenco[i];
                    if(i==Elenco.Length){
                    VariavelElenco += "";
                    }
                    else{
                        VariavelElenco += ",";
                    }

                arquivoTeatro.WriteLine(
                            Titulo+";"+
                            Local+";"+
                            Lotacao+";"+
                            Duracao+";"+
                            Classificacao+";"+
                            Data+";"+
                            Diretor+";"+
                            VariavelElenco
                            );

                efetuadoTeatro=true;
                }
            }
            catch(Exception ex){
                throw new Exception("Erro ao tentar gravar o arquivo");
            }
            finally{
                arquivoTeatro.Close();
            }
            return efetuadoTeatro;
        }
    }
}