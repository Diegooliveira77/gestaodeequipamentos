using System.Collections;
using System.Security.Cryptography;

namespace gestaodeequipamentos.cosoleap

    
    
{
    internal class Program
    {
        static int id = 1;

        static ArrayList ListaIdsEquipamento = new ArrayList();
        static ArrayList ListaNomesEquipamentos = new ArrayList();
        static ArrayList ListaPrecosEquipamentos = new ArrayList();
        static ArrayList ListaNumerosSerieEquipamento = new ArrayList();
        static ArrayList ListaDataFabricacao = new ArrayList();
        static ArrayList ListaFabricanteEquipamento = new ArrayList();

        static void Main(string[] args)
        {
            while (true)
            {
                //apresentar menu principal

                string opcao = ApresentarMenuPrincipa();
                if (opcao == "S")
                    break;
                if (opcao == "1")
                {
                    // apresentar um submenu com o crud de Equipamentos
                    string opcaoCadastroEquipamentos = ApresentarMenuCadastroEquipamento();

                    if (opcaoCadastroEquipamentos == "S")
                        continue;
                    if (opcaoCadastroEquipamentos == "1")
                    {
                        //Inserir novo equipamento
                        InserirNovoEquipamento();
                    }
                    else if (opcaoCadastroEquipamentos == "2")
                    {
                        //visualizar equipamento
                        VisualizarEquipamentos();
                    }
                    else if (opcaoCadastroEquipamentos == "3")
                    {
                        //editar um equipamento
                        EditarEquipamento();
                    }
                    else if (opcaoCadastroEquipamentos == "4")
                    {
                        //excluir equipamento existente
                    }
                }

                {

                }
            }
        }

        static void EditarEquipamento()
        {
            MostrarCabecalho("Cadastro de Equipamentos ", "Editando Equipamento: ");
            VisualizarEquipamentos();
            Console.WriteLine("Digite o Id do Equipamento que deseja Editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            GravarEquipamento(idSelecionado, "Inserir");
            id++;


            apresentarMensagem("Equipamento Editaro com Sucesso!", ConsoleColor.Green);
        }

        // aqui
        static void GravarEquipamento(int id, string tipoOperacao)
        {
            string nome;
            bool nomeInvalido;




            do
            {
                nomeInvalido = false;
                Console.Write("Digite o Nome do Equipamento: ");
                nome = Console.ReadLine();

                if (nome.Length < 6)
                {
                    nomeInvalido = true;
                    apresentarMensagem("Nome inválido, Informe no minimo 6 Letras", ConsoleColor.Red);

                }

            }


            while (nomeInvalido);

            Console.Write("Digite o Nome do Equipamento : ");


            Console.Write("Digite o Preço do Equipamento: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite o Numero de Série: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Digite a Data de Fabricação: ");
            string dataFabricacao = Console.ReadLine();

            Console.Write("Digite o Nome do Fabricante: ");
            string fabricante = Console.ReadLine();

            int posicao = ListaIdsEquipamento.IndexOf(id);

            //inserção
            if (tipoOperacao == "Inserir")
            {
                ListaIdsEquipamento.Add(id);
                ListaNomesEquipamentos.Add(nome);
                ListaPrecosEquipamentos.Add(preco);
                ListaNumerosSerieEquipamento.Add(numeroSerie);
                ListaDataFabricacao.Add(dataFabricacao);
                ListaFabricanteEquipamento.Add(fabricante);

            }

            else if (tipoOperacao == "Editar")
            {
                ListaIdsEquipamento[posicao] = id;
                ListaNomesEquipamentos[posicao] = nome;
                ListaPrecosEquipamentos[posicao] = preco;
                ListaNumerosSerieEquipamento[posicao] = numeroSerie;
                ListaDataFabricacao[posicao] = dataFabricacao;
                ListaFabricanteEquipamento[posicao] = fabricante;
            }

            //ediçao



        }
        //
        static void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();
            Console.WriteLine(titulo);

            Console.WriteLine(subtitulo);
            Console.WriteLine();
            Console.WriteLine();
        }
        static bool VisualizarEquipamentos()
        {
            bool temEquipamentosGravados = VisualizarEquipamentos();
            if (temEquipamentosGravados == false)


                Console.ForegroundColor = ConsoleColor.Red;

            MostrarCabecalho("Cadastro de Equipamentos ", "Inserindo Novo Equipamento: ");

            if (ListaIdsEquipamento.Count == 0)
            {
                apresentarMensagem("Nenhum Equipamento Cadastrado", ConsoleColor.DarkYellow);

                return false;
            }

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", "Id", "Nome", "Fabricante");
            Console.WriteLine("-------------------------------------------------------------------------------");
            for (int i = 0; i < ListaNomesEquipamentos.Count; i++)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", "Id", ListaNomesEquipamentos[i],
                    ListaIdsEquipamento[i],
                    ListaFabricanteEquipamento[i]);
            }
            Console.ResetColor();
            Console.ReadLine();

            return true;

        }

        static int EncontrarEquipamento()
            {
            int idSelecionado = 0;
            do
            {


                Console.WriteLine("Digite o Id do Equipamento que deseja Editar: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
            } while (id== 0);
            return id;
        }

        static void InserirNovoEquipamento()
        {

            Console.Clear();
            Console.WriteLine("Cadastro de Equipamentos ");
            Console.WriteLine("Digite 1 para enseirir um Novo Equipamento");
            Console.WriteLine("Inserindo novo Equipamento:");
            Console.WriteLine();
            Console.WriteLine();
            
            GravarEquipamento(id,"Enserir");
            id++;

         

            apresentarMensagem("Equipamento Inserido com Sucesso", ConsoleColor.Green);

        }

        static void apresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Nenhum Equipamento Cadastrado");
            Console.ResetColor();
            Console.ReadLine();
        }
    

       


        static string ApresentarMenuCadastroEquipamento()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Equipamentos ");
            Console.WriteLine("Digite 1 para enseirir um Novo Equipamento");
            Console.WriteLine("Digite 2 para Visualizar Equipamentos Cadastrados");
            Console.WriteLine("Digite 3 para Editar Equipamentos");
            Console.WriteLine("Digite 4 para excluir Equipamentos");
            Console.WriteLine("Digite S para Voltar ao Menu Principal");

            string opcao = Console.ReadLine();
            return opcao;
        }
        static string ApresentarMenuPrincipa()
        {
            Console.Clear();
            Console.WriteLine("Getão de Equipamentos 1.0");
            Console.WriteLine("Digite 1 para  Cadastrar Equipamentos");
            Console.WriteLine("Digite 2 para Controlar Chamados");
            Console.WriteLine("Digite S para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}