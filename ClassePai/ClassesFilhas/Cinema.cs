using System;
using System.IO;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Cinema : Evento
    {
        public string Genero { get; set; }
        public DateTime[] Sessao { get; set; }

        public Cinema(){}

        public Cinema(string Titulo, string Local, int Lotacao, string Duracao, int Classificacao, string Genero, DateTime[] Sessao)
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;

            this.Genero = Genero;
            this.Sessao = Sessao;
        }
        public override bool Cadastrar(){
            bool efetuadoCinema = false;
            StreamWriter arquivoCinema = null;
            try{
                arquivoCinema = new StreamWriter("Teatro.csv", true);

                string VariavelSessao = "";

                for(int i=0; i<Sessao.Length; i++){
                    VariavelSessao += Sessao[i];
                    if(i==Sessao.Length){
                    VariavelSessao += "";
                    }
                    else{
                        VariavelSessao += ",";
                    }

                arquivoCinema.WriteLine(
                            Titulo+";"+
                            Local+";"+
                            Lotacao+";"+
                            Duracao+";"+
                            Classificacao+";"+
                            Data+";"+
                            Genero+";"+
                            VariavelSessao
                            );

                efetuadoCinema=true;
                }
            }
            catch(Exception ex){
                throw new Exception("Erro ao tentar gravar o arquivo");
            }
            finally{
                arquivoCinema.Close();
            }
            return efetuadoCinema;
        }
    }
}