
using System;

namespace GestaodeEquipamentosJP.ConsoleApp
{
    internal class Program
    {
        #region Declaração de variáveis globais
        //Variáveis relacionadas aos equipamentos
        static int[] idsDosEquipamentos = new int[1000];
        static string[] nomesDosEquipamentos = new string[1000];
        static decimal[] precosDeAquisicaoDosEquipamentos = new decimal[1000];
        static int[] numerosDeSerieDosEquipamentos = new int[1000];
        static DateTime[] datasDeFabricacaoDosEquipamentos = new DateTime[1000];
        static string[] fabricantesDosEquipamentos = new string[1000];
        static bool[] equipamentoTemChamado = new bool[1000];
        //Variáveis relacionadas aos chamados
        static int[] idsDosChamados = new int[1000];
        static string[] titulosDosChamados = new string[1000];
        static string[] descricaoDosChamados = new string[1000];
        static DateTime[] datasDeAberturaDosChamados = new DateTime[1000];
        static DateTime[] datasDeFechamentoDosChamados = new DateTime[1000];
        static int[] posicaoDoEquipamentoNoArrayDeChamado = new int[1000];
        static int[] idsDosEquipamentosDentroDosChamados = new int[1000];
        static int[] idsDosSolicitantesDentroDosChamados = new int[1000];
        static string[] statusDosChamados = new string[1000];
        //Variáveis relacionadas aos solictates
        static int[] idsDosSolicitantes = new int[1000];
        static string[] nomesDosSolicitantes = new string[1000];
        static string[] emailDosSolicitantes = new string[1000];
        static string[] telefoneDosSolicitantes = new string[1000];
        static bool[] solicitanteTemChamado = new bool[1000];

        //Variáveis de fluxo do programa
        static bool programaContinuaExecutando = true;

        #endregion

        static void Main(string[] args)
        {
            while (programaContinuaExecutando == true)
            {
                ApresentaTelaInicial();
            }
        }

        #region Métodos auxiliares
        static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------\n");
            Console.WriteLine(mensagem);
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }

        static string TransformarDateTimeEmString(DateTime data)
        {
            string retorno = "";
            string dia = data.Day.ToString();
            string mes = data.Month.ToString();
            string ano = data.Year.ToString();
            retorno = dia + "/" + mes + "/" + ano;
            return retorno;
        }

        static DateTime TransformaStringEmDateTime(string data)
        {
            string[] dataSeparada = new string[3];
            dataSeparada = data.Split("/");
            int dia = int.Parse(dataSeparada[0]);
            int mes = int.Parse(dataSeparada[1]);
            int ano = int.Parse(dataSeparada[2]);
            DateTime dataDeRetorno = new DateTime(ano, mes, dia);
            return dataDeRetorno;
        }

        static string[] DeletarUmElementoDeUmArrayDeStrings(string[] arrayAhSerReduzido, int posicaoDeRemocao)
        {
            string[] arrayTemporario = new string[arrayAhSerReduzido.Length];
            int j = 0;
            for (int i = 0; i < arrayAhSerReduzido.Length; i++)
            {
                if (i != posicaoDeRemocao)
                {
                    arrayTemporario[j] = arrayAhSerReduzido[i];
                    j++;
                }
            }
            return arrayTemporario;
        }

        static int[] DeletarUmElementoDeUmArrayDeInteiros(int[] arrayAhSerReduzido, int posicaoDeRemocao)
        {
            int[] arrayTemporario = new int[arrayAhSerReduzido.Length];
            int j = 0;
            for (int i = 0; i < arrayAhSerReduzido.Length; i++)
            {
                if (i != posicaoDeRemocao)
                {
                    arrayTemporario[j] = arrayAhSerReduzido[i];
                    j++;
                }
            }
            return arrayTemporario;
        }

        static decimal[] DeletarUmElementoDeUmArrayDeDecimais(decimal[] arrayAhSerReduzido, int posicaoDeRemocao)
        {
            decimal[] arrayTemporario = new decimal[arrayAhSerReduzido.Length];
            int j = 0;
            for (int i = 0; i < arrayAhSerReduzido.Length; i++)
            {
                if (i != posicaoDeRemocao)
                {
                    arrayTemporario[j] = arrayAhSerReduzido[i];
                    j++;
                }
            }
            return arrayTemporario;
        }

        static DateTime[] DeletarUmElementoDeUmArrayDeDateTime(DateTime[] arrayAhSerReduzido, int posicaoDeRemocao)
        {
            DateTime[] arrayTemporario = new DateTime[arrayAhSerReduzido.Length - 1];
            int j = 0;
            for (int i = 0; i < arrayAhSerReduzido.Length; i++)
            {
                if (i != posicaoDeRemocao)
                {
                    arrayTemporario[j] = arrayAhSerReduzido[i];
                    j++;
                }
            }
            return arrayTemporario;
        }

        static bool[] DeletarUmElementoDeUmArrayDeBooleanos(bool[] arrayAhSerReduzido, int posicaoDeRemocao)
        {
            bool[] arrayTemporario = new bool[arrayAhSerReduzido.Length - 1];
            int j = 0;
            for (int i = 0; i < arrayAhSerReduzido.Length; i++)
            {
                if (i != posicaoDeRemocao)
                {
                    arrayTemporario[j] = arrayAhSerReduzido[i];
                    j++;
                }
            }
            return arrayTemporario;
        }

        #endregion

