using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Show : Evento
    {
        public string Artista { get; set; }
        public string GeneroMusical { get; set; }
        //constrtutor simples e/ou com passagem de dados
        public Show() { } // construtor simples só instancia a sua classe
        public Show(string Titulo, string Local, int Lotacao, string Duracao, int Classificacao, DateTime Data, string Artista, string GeneroMusical)
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;

            this.Artista = Artista;
            this.GeneroMusical = GeneroMusical;
        }

        public override bool Cadastrar()
        {
            bool efetuado = false;
            StreamWriter arquivo = null;
            try
            {
                arquivo = new StreamWriter("show.csv", true); //isso é um CONSTRUTOR
                //TRUE: é para tornar cumulativo, faz um "append", se o arquivo existir, ele apenas adiciona o conteúdo no arquivo existente.
                //TRABALHAR COM STREAMWRITER É CRÍTICO: ELE SÓ CONSEGUE TRABALHAR SE PASSAR O NOME DO ARQUIVO, NÃO PODE SER UM CONSTRUTOR SIMPLES.

                arquivo.WriteLine(//escrever no "arquivo" - NÃO NO CONSOLE
                    Titulo + "," +
                    Local + "," +
                    Duracao + "," +
                    Data + "," +
                    Artista + "," +
                    GeneroMusical + "," +
                    Lotacao + "," +
                    Classificacao);
                    //aqui, o "Titulo" por ex pode ser BASE, THIS ou nada.
                    //"Artista" e "GeneroMusical", não.

                efetuado = true;
            }
            catch(Exception ex){
                throw new Exception("Erro ao tentar gravar o arquivo");
            }
            finally{
                arquivo.Close();
            }
            return efetuado;
        }
        public override string Pesquisar(string Titulo){
            
            string resultado = "Título não encontrado";
            StreamReader ler = null;
            try{//achar o evento/arquivo, e pesquisar nele.
                ler = new StreamReader("show.csv",Encoding.Default);
                string linha = "";
                while((linha=ler.ReadLine())!=null){
                    string [] dados = linha.Split(';'); //o SPLIT separa, olhando para o ponto-e-vírgula. Criando um ARRAY onde pega cada elemento separado por ; e coloca em ordem dentro do ARRAY.
                    if(dados[0]==Titulo){
                        resultado = linha;
                        break;
                    }
                }
            }
            catch(Exception ex){
                resultado = "Erro ao tentar ler o arquivo. "+ex.Message;
            }
            finally{
                ler.Close();
            }
            return resultado;
        }
        public override string Pesquisar(DateTime Data){
            
            string resultado = "Data não encontrada";
            StreamReader ler = null;
            try{//achar o evento/arquivo, e pesquisar nele.
                ler = new StreamReader("show.csv",Encoding.Default);
                string linha = "";
                while((linha=ler.ReadLine())!=null){
                    string [] dados = linha.Split(';'); //o SPLIT separa a linha do arquivo, olhando para o ponto-e-vírgula. Criando um ARRAY onde pega cada elemento separado por ; e coloca em ordem dentro do ARRAY.
                    if(dados[3]==Data.ToString()){
                        resultado = linha;
                        break;
                    }
                }
            }
            catch(Exception ex){
                resultado = "Erro ao tentar ler o arquivo. "+ex.Message;
            }
            finally{
                ler.Close();
            }
            return resultado;
        }
    }
}