        #region Métodos para apresentar as telas
        static void ApresentaTelaInicial()
        {
            bool opcaoValida = false;
            do
            {
                Console.Clear();
                ApresentarMensagem("OLÁ!! SEJA BEM VINDO AO SISTEMA DE GESTÃO DE EQUIPAMENTOS AP-2022", ConsoleColor.White);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\n\t\tMENU PRINCIPAL");
                Console.WriteLine("\n * Digite 1 para Gerenciar os equipamentos;");
                Console.WriteLine("\n * Digite 2 para Gerenciar os chamados;");
                Console.WriteLine("\n * Digite 3 para Gerenciar os solicitantes; ");
                Console.WriteLine("\n * Digite 0 para Sair do sistema;");
                Console.Write("\n * Sua escolha: ");
                string escolha = Console.ReadLine();
                if (int.TryParse(escolha, out int opcao) && opcao >= 0 && opcao <= 3)
                {
                    opcaoValida = true;
                    ExecutaAhOpcaoEscolhidaNoMenuPrincipal(opcao);
                }
                else
                {
                    opcaoValida = false;
                    ApresentarMensagem("OPÇÃO INVÁLIDA!! DIGITE UM NÚMERO DE 0 A 3!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (opcaoValida == false);
            Console.ResetColor();
        }

        static void ApresentaTelaGerenciarSolicitantes()
        {
            bool opcaoValida = false;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\n\t\tMENU GERENCIAR SOLICITANTES");
                Console.WriteLine("\n * Digite 1 para Registrar um novo solicitante;");
                Console.WriteLine("\n * Digite 2 para Editar um solicitante;");
                Console.WriteLine("\n * Digite 3 para Excluir um solicitante; ");
                Console.WriteLine("\n * Digite 4 para Vizualizar todos os solicitantes cadastrados; ");
                Console.WriteLine("\n * Digite 0 para Retornar ao Menu principal;");
                Console.Write("\n * Sua escolha: ");
                string escolha = Console.ReadLine();
                if (int.TryParse(escolha, out int opcao) && opcao >= 0 && opcao <= 4)
                {
                    opcaoValida = true;
                    ExecutaAhOpcaoEscolhidaNoMenuGerenciarSolicitantes(opcao);
                }
                else
                {
                    opcaoValida = false;
                    ApresentarMensagem("OPÇÃO INVÁLIDA!! DIGITE UM NÚMERO DE 0 A 4!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (opcaoValida == false);
            Console.ResetColor();
        }

        static void ApresentaTelaGerenciarChamados()
        {
            bool opcaoValida = false;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\tMENU GERENCIAR CHAMADOS");
                Console.WriteLine("\n * Digite 1 para Registrar um novo chamado;");
                Console.WriteLine("\n * Digite 2 para Editar um chamado;");
                Console.WriteLine("\n * Digite 3 para Excluir um chamado; ");
                Console.WriteLine("\n * Digite 4 para Vizualizar todos os chamados registrados; ");
                Console.WriteLine("\n * Digite 5 para Vizualizar todos os chamados em aberto; ");
                Console.WriteLine("\n * Digite 6 para Vizualizar todos os já fechados; ");
                Console.WriteLine("\n * Digite 7 para fechar um chamado em aberto; ");
                Console.WriteLine("\n * Digite 8 para Alterar o solicitante de um chamado; ");
                Console.WriteLine("\n * Digite 0 para Retornar ao Menu principal;");
                Console.Write("\n * Sua escolha: ");
                string escolha = Console.ReadLine();
                if (int.TryParse(escolha, out int opcao) && opcao >= 0 && opcao <= 8)
                {
                    opcaoValida = true;
                    ExecutaAhOpcaoEscolhidaNoMenuGerenciarChamados(opcao);
                }
                else
                {
                    opcaoValida = false;
                    ApresentarMensagem("OPÇÃO INVÁLIDA!! DIGITE UM NÚMERO DE 0 A 4!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (opcaoValida == false);
            Console.ResetColor();
        }

        static void ApresentaTelaGerenciarEquipamentos()
        {
            bool opcaoValida = false;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
                Console.WriteLine("\t\tMENU GERENCIAR EQUIPAMENTOS");
                Console.WriteLine("\n * Digite 1 para Registrar um novo equipamento;");
                Console.WriteLine("\n * Digite 2 para Editar um equipamento;");
                Console.WriteLine("\n * Digite 3 para Excluir um equipamento; ");
                Console.WriteLine("\n * Digite 4 para Vizualizar todos os equipamentos cadastrados; ");
                Console.WriteLine("\n * Digite 0 para Retornar ao Menu principal;");
                Console.Write("\n * Sua escolha: ");
                string escolha = Console.ReadLine();
                if (int.TryParse(escolha, out int opcao) && opcao >= 0 && opcao <= 4)
                {
                    opcaoValida = true;
                    ExecutaAhOpcaoEscolhidaNoMenuGerenciarEquipamentos(opcao);
                }
                else
                {
                    opcaoValida = false;
                    ApresentarMensagem("OPÇÃO INVÁLIDA!! DIGITE UM NÚMERO DE 0 A 4!!", ConsoleColor.Red);
                    Console.WriteLine("\n\nTECLE ENTER PARA CONTINUARMOS\n");
                    Console.ReadLine();
                }
            } while (opcaoValida == false);
            Console.ResetColor();
        }

        #endregion

        #region Métodos que executam as escolhas do usuário nos menus
        static void ExecutaAhOpcaoEscolhidaNoMenuGerenciarEquipamentos(int opcaoEscolhida)
        {
            switch (opcaoEscolhida)
            {
                case 0:
                    ApresentaTelaInicial();
                    break;
                case 1:
                    RegistrarUmEquipamento();
                    break;
                case 2:
                    EditarUmEquipamento();
                    break;
                case 3:
                    ExcluirUmEquipamento();
                    break;
                case 4:
                    VisualizarTodosOsEquipamentos();
                    break;
            }
        }

        static void ExecutaAhOpcaoEscolhidaNoMenuPrincipal(int opcaoEscolhida)
        {
            switch (opcaoEscolhida)
            {
                case 0:
                    SairDoSistema();
                    break;
                case 1:
                    ApresentaTelaGerenciarEquipamentos();
                    break;
                case 2:
                    ApresentaTelaGerenciarChamados();
                    break;
                case 3:
                    ApresentaTelaGerenciarSolicitantes();
                    break;
            }
        }

        static void ExecutaAhOpcaoEscolhidaNoMenuGerenciarChamados(int opcaoEscolhida)
        {
            switch (opcaoEscolhida)
            {
                case 0:
                    ApresentaTelaInicial();
                    break;
                case 1:
                    RegistrarUmChamado();
                    break;
                case 2:
                    EditarUmChamado();
                    break;
                case 3:
                    ExcluirUmChamado();
                    break;
                case 4:
                    VisualizarTodosOsChamados();
                    break;
                case 5:
                    VisualizarChamadosAbertos();
                    break;
                case 6:
                    VisualizarChamadosFechados();
                    break;
                case 7:
                    FecharChamado();
                    break;
                case 8:
                    AlterarSolicitanteDoChamado();
                    break;
            }
        }

        static void ExecutaAhOpcaoEscolhidaNoMenuGerenciarSolicitantes(int opcaoEscolhida)
        {
            switch (opcaoEscolhida)
            {
                case 0:
                    ApresentaTelaInicial();
                    break;
                case 1:
                    RegistrarUmSolicitante();
                    break;
                case 2:
                    EditarUmSolicitante();
                    break;
                case 3:
                    ExcluirUmSolicitante();
                    break;
                case 4:
                    VisualizarTodosOsSolicitantes();
                    break;
            }
        }

        static void SairDoSistema()
        {
            programaContinuaExecutando = false;
        }

        #endregion

        #region Métodos dos equipamentos
        static void RegistrarUmEquipamento()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("\n\n\t\tREGISTRO DE EQUIPAMENTOS\n");
            int posicaoParaRegistrar = RetornaAhPosicaoLivreDoArrayDeEquipamentos();
            bool registrou = PedeOsDadosDoEquipamentoEhColocaEmUmaPosicao(posicaoParaRegistrar, "registrar");
            if (registrou == true)
            {
                ApresentarMensagem("EQUIPAMENTO REGISTRADO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                Console.ReadLine();
            }
            else
            {
                ApresentarMensagem("FALHA NO REGISTRO DO EQUIPAMENTO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                Console.ReadLine();
            }
        }

        static void EditarUmEquipamento()
        {
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeEquipamentos();
            if (posicaoLivre != 0)
            {
                bool idValido = false;
                int idDoEquipamento = -1;
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\n\n\t\tEDIÇÃO DE EQUIPAMENTOS\n\n");
                do
                {
                    Console.Write("Informe o Id do equipamento que deseja editar: ");
                    string idInputado = Console.ReadLine();
                    if (int.TryParse(idInputado, out int idDoUsuario) == true)
                    {
                        if (RetornaAhPosicaoDoEquipamentoPeloId(idDoUsuario) != -1)
                        {
                            idDoEquipamento = RetornaAhPosicaoDoEquipamentoPeloId(idDoUsuario);
                            idValido = true;
                            Console.WriteLine("\n\nESTE É O EQUIPAMENTO A SER EDITADO:\n\n");
                            VisualizarUmEquipamento(idDoEquipamento);
                            bool confirmacaoInputEdicaoValida = false;
                            do
                            {
                                Console.Write("\n\nCONFIRMA A EDIÇÃO? (S/N) ");
                                string confirmacaoEdicao = Console.ReadLine();
                                if (confirmacaoEdicao == "S" || confirmacaoEdicao == "s")
                                {
                                    confirmacaoInputEdicaoValida = true;
                                    bool editou = PedeOsDadosDoEquipamentoEhColocaEmUmaPosicao(idDoEquipamento, "editar");
                                    if (editou == true)
                                    {
                                        ApresentarMensagem("EQUIPAMENTO EDITADO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        ApresentarMensagem("FALHA NA EDIÇÃO DO EQUIPAMENTO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                        Console.ReadLine();
                                    }
                                }
                                else if (confirmacaoEdicao == "N" || confirmacaoEdicao == "n")
                                {
                                    confirmacaoInputEdicaoValida = true;
                                    ApresentarMensagem("O EQUIPAMENTO NÃO FOI EDITADO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Yellow);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                    Console.ReadLine();
                                }
                            } while (confirmacaoInputEdicaoValida == false);
                        }
                        else
                        {
                            ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                        Console.ReadLine();
                    }
                } while (idValido == false);
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI EQUIPAMENTOS!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                Console.ReadLine();
            }
        }

        static void ExcluirUmEquipamento()
        {
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeEquipamentos();
            if (posicaoLivre != 0)
            {
                bool idValido = false;
                int idDoEquipamento = -1;
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\n\n\t\tEXCLUIR UM EQUIPAMENTO NO SITEMA\n");
                do
                {
                    Console.Write("Informe o Id do equipamento que deseja excluir: ");
                    string idInputado = Console.ReadLine();
                    if (int.TryParse(idInputado, out int idDoUsuario) == true)
                    {
                        if (RetornaAhPosicaoDoEquipamentoPeloId(idDoUsuario) != -1)
                        {
                            idDoEquipamento = RetornaAhPosicaoDoEquipamentoPeloId(idDoUsuario);
                            idValido = true;
                            Console.WriteLine("\n\nESTE É O EQUIPAMENTO A SER EXCLUÍDO:\n\n");
                            VisualizarUmEquipamento(idDoEquipamento);
                            if (equipamentoTemChamado[idDoEquipamento] == false)
                            {
                                bool confirmacaoInputExclusao = false;
                                do
                                {
                                    Console.Write("\n\nCONFIRMA A EXCLUSÃO? (S/N): ");
                                    string confirmacaoExclusao = Console.ReadLine();
                                    if (confirmacaoExclusao == "S" || confirmacaoExclusao == "s")
                                    {
                                        nomesDosEquipamentos = DeletarUmElementoDeUmArrayDeStrings(nomesDosEquipamentos, idDoEquipamento);
                                        precosDeAquisicaoDosEquipamentos = DeletarUmElementoDeUmArrayDeDecimais(precosDeAquisicaoDosEquipamentos, idDoEquipamento);
                                        numerosDeSerieDosEquipamentos = DeletarUmElementoDeUmArrayDeInteiros(numerosDeSerieDosEquipamentos, idDoEquipamento);
                                        datasDeFabricacaoDosEquipamentos = DeletarUmElementoDeUmArrayDeDateTime(datasDeFabricacaoDosEquipamentos, idDoEquipamento);
                                        fabricantesDosEquipamentos = DeletarUmElementoDeUmArrayDeStrings(fabricantesDosEquipamentos, idDoEquipamento);
                                        equipamentoTemChamado = DeletarUmElementoDeUmArrayDeBooleanos(equipamentoTemChamado, idDoEquipamento);
                                        idsDosEquipamentos = DeletarUmElementoDeUmArrayDeInteiros(idsDosEquipamentos, idDoEquipamento);
                                        confirmacaoInputExclusao = true;
                                        ApresentarMensagem("O EQUIPAMENTO FOI EXCLUÍDO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                        Console.ReadLine();
                                    }
                                    else if (confirmacaoExclusao == "N" || confirmacaoExclusao == "n")
                                    {
                                        confirmacaoInputExclusao = true;
                                        ApresentarMensagem("VOCÊ DECIDIU NÃO EXLUIR O EQUIPAMENTO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Yellow);
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                        Console.ReadLine();
                                    }
                                } while (confirmacaoInputExclusao == false);
                            }
                            else
                            {
                                ApresentarMensagem("NÃO FOI POSSÍVEL EXCLUIR O EQUIPAENTO, POIS ELE ESTÁ VINCULADO A UM CHAMADO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                        Console.ReadLine();
                    }
                } while (idValido == false);
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI EQUIPAMENTOS!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                Console.ReadLine();
            }
        }

        static int RetornaAhPosicaoDoEquipamentoPeloId(int id)
        {
            int posicaoAhRetornar = -1;
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeEquipamentos();
            for (int i = 0; i < posicaoLivre; i++)
            {
                if (idsDosEquipamentos[i] == id)
                {
                    posicaoAhRetornar = i;
                    break;
                }
            }
            return posicaoAhRetornar;
        }

        static int RetornaAhPosicaoLivreDoArrayDeEquipamentos()
        {
            int posicaoLivre = -1;
            for (int i = 0; i < nomesDosEquipamentos.Length; i++)
            {
                if (nomesDosEquipamentos[i] == null)
                {
                    posicaoLivre = i;
                    break;
                }
            }
            return posicaoLivre;
        }

        static void VisualizarUmEquipamento(int posicao)
        {
            Console.WriteLine("\nId do equipamento: {0}", idsDosEquipamentos[posicao]);
            Console.WriteLine("\nNome do equipamento: {0}", nomesDosEquipamentos[posicao]);
            Console.WriteLine("\nPreço de aquisição do equipamento: {0}", precosDeAquisicaoDosEquipamentos[posicao]);
            Console.WriteLine("\nNúmero de série do equipamento: {0}", numerosDeSerieDosEquipamentos[posicao]);
            Console.WriteLine("\nData de fabricação do equipamento: {0}", TransformarDateTimeEmString(datasDeFabricacaoDosEquipamentos[posicao]));
            Console.WriteLine("\nFabricante do equipamento: {0}", fabricantesDosEquipamentos[posicao]);
            Console.WriteLine("\nO equipamento tem chamado? {0}", equipamentoTemChamado[posicao]);
        }

        static void VisualizarTodosOsEquipamentos()
        {
            Console.Clear();
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeEquipamentos();
            if (posicaoLivre != 0)
            {
                Console.WriteLine("\t\tVISUALIZAR TODOS OS EQUIPAMENTOS REGISTRADOS NO SISTEMA\n");
                for (int i = 0; i < posicaoLivre; i++)
                {
                    //if ternário escolhendo uma cor se for par e uma cor se for ímpar
                    Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.DarkCyan : ConsoleColor.DarkYellow;
                    VisualizarUmEquipamento(i);
                }
                Console.ResetColor();
            }
            else
            {
                ApresentarMensagem("O SISTEMA AINDA NÃO POSSUI EQUIPAMENTOS REGISTRADOS!!", ConsoleColor.Red);
            }
            Console.WriteLine("\n\nTECLE ENTER PARA CONTINUARMOS\n");
            Console.ReadLine();
        }

        static bool PedeOsDadosDoEquipamentoEhColocaEmUmaPosicao(int posicao, string formaDeUso)
        {
            bool nomeValido = false, precoValido = false, numeroDeSerieValido = false, fabricanteValido = false, dataFabricacaoValida = false;
            string nomeEquipamento = "", fabricante = "", dataFabricacao = "";
            decimal precoDeAquisicao = -1;
            int numeroDeSerie = -1;
            DateTime dataFabricacaoDT = new DateTime(01, 01, 01);
            do
            {
                Console.Write("\nInforme o nome do equipamento com no mínimo 6 (seis) caracteres: ");
                nomeEquipamento = Console.ReadLine();
                if (nomeEquipamento.Length >= 6)
                {
                    nomeValido = true;
                }
                else
                {
                    ApresentarMensagem("O NOME DO EQUIPAMENTO DEVE TER PELO MENOS 6 CARACTERES!!\n" +
                        "\n\n\nTECLE ENTER PARA CONTINUARMOS!!", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (nomeValido == false);
            do
            {
                Console.Write("\nInforme o preço de aquisição do equipamento: ");
                if (decimal.TryParse(Console.ReadLine(), out precoDeAquisicao) && precoDeAquisicao >= 0)
                {
                    precoValido = true;
                }
                else
                {
                    ApresentarMensagem("PRECO INVÁLIDO!! INFORME SOMENTE NÚMEROS POSITIVOS!!" +
                        "\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (precoValido == false);
            do
            {
                Console.Write("\nInforme o número de série do equipamento: ");
                if (int.TryParse(Console.ReadLine(), out numeroDeSerie) && numeroDeSerie >= 0)
                {
                    numeroDeSerieValido = true;
                }
                else
                {
                    ApresentarMensagem("NÚMERO DE SÉRIE INVÁLIDO!! INFORME SOMENTE NÚMEROS POSITIVOS!!" +
                        "\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (numeroDeSerieValido == false);
            do
            {
                Console.Write("\nInforme a data de fabricação do equipamento no formato (DD/MM/AAAA): ");
                dataFabricacao = Console.ReadLine();
                if (dataFabricacao.Length == 10 && dataFabricacao.Contains("/"))
                {
                    dataFabricacaoDT = TransformaStringEmDateTime(dataFabricacao);
                    dataFabricacaoValida = true;
                }
                else
                {
                    ApresentarMensagem("DATA INVÁLIDA!! INFORME UMA DATA NO SEGUINTE FORMATO (DD/MM/AAAA)\n" +
                        "\n\nTECLE ENTER PARA CONTINUARMOS!!", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (dataFabricacaoValida == false);
            do
            {
                Console.Write("\nInforme o nome do fabricante do equipamento: ");
                fabricante = Console.ReadLine();
                if (nomeEquipamento.Length > 0)
                {
                    fabricanteValido = true;
                }
                else
                {
                    ApresentarMensagem("O NOME DO FABRICANTE NÃO PODE SER VAZIO!!\n" +
                        "\n\nTECLE ENTER PARA CONTINUARMOS!!", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (fabricanteValido == false);
            //int posicaoParaRegistrar = RetornaAhPosicaoLivreDoArrayDeEquipamentos();
            nomesDosEquipamentos[posicao] = nomeEquipamento;
            precosDeAquisicaoDosEquipamentos[posicao] = precoDeAquisicao;
            numerosDeSerieDosEquipamentos[posicao] = numeroDeSerie;
            datasDeFabricacaoDosEquipamentos[posicao] = dataFabricacaoDT;
            fabricantesDosEquipamentos[posicao] = fabricante;
            if (formaDeUso == "registrar")
            {
                equipamentoTemChamado[posicao] = false;
                //Registrando o id sendo a posicao + 1
                idsDosEquipamentos[posicao] = posicao + 1;
            }
            if (nomeValido == precoValido && precoValido == numeroDeSerieValido && numeroDeSerieValido == fabricanteValido && fabricanteValido == dataFabricacaoValida && dataFabricacaoValida == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Métodos dos chamados
        static void FecharChamado()
        {
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeChamados();
            if (posicaoLivre != 0)
            {
                bool idValido = false;
                int idDoChamado = -1;
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\n\n\t\tFECHAR UM CHAMADO NO SISTEMA\n");
                do
                {
                    Console.Write("Informe o Id do chamado que deseja fechar: ");
                    string idInputado = Console.ReadLine();
                    if (int.TryParse(idInputado, out int idDoUsuario) == true)
                    {
                        if (RetornaAhPosicaoDoChamadoPeloId(idDoUsuario) != -1)
                        {
                            idDoChamado = RetornaAhPosicaoDoChamadoPeloId(idDoUsuario);
                            idValido = true;
                            if (statusDosChamados[idDoChamado] == "aberto")
                            {
                                Console.WriteLine("\n\nESTE É O CHAMADO A SER FECHADO:\n\n");
                                VisualizarUmChamado(idDoChamado);
                                bool confirmacaoInputFechamentoValido = false;
                                do
                                {
                                    Console.Write("\n\nCONFIRMA O FECHAMENTO? (S/N): ");
                                    string confirmacaoFechamento = Console.ReadLine();
                                    if (confirmacaoFechamento == "S" || confirmacaoFechamento == "s")
                                    {
                                        statusDosChamados[idDoChamado] = "fechado";
                                        datasDeFechamentoDosChamados[idDoChamado] = DateTime.Today;
                                        confirmacaoInputFechamentoValido = true;
                                        ApresentarMensagem("O CHAMADO FOI FECHADO (NA DATA DE HOJE) COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                        Console.ReadLine();
                                    }
                                    else if (confirmacaoFechamento == "N" || confirmacaoFechamento == "n")
                                    {
                                        confirmacaoInputFechamentoValido = true;
                                        ApresentarMensagem("O CHAMADO CONTINUARÁ ABERTO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Yellow);
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                        Console.ReadLine();
                                    }
                                } while (confirmacaoInputFechamentoValido == false);
                            }
                            else
                            {
                                ApresentarMensagem("O CHAMADO INFORMADO JÁ SE ENCONTRA FECHADO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Yellow);
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                        Console.ReadLine();
                    }
                } while (idValido == false);
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI CHAMADOS!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                Console.ReadLine();
            }
        }

        static void VisualizarTodosOsChamados()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("\n\n\t\tVISUALIZAR TODOS OS CHAMADOS REGISTRADOS NO SISTEMA");
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeChamados();
            if (posicaoLivre != 0)
            {
                for (int i = 0; i < posicaoLivre; i++)
                {
                    //if ternário escolhendo uma cor se for par e uma cor se for ímpar
                    Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.DarkCyan : ConsoleColor.DarkYellow;
                    VisualizarUmChamado(i);
                }
                Console.ResetColor();
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI CHAMADOS REGISTRADOS!!", ConsoleColor.Red);
            }
            Console.WriteLine("\n\nTECLE ENTER PARA CONTINUARMOS");
            Console.ReadLine();
        }

        static void VisualizarChamadosFechados()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("\n\n\t\tVISUALIZAR TODOS OS CHAMADOS FECHADOS\n");
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeChamados(), quantidadeDeChamadosFechados = 0, corAtual = 0;
            if (posicaoLivre != 0)
            {
                for (int i = 0; i < posicaoLivre; i++)
                {
                    //if ternário escolhendo uma cor se for par e uma cor se for ímpar
                    Console.ForegroundColor = (corAtual % 2 == 0) ? ConsoleColor.DarkCyan : ConsoleColor.DarkYellow;
                    if (statusDosChamados[i] == "fechado")
                    {
                        VisualizarUmChamado(i);
                        quantidadeDeChamadosFechados++;
                        corAtual++;
                    }
                }
                if (quantidadeDeChamadosFechados == 0)
                {
                    ApresentarMensagem("O SISTEMA NÃO POSSUI NENHUM CHAMADO FECHADO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                    Console.ReadLine();
                }
                Console.ResetColor();
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI CHAMADOS REGISTRADOS!!", ConsoleColor.Red);
            }
            Console.WriteLine("\n\nTECLE ENTER PARA CONTINUARMOS");
            Console.ReadLine();
        }

        static void VisualizarChamadosAbertos()
        {

            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("\n\n\n\t\tVISUALIZAR TODOS OS CHAMADOS ABERTPS\n");
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeChamados(), quantidadeDeChamadosAbertos = 0, corAtual = 0;
            if (posicaoLivre != 0)
            {
                for (int i = 0; i < posicaoLivre; i++)
                {
                    //if ternário escolhendo uma cor se for par e uma cor se for ímpar
                    Console.ForegroundColor = (corAtual % 2 == 0) ? ConsoleColor.DarkCyan : ConsoleColor.DarkYellow;
                    if (statusDosChamados[i] == "aberto")
                    {
                        VisualizarUmChamado(i);
                        quantidadeDeChamadosAbertos++;
                        corAtual++;
                    }
                }

                if (quantidadeDeChamadosAbertos == 0)
                {
                    ApresentarMensagem("O SISTEMA NÃO POSSUI NENHUM CHAMADO EM ABERTO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                    Console.ReadLine();
                }
                Console.ResetColor();
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI CHAMADOS REGISTRADOS!!", ConsoleColor.Red);
            }
            Console.WriteLine("\n\nTECLE ENTER PARA CONTINUARMOS");
            Console.ReadLine();


        }

        static void ExcluirUmChamado()
        {
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeChamados();
            if (posicaoLivre != 0)
            {
                bool idValido = false;
                int idDoChamado = -1;
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\n\n\t\tEXCLUIR UM CHAMADO NO SISTEMA\n");
                do
                {
                    Console.Write("Informe o Id do chamado que deseja excluir: ");
                    string idInputado = Console.ReadLine();
                    if (int.TryParse(idInputado, out int idDoUsuario) == true)
                    {
                        if (RetornaAhPosicaoDoChamadoPeloId(idDoUsuario) != -1)
                        {
                            idDoChamado = RetornaAhPosicaoDoChamadoPeloId(idDoUsuario);
                            idValido = true;
                            Console.WriteLine("\n\nESTE É O CHAMADO A SER EXCLUÍDO:\n\n");
                            VisualizarUmChamado(idDoChamado);
                            bool confirmacaoInputExclusaoValida = false;
                            do
                            {
                                Console.Write("\n\nCONFIRMA A EXCLUSÃO? (S/N): ");
                                string confirmacaoExclusao = Console.ReadLine();
                                if (confirmacaoExclusao == "S" || confirmacaoExclusao == "s")
                                {
                                    titulosDosChamados = DeletarUmElementoDeUmArrayDeStrings(titulosDosChamados, idDoChamado);
                                    descricaoDosChamados = DeletarUmElementoDeUmArrayDeStrings(descricaoDosChamados, idDoChamado);
                                    idsDosChamados = DeletarUmElementoDeUmArrayDeInteiros(idsDosChamados, idDoChamado);
                                    datasDeAberturaDosChamados = DeletarUmElementoDeUmArrayDeDateTime(datasDeAberturaDosChamados, idDoChamado);
                                    equipamentoTemChamado[RetornaAhPosicaoDoEquipamentoPeloId(idsDosEquipamentosDentroDosChamados[idDoChamado])] = false;
                                    idsDosEquipamentosDentroDosChamados = DeletarUmElementoDeUmArrayDeInteiros(idsDosEquipamentosDentroDosChamados, idDoChamado);
                                    idsDosSolicitantesDentroDosChamados = DeletarUmElementoDeUmArrayDeInteiros(idsDosSolicitantesDentroDosChamados, idDoChamado);
                                    confirmacaoInputExclusaoValida = true;
                                    ApresentarMensagem("O CHAMADO FOI EXCLUÍDO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                    Console.ReadLine();
                                }
                                else if (confirmacaoExclusao == "N" || confirmacaoExclusao == "n")
                                {
                                    confirmacaoInputExclusaoValida = true;
                                    ApresentarMensagem("O CHAMADO NÃO FOI EXCLUÍDO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Yellow);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Yellow);
                                    Console.ReadLine();
                                }
                            } while (confirmacaoInputExclusaoValida == false);
                        }
                        else
                        {
                            ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                        Console.ReadLine();
                    }
                } while (idValido == false);
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI CHAMADOS!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                Console.ReadLine();
            }
        }

        static void EditarUmChamado()
        {
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeChamados();
            if (posicaoLivre != 0)
            {
                bool idValido = false;
                int idDoChamado = -1;
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\n\n\t\tEDITAR UM CHAMADO NO SISTEMA\n");
                do
                {
                    Console.Write("Informe o Id do chamado que deseja editar: ");
                    string idInputado = Console.ReadLine();
                    if (int.TryParse(idInputado, out int idDoUsuario) == true)
                    {
                        if (RetornaAhPosicaoDoChamadoPeloId(idDoUsuario) != -1)
                        {
                            //int idDoEquipamento = -1;
                            idDoChamado = RetornaAhPosicaoDoChamadoPeloId(idDoUsuario);
                            idValido = true;
                            Console.WriteLine("\n\nESTE É O CHAMADO A SER EDITADO:\n\n");
                            VisualizarUmChamado(idDoChamado);

                            bool confirmacaoInputEdicaoValida = false;
                            do
                            {
                                Console.Write("\n\nCONFIRMA A EDIÇÃO? (S/N): ");
                                string confirmacaoEdicao = Console.ReadLine();
                                if (confirmacaoEdicao == "S" || confirmacaoEdicao == "s")
                                {
                                    confirmacaoInputEdicaoValida = true;
                                    bool editou = PedeOsDadosDoChamadoEhColocaEmUmaPosicao(idDoChamado, "edição");
                                    if (editou == true)
                                    {
                                        ApresentarMensagem("O CHAMADO FOI EDITADO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                        Console.ReadLine();
                                    }
                                }
                                else if (confirmacaoEdicao == "N" || confirmacaoEdicao == "n")
                                {
                                    confirmacaoInputEdicaoValida = true;
                                    ApresentarMensagem("O CHAMADO NÃO FOI EDITADO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Yellow);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    ApresentarMensagem("ENTRADA INÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                    Console.ReadLine();
                                }
                            } while (confirmacaoInputEdicaoValida == false);
                        }
                        else
                        {
                            ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                        Console.ReadLine();
                    }
                } while (idValido == false);
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI CHAMADOS!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                Console.ReadLine();
            }
        }

        static void AlterarSolicitanteDoChamado()
        {
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeChamados();
            if (posicaoLivre != 0)
            {
                bool idValidoDoChamadoValido = false, idDoNovoSolicitanteValido = false;
                int idDoChamado = -1;
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\n\n\t\tEDITAR O SOLICITANTE DE UM CHAMADO\n");
                do
                {
                    Console.Write("Informe o Id do chamado para troca de solicitantes: ");
                    string idInputado = Console.ReadLine();
                    if (int.TryParse(idInputado, out int idDoUsuario) == true)
                    {
                        if (RetornaAhPosicaoDoChamadoPeloId(idDoUsuario) != -1)
                        {
                            idDoChamado = RetornaAhPosicaoDoChamadoPeloId(idDoUsuario);
                            idValidoDoChamadoValido = true;
                            Console.WriteLine("\n\nESTE É O CHAMADO EM SUA FORMA ATUAL:\n\n");
                            VisualizarUmChamado(idDoChamado);
                            bool confirmacaoInputaEdicaoDeSolicitanteValida = false;
                            do
                            {
                                Console.Write("\n\nDESEJA MESMO ALTERAR O SOLICITANTE DESTE CHAMADO? (S/N): ");
                                string confirmacaoEdicaoSolicitante = Console.ReadLine();
                                if (confirmacaoEdicaoSolicitante == "S" || confirmacaoEdicaoSolicitante == "s")
                                {
                                    confirmacaoInputaEdicaoDeSolicitanteValida = true;
                                    do
                                    {
                                        Console.Write("\nInforme o Id do novo solicitante que deseja anexar a este chamado: ");
                                        string idDoNovoSolicitanteInputado = Console.ReadLine();
                                        if (int.TryParse(idDoNovoSolicitanteInputado, out int novoIdDoUsuario) == true)
                                        {
                                            if (RetornaAhPosicaoDoSolicitantePeloId(novoIdDoUsuario) != -1)
                                            {
                                                idsDosSolicitantesDentroDosChamados[idDoChamado] = novoIdDoUsuario;
                                                idDoNovoSolicitanteValido = true;
                                                ApresentarMensagem("O CHAMADO TEVE O SOLICITANTE ALTERADO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                                Console.ReadLine();
                                            }
                                            else
                                            {
                                                ApresentarMensagem("O ID DE NOVO SOLICITANTE INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                                Console.ReadLine();
                                            }
                                        }
                                        else
                                        {
                                            ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                            Console.ReadLine();
                                        }
                                    } while (idDoNovoSolicitanteValido == false);
                                }
                                else if (confirmacaoEdicaoSolicitante == "N" || confirmacaoEdicaoSolicitante == "n")
                                {
                                    confirmacaoInputaEdicaoDeSolicitanteValida = true;
                                    ApresentarMensagem("O SOLICITANTE PERMANECERÁ O MESMO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Yellow);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                    Console.ReadLine();
                                }
                            } while (confirmacaoInputaEdicaoDeSolicitanteValida == false);
                        }
                        else
                        {
                            ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                        Console.ReadLine();
                    }
                } while (idValidoDoChamadoValido == false);
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI CHAMADOS!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                Console.ReadLine();
            }
        }

        static void RegistrarUmChamado()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("\n\n\t\tREGISTRO DE CHAMADOS\n");
            if (RetornaAhPosicaoLivreDoArrayDeEquipamentos() != 0)
            {
                if (RetornaAhPosicaoLivreDoArrayDeSolicitantes() != 0)
                {
                    int posicaoParaRegistrar = RetornaAhPosicaoLivreDoArrayDeChamados();
                    bool registrou = PedeOsDadosDoChamadoEhColocaEmUmaPosicao(posicaoParaRegistrar, "registrar");
                    if (registrou == true)
                    {
                        ApresentarMensagem("CHAMADO REGISTRADO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                        Console.ReadLine();
                    }
                    else
                    {
                        ApresentarMensagem("FALHA NO REGISTRO DO CHAMADO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                        Console.ReadLine();
                    }
                }
                else
                {
                    ApresentarMensagem("O SISTEMA AINDA NÃO POSSUI SOLICITANTES, PORTANTO NÃO PODEMOS REGISTRAR CHAMADOS!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                    Console.ReadLine();
                }
            }
            else
            {
                ApresentarMensagem("O SISTEMA AINDA NÃO POSSUI EQUIPAMENTOS, PORTANTO NÃO PODEMOS REGISTRAR CHAMADOS!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                Console.ReadLine();
            }
        }

        static int RetornaAhPosicaoLivreDoArrayDeChamados()
        {
            int posicaoLivre = -1;
            for (int i = 0; i < titulosDosChamados.Length; i++)
            {
                if (titulosDosChamados[i] == null)
                {
                    posicaoLivre = i;
                    break;
                }
            }
            return posicaoLivre;
        }

        static bool PedeOsDadosDoChamadoEhColocaEmUmaPosicao(int posicao, string formaDeUso)
        {
            bool tituloValido = false, descricaoValida = false, dataAberturaValida = false, idDoEquipamentoValido = false, idDoSolicitanteValido = false, retorno = false;
            string tituloChamado = "", descricaoChamado = "", dataAbertura = "", idEquipamentoInput = "", idSolicitanteInput = "";
            DateTime dataAberturaDT = new DateTime(01, 01, 01);
            int posicaoDoEquipamentoNoArrayDeEquipamentos = -1, posicaoDoSolicitanteNoArrayDeSolicitantes = -1, idDoEquipamentoDoUsuario = -1, idDoSolicitanteDoUsuario = -1;
            do
            {
                Console.Write("\nInforme o título do chamado: ");
                tituloChamado = Console.ReadLine();
                if (tituloChamado.Length > 0)
                {
                    tituloValido = true;
                }
                else
                {
                    ApresentarMensagem("O TÍTULO DO CHAMADO NÃO PODE SER VAZIO!!\n\nTECLE ENTER PARA CONTINUARMOS!!", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (tituloValido == false);
            do
            {
                Console.Write("\nInforme a descrição do chamado: ");
                descricaoChamado = Console.ReadLine();
                if (descricaoChamado.Length > 0)
                {
                    descricaoValida = true;
                }
                else
                {
                    ApresentarMensagem("A DESCRIÇÃO DO CHAMADO NÃO PODE SER VAZIA!!\n\nTECLE ENTER PARA CONTINUARMOS!!", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (descricaoValida == false);
            do
            {
                Console.Write("\nInforme a data de abertura do chamado no formato (DD/MM/AAAA): ");
                dataAbertura = Console.ReadLine();
                if (dataAbertura.Length == 10 && dataAbertura.Contains("/"))
                {
                    dataAberturaDT = TransformaStringEmDateTime(dataAbertura);
                    dataAberturaValida = true;
                }
                else
                {
                    ApresentarMensagem("DATA INVÁLIDA!! INFORME UMA DATA NO SEGUINTE FORMATO (DD/MM/AAAA)!!\n\nTECLE ENTER PARA CONTINUARMOS!!", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (dataAberturaValida == false);
            if (formaDeUso == "registrar")
            {
                do
                {
                    Console.Write("\nInforme o id do equipamento a ser incluso no chamado: ");
                    idEquipamentoInput = Console.ReadLine();
                    if (int.TryParse(idEquipamentoInput, out idDoEquipamentoDoUsuario) == true)
                    {
                        posicaoDoEquipamentoNoArrayDeEquipamentos = RetornaAhPosicaoDoEquipamentoPeloId(idDoEquipamentoDoUsuario);
                        if (posicaoDoEquipamentoNoArrayDeEquipamentos != -1)
                        {
                            Console.WriteLine("\n\nESTE É O EQUIPAMENTO A SER INCLUSO NO CHAMADO:\n\n");
                            VisualizarUmEquipamento(posicaoDoEquipamentoNoArrayDeEquipamentos);
                            bool confirmacaoInputEquipamentoValido = false;
                            do
                            {
                                Console.Write("\n\nCONFIRMA A INCLUSAO? (S/N) ");
                                string confirmacaoEquipamento = Console.ReadLine();
                                if (confirmacaoEquipamento == "S" || confirmacaoEquipamento == "s")
                                {
                                    equipamentoTemChamado[posicaoDoEquipamentoNoArrayDeEquipamentos] = true;
                                    idDoEquipamentoValido = true;
                                    confirmacaoInputEquipamentoValido = true;
                                    ApresentarMensagem("EQUIPAMENTO INCLUSO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                    Console.ReadLine();
                                }
                                else if (confirmacaoEquipamento == "N" || confirmacaoEquipamento == "n")
                                {
                                    confirmacaoInputEquipamentoValido = true;
                                    idDoEquipamentoValido = true;
                                    ApresentarMensagem("CHAMADO NÃO REGISTRADO, POIS NÃO HOUVE A INCLUSÃO DE UM EQUIPAMENTO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Yellow);
                                    Console.ReadLine();
                                    return false;
                                }
                                else
                                {
                                    ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                    Console.ReadLine();
                                }
                            } while (confirmacaoInputEquipamentoValido == false);
                        }
                        else
                        {
                            ApresentarMensagem("ID DO EQUIPAMENTO NÃO ENCONTRADO NO SISTEMA!!\n\nTECLE ENTER PARA CONTINUARMOS!!", ConsoleColor.Red);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS!!", ConsoleColor.Red);
                        Console.ReadLine();
                    }
                } while (idDoEquipamentoValido == false);
                //Inserindo o solicitante no chamado
                do
                {
                    Console.Write("\nInforme o id do solicitante a ser incluso no chamado: ");
                    idSolicitanteInput = Console.ReadLine();
                    if (int.TryParse(idSolicitanteInput, out idDoSolicitanteDoUsuario) == true)
                    {
                        posicaoDoSolicitanteNoArrayDeSolicitantes = RetornaAhPosicaoDoSolicitantePeloId(idDoSolicitanteDoUsuario);
                        if (posicaoDoSolicitanteNoArrayDeSolicitantes != -1)
                        {
                            Console.WriteLine("\n\nESTE É O SOLICITANTE A SER INCLUSO NO CHAMADO:\n\n");
                            VisualizarUmSolicitante(posicaoDoSolicitanteNoArrayDeSolicitantes);
                            bool confirmacaoInputSolicitanteValido = false;
                            do
                            {
                                Console.Write("\n\nCONFIRMA A INCLUSAO? (S/N) ");
                                string confirmacaoSolicitante = Console.ReadLine();
                                if (confirmacaoSolicitante == "S" || confirmacaoSolicitante == "s")
                                {
                                    idDoSolicitanteValido = true;
                                    confirmacaoInputSolicitanteValido = true;
                                    solicitanteTemChamado[posicaoDoSolicitanteNoArrayDeSolicitantes] = true;
                                    ApresentarMensagem("SOLICITANTE INCLUSO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                    Console.ReadLine();
                                }
                                else if (confirmacaoSolicitante == "N" || confirmacaoSolicitante == "n")
                                {
                                    idDoSolicitanteValido = true;
                                    confirmacaoInputSolicitanteValido = true;
                                    ApresentarMensagem("CHAMADO NÃO REGISTRADO, POIS NÃO HOUVE A INCLUSÃO DE UM SOLICITANTE!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Yellow);
                                    Console.ReadLine();
                                    return false;
                                }
                                else
                                {
                                    ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                    Console.ReadLine();
                                }
                            } while (confirmacaoInputSolicitanteValido == false);
                        }
                        else
                        {
                            ApresentarMensagem("ID DO SOLICITANTE NÃO ENCONTRADO NO SISTEMA!!\n\nTECLE ENTER PARA CONTINUARMOS!!", ConsoleColor.Red);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS!!", ConsoleColor.Red);
                        Console.ReadLine();
                    }
                } while (idDoSolicitanteValido == false);
            }
            //int posicaoParaRegistrar = RetornaAhPosicaoLivreDoArrayDeEquipamentos();
            titulosDosChamados[posicao] = tituloChamado;
            descricaoDosChamados[posicao] = descricaoChamado;
            datasDeAberturaDosChamados[posicao] = dataAberturaDT;
            posicaoDoEquipamentoNoArrayDeChamado[posicao] = posicaoDoEquipamentoNoArrayDeEquipamentos;
            if (formaDeUso == "registrar")
            {
                //Registrando o id sendo a posicao + 1
                idsDosChamados[posicao] = posicao + 1;
                idsDosEquipamentosDentroDosChamados[posicao] = idDoEquipamentoDoUsuario;
                idsDosSolicitantesDentroDosChamados[posicao] = idDoSolicitanteDoUsuario;
                datasDeFechamentoDosChamados[posicao] = new DateTime(01 / 01 / 01);
                statusDosChamados[posicao] = "aberto";
                if (tituloValido == descricaoValida && descricaoValida == dataAberturaValida && dataAberturaValida == idDoEquipamentoValido && idDoEquipamentoValido && idDoEquipamentoValido == idDoSolicitanteValido && idDoSolicitanteValido == true)
                {
                    retorno = true;
                }
            }
            else
            {
                if (tituloValido == descricaoValida && descricaoValida == dataAberturaValida == true)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        static int RetornaAhPosicaoDoChamadoPeloId(int id)
        {
            int posicaoAhRetornar = -1;
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeChamados();
            for (int i = 0; i < posicaoLivre; i++)
            {
                if (idsDosChamados[i] == id)
                {
                    posicaoAhRetornar = i;
                    break;
                }
            }
            return posicaoAhRetornar;
        }

        static void VisualizarUmChamado(int posicao)
        {
            Console.WriteLine("\nId do chamado: {0}", idsDosChamados[posicao]);
            Console.WriteLine("\nTítulo do chamado: {0}", titulosDosChamados[posicao]);
            Console.WriteLine("\nDescrição do chamado: {0}", descricaoDosChamados[posicao]);
            Console.WriteLine("\nStatus do chamado: {0}", statusDosChamados[posicao]);
            Console.WriteLine("\nData de abertura do chamado: {0}", TransformarDateTimeEmString(datasDeAberturaDosChamados[posicao]));
            string dataDeFechamento = (datasDeFechamentoDosChamados[posicao] == new DateTime(01 / 01 / 01)) ? "null" : TransformarDateTimeEmString(datasDeFechamentoDosChamados[posicao]);
            Console.WriteLine("\nData de fechamento do chamado: {0}", dataDeFechamento);
            Console.WriteLine("\nQuantidade de dias que o chamado está aberto: {0}", RetornaAhQuantidadeDeDiasDaAberturaDeUmChamado(datasDeAberturaDosChamados[posicao]));
            Console.WriteLine("\n\t\t=== Este é o equipamento do chamado ===");
            VisualizarUmEquipamento(RetornaAhPosicaoDoEquipamentoPeloId(idsDosEquipamentosDentroDosChamados[posicao]));
            Console.WriteLine("\n\t\t=== Este é o solicitante do chamado ===");
            VisualizarUmSolicitante(RetornaAhPosicaoDoSolicitantePeloId(idsDosSolicitantesDentroDosChamados[posicao]));
            Console.WriteLine();
        }

        static int RetornaAhQuantidadeDeDiasDaAberturaDeUmChamado(DateTime dataDeAberturaDoChamado)
        {
            DateTime hoje = DateTime.Today;
            TimeSpan dataCalculada = Convert.ToDateTime(hoje) - Convert.ToDateTime(dataDeAberturaDoChamado);
            int dias = dataCalculada.Days;
            return dias;
        }

        #endregion

        #region Métodos dos solicitantes

        static void ExcluirUmSolicitante()
        {
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeSolicitantes();
            if (posicaoLivre != 0)
            {
                bool idValido = false;
                int idDoSolicitante = -1;
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\n\n\t\tEXCLUIR UM SOLICITANTE NO SISTEMA\n");
                do
                {
                    Console.Write("Informe o Id do solicitante que deseja excluir: ");
                    string idInputado = Console.ReadLine();
                    if (int.TryParse(idInputado, out int idDoUsuario) == true)
                    {
                        if (RetornaAhPosicaoDoSolicitantePeloId(idDoUsuario) != -1)
                        {
                            idDoSolicitante = RetornaAhPosicaoDoSolicitantePeloId(idDoUsuario);
                            idValido = true;
                            Console.WriteLine("\n\nESTE É O SOLICITANTE A SER EXCLUÍDO:\n\n");
                            VisualizarUmSolicitante(idDoSolicitante);
                            if (equipamentoTemChamado[idDoSolicitante] == false)
                            {
                                bool confirmacaoInputExlusaoSolicitante = false;
                                do
                                {
                                    Console.Write("\n\nCONFIRMA A EXCLUSÃO? (S/N): ");
                                    string confirmacaoExclusao = Console.ReadLine();
                                    if (confirmacaoExclusao == "S" || confirmacaoExclusao == "s")
                                    {
                                        nomesDosSolicitantes = DeletarUmElementoDeUmArrayDeStrings(nomesDosSolicitantes, idDoSolicitante);
                                        emailDosSolicitantes = DeletarUmElementoDeUmArrayDeStrings(emailDosSolicitantes, idDoSolicitante);
                                        telefoneDosSolicitantes = DeletarUmElementoDeUmArrayDeStrings(telefoneDosSolicitantes, idDoSolicitante);
                                        idsDosSolicitantes = DeletarUmElementoDeUmArrayDeInteiros(idsDosSolicitantes, idDoSolicitante);
                                        solicitanteTemChamado = DeletarUmElementoDeUmArrayDeBooleanos(solicitanteTemChamado, idDoSolicitante);
                                        ApresentarMensagem("O SOLICITANTE FOI EXCLUÍDO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                        Console.ReadLine();
                                    }
                                    else if (confirmacaoExclusao == "N" || confirmacaoExclusao == "n")
                                    {
                                        ApresentarMensagem("O SOLICITANTE NÃO FOI EXCLUÍDO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Yellow);
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                        Console.ReadLine();
                                    }
                                } while (confirmacaoInputExlusaoSolicitante == false);
                            }
                            else
                            {
                                ApresentarMensagem("NÃO FOI POSSÍVEL EXCLUIR O SOLICITANTE, POIS ELE ESTÁ VINCULADO A UM CHAMADO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                        Console.ReadLine();
                    }
                } while (idValido == false);
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI SOLICITANTES!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                Console.ReadLine();
            }
        }

        static void EditarUmSolicitante()
        {
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeSolicitantes();
            if (posicaoLivre != 0)
            {
                bool idValido = false;
                int idDoSolicitante = -1;
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\n\n\t\tEDIÇÃO DE SOLICITANTES\n\n");
                do
                {
                    Console.Write("Informe o Id do solicitante que deseja editar: ");
                    string idInputado = Console.ReadLine();
                    if (int.TryParse(idInputado, out int idDoUsuario) == true)
                    {
                        if (RetornaAhPosicaoDoSolicitantePeloId(idDoUsuario) != -1)
                        {
                            idDoSolicitante = RetornaAhPosicaoDoSolicitantePeloId(idDoUsuario);
                            idValido = true;
                            Console.WriteLine("\n\nESTE É O SOLICITANTE A SER EDITADO:\n\n");
                            VisualizarUmSolicitante(idDoSolicitante);
                            bool confirmacaoInputEdicaoValida = false;
                            do
                            {
                                Console.Write("\n\nCONFIRMA A EDIÇÃO? (S/N) ");
                                string confirmacaoEdicao = Console.ReadLine();
                                if (confirmacaoEdicao == "S" || confirmacaoEdicao == "s")
                                {
                                    confirmacaoInputEdicaoValida = true;
                                    bool editou = PedeOsDadosDoSolicitanteEhColocaEmUmaPosicao(idDoSolicitante, "editar");
                                    if (editou == true)
                                    {
                                        ApresentarMensagem("SOLICITANTE EDITADO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        ApresentarMensagem("FALHA NA EDIÇÃO DO SOLICITANTE!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                        Console.ReadLine();
                                    }
                                }
                                else if (confirmacaoEdicao == "N" || confirmacaoEdicao == "n")
                                {
                                    ApresentarMensagem("O SOLICITANTE NÃO FOI EDITADO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Yellow);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                    Console.ReadLine();
                                }
                            } while (confirmacaoInputEdicaoValida == false);
                        }
                        else
                        {
                            ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        ApresentarMensagem("ENTRADA INVÁLIDA!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                        Console.ReadLine();
                    }
                } while (idValido == false);
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI SOLICITANTES!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                Console.ReadLine();
            }
        }

        static void RegistrarUmSolicitante()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("\n\n\t\tREGISTRO DE SOLICITANTES\n");
            int posicaoParaRegistrar = RetornaAhPosicaoLivreDoArrayDeSolicitantes();
            bool registrou = PedeOsDadosDoSolicitanteEhColocaEmUmaPosicao(posicaoParaRegistrar, "registrar");
            if (registrou == true)
            {
                ApresentarMensagem("SOLICITANTE REGISTRADO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                Console.ReadLine();
            }
            else
            {
                ApresentarMensagem("FALHA NO REGISTRO DO SOLICITANTE!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                Console.ReadLine();
            }
        }

        static int RetornaAhPosicaoDoSolicitantePeloId(int id)
        {
            int posicaoAhRetornar = -1;
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeSolicitantes();
            for (int i = 0; i < posicaoLivre; i++)
            {
                if (idsDosSolicitantes[i] == id)
                {
                    posicaoAhRetornar = i;
                    break;
                }
            }
            return posicaoAhRetornar;
        }

        static int RetornaAhPosicaoLivreDoArrayDeSolicitantes()
        {
            int posicaoLivre = -1;
            for (int i = 0; i < nomesDosSolicitantes.Length; i++)
            {
                if (nomesDosSolicitantes[i] == null)
                {
                    posicaoLivre = i;
                    break;
                }
            }
            return posicaoLivre;
        }

        static bool PedeOsDadosDoSolicitanteEhColocaEmUmaPosicao(int posicao, string formaDeUso)
        {
            bool nomeValido = false, emailValido = false, telefoneValido = false;
            string nomeSolicitante = "", emailSolicitante = "", telefoneSolicitante = "";
            do
            {
                Console.Write("\nInforme o nome do solicitante com no mínimo 6 (seis) caracteres: ");
                nomeSolicitante = Console.ReadLine();
                if (nomeSolicitante.Length >= 6)
                {
                    nomeValido = true;
                }
                else
                {
                    ApresentarMensagem("O NOME DO SOLICITANTE DEVE TER PELO MENOS 6 CARACTERES!!\n\nTECLE ENTER PARA CONTINUARMOS!!", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (nomeValido == false);
            do
            {
                Console.Write("\nInforme o email do solicitante: ");
                emailSolicitante = Console.ReadLine();
                if (emailSolicitante.Length > 0 && emailSolicitante.Contains("@") && emailSolicitante.Contains("."))
                {
                    emailValido = true;
                }
                else
                {
                    ApresentarMensagem("EMAIL INVÁLIDO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (emailValido == false);
            do
            {
                Console.Write("\nInforme o telefone do solicitante: ");
                telefoneSolicitante = Console.ReadLine();
                if (telefoneSolicitante.Length > 0)
                {
                    telefoneValido = true;
                }
                else
                {
                    ApresentarMensagem("NÚMERO DE TELEFONE INVÁLIDO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                    Console.ReadLine();
                }
            } while (telefoneValido == false);
            //int posicaoParaRegistrar = RetornaAhPosicaoLivreDoArrayDeEquipamentos();
            nomesDosSolicitantes[posicao] = nomeSolicitante;
            emailDosSolicitantes[posicao] = emailSolicitante;
            telefoneDosSolicitantes[posicao] = telefoneSolicitante;
            if (formaDeUso == "registrar")
            {
                solicitanteTemChamado[posicao] = false;
                //Registrando o id sendo a posicao + 1
                idsDosSolicitantes[posicao] = posicao + 1;
            }
            if (nomeValido == emailValido && emailValido == telefoneValido && telefoneValido == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void VisualizarTodosOsSolicitantes()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("\n\n\t\tVISUALIZAR TODOS OS SOLICITANTES REGISTRADOS NO SISTEMA");
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeSolicitantes();
            if (posicaoLivre != 0)
            {
                for (int i = 0; i < posicaoLivre; i++)
                {
                    //if ternário escolhendo uma cor se for par e uma cor se for ímpar
                    Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.DarkCyan : ConsoleColor.DarkYellow;
                    VisualizarUmSolicitante(i);
                }
                Console.ResetColor();
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI SOLCITANTES REGISTRADOS!!", ConsoleColor.Red);
            }
            Console.WriteLine("\n\nTECLE ENTER PARA CONTINUARMOS");
            Console.ReadLine();
        }

        static void VisualizarUmSolicitante(int posicao)
        {
            Console.WriteLine("\nId do solicitante: {0}", idsDosSolicitantes[posicao]);
            Console.WriteLine("\nNome do solicitante: {0}", nomesDosSolicitantes[posicao]);
            Console.WriteLine("\nEmail do solicitante: {0}", emailDosSolicitantes[posicao]);
            Console.WriteLine("\nTelefone do solicitante: {0}", telefoneDosSolicitantes[posicao]);
            Console.WriteLine("\nExiste algum chamado para este solictante: {0}", solicitanteTemChamado[posicao]);
        }

        #endregion
    }
}