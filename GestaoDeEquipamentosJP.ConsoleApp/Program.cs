﻿
using System;

namespace GestaodeEquipamentosJP.ConsoleApp
{
    internal class Program
    {
        #region Declaração de variáveis globais
        //Variáveis relacionadas aos equipamentos
        static string[] nomesDosEquipamentos = new string[10];
        static decimal[] precosDeAquisicaoDosEquipamentos = new decimal[10];
        static int[] numerosDeSerieDosEquipamentos = new int[10];
        static DateTime[] datasDeFabricacaoDosEquipamentos = new DateTime[10];
        static string[] fabricantesDosEquipamentos = new string[10];
        static int[] idsDosEquipamentos = new int[10];
        static bool[] temChamado = new bool[10];
        //Variáveis relacionadas aos chamados
        static int[] idsDosChamados = new int[10];
        static string[] titulosDosChamados = new string[10];
        static string[] descricaoDosChamados = new string[10];
        static DateTime[] datasDeAberturaDosChamados = new DateTime[10];
        static int[] posicaoDoEquipamentoNoArrayDeChamado = new int[10];
        static int[] idsDosEquipamentosDentroDosChamados = new int[10];
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
                Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
                Console.WriteLine("\t\tMENU PRINCIPAL");
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
                    ApresentarMensagem("OPÇÃO INVÁLIDA!! DIGITE UM NÚMERO DE 0 A 3!!", ConsoleColor.Red);
                    Console.WriteLine("\n\nTECLE ENTER PARA CONTINUARMOS\n");
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
                Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
                Console.WriteLine("\t\tMENU GERENCIAR SOLICITANTES");
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
                    ApresentarMensagem("OPÇÃO INVÁLIDA!! DIGITE UM NÚMERO DE 0 A 4!!", ConsoleColor.Red);
                    Console.WriteLine("\n\nTECLE ENTER PARA CONTINUARMOS\n");
                    Console.ReadLine();
                }
                Console.WriteLine("\n-----------------------------------------------------------------------------------------------\n");
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
                Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
                Console.WriteLine("\t\tMENU GERENCIAR CHAMADOS");
                Console.WriteLine("\n * Digite 1 para Registrar um novo chamado;");
                Console.WriteLine("\n * Digite 2 para Editar um chamado;");
                Console.WriteLine("\n * Digite 3 para Excluir um chamado; ");
                Console.WriteLine("\n * Digite 4 para Vizualizar todos os chamados cadastrados; ");
                Console.WriteLine("\n * Digite 0 para Retornar ao Menu principal;");
                Console.Write("\n * Sua escolha: ");
                string escolha = Console.ReadLine();
                if (int.TryParse(escolha, out int opcao) && opcao >= 0 && opcao <= 4)
                {
                    opcaoValida = true;
                    ExecutaAhOpcaoEscolhidaNoMenuGerenciarChamados(opcao);
                }
                else
                {
                    opcaoValida = false;
                    ApresentarMensagem("OPÇÃO INVÁLIDA!! DIGITE UM NÚMERO DE 0 A 4!!", ConsoleColor.Red);
                    Console.WriteLine("\n\nTECLE ENTER PARA CONTINUARMOS\n");
                    Console.ReadLine();
                }
                Console.WriteLine("\n-----------------------------------------------------------------------------------------------\n");
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
            }
        }

        static void ExecutaAhOpcaoEscolhidaNoMenuGerenciarSolicitantes(int opcaoEscolhida)
        {

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
            Console.WriteLine("\n\t\tREGISTRO DE EQUIPAMENTOS\n");
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
                Console.WriteLine("\n\t\tEDIÇÃO DE EQUIPAMENTOS\n\n");
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
                            Console.Write("\n\nCONFIRMA A EDIÇÃO? (S/N) ");
                            string confirmacao = Console.ReadLine();
                            if (confirmacao == "S" || confirmacao == "s")
                            {
                                bool editou = PedeOsDadosDoEquipamentoEhColocaEmUmaPosicao(idDoEquipamento, "editar");
                                if (editou == true)
                                {
                                    ApresentarMensagem("EQUIPAMENTO EDITADO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    ApresentarMensagem("FALHA NA EDIÇÃO DO EQUIPAMENTO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
                                }
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

        static void ExcluirUmEquipamento()
        {
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeEquipamentos();
            if (posicaoLivre != 0)
            {
                bool idValido = false;
                int idDoEquipamento = -1;
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\n\t\tEXCLUIR UM EQUIPAMENTO NO SITEMA\n");
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
                            if (temChamado[idDoEquipamento] == false)
                            {
                                Console.Write("\n\nCONFIRMA A EXCLUSÃO? (S/N): ");
                                string confirmacao = Console.ReadLine();
                                if (confirmacao == "S" || confirmacao == "s")
                                {
                                    nomesDosEquipamentos = DeletarUmElementoDeUmArrayDeStrings(nomesDosEquipamentos, idDoEquipamento);
                                    precosDeAquisicaoDosEquipamentos = DeletarUmElementoDeUmArrayDeDecimais(precosDeAquisicaoDosEquipamentos, idDoEquipamento);
                                    numerosDeSerieDosEquipamentos = DeletarUmElementoDeUmArrayDeInteiros(numerosDeSerieDosEquipamentos, idDoEquipamento);
                                    datasDeFabricacaoDosEquipamentos = DeletarUmElementoDeUmArrayDeDateTime(datasDeFabricacaoDosEquipamentos, idDoEquipamento);
                                    fabricantesDosEquipamentos = DeletarUmElementoDeUmArrayDeStrings(fabricantesDosEquipamentos, idDoEquipamento);
                                    temChamado = DeletarUmElementoDeUmArrayDeBooleanos(temChamado, idDoEquipamento);
                                    idsDosEquipamentos = DeletarUmElementoDeUmArrayDeInteiros(idsDosEquipamentos, idDoEquipamento);
                                    ApresentarMensagem("O EQUIPAMENTO FOI EXCLUÍDO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                    Console.ReadLine();
                                }
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

        static void VisualizarUmEquipamento(int posicao)
        {
            Console.WriteLine("\nId do equipamento: {0}", idsDosEquipamentos[posicao]);
            Console.WriteLine("\nNome do equipamento: {0}", nomesDosEquipamentos[posicao]);
            Console.WriteLine("\nPreço de aquisição do equipamento: {0}", precosDeAquisicaoDosEquipamentos[posicao]);
            Console.WriteLine("\nNúmero de série do equipamento: {0}", numerosDeSerieDosEquipamentos[posicao]);
            Console.WriteLine("\nData de fabricação do equipamento: {0}", TransformarDateTimeEmString(datasDeFabricacaoDosEquipamentos[posicao]));
            Console.WriteLine("\nFabricante do equipamento: {0}", fabricantesDosEquipamentos[posicao]);
            Console.WriteLine("\nO equipamento tem chamado? {0}", temChamado[posicao]);
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------\n");
        }

        static void VisualizarTodosOsEquipamentos()
        {
            Console.Clear();
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeEquipamentos();
            if (posicaoLivre != 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\t\tVISUALIZAR TODOS OS EQUIPAMENTOS REGISTRADOS NO SISTEMA\n");
                for (int i = 0; i < posicaoLivre; i++)
                {
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
                temChamado[posicao] = false;
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
        static void VisualizarTodosOsChamados()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("\n\t\tVISUALIZAR TODOS OS CHAMADOS REGISTRADOS NO SISTEMA");
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeChamados();
            if (posicaoLivre != 0)
            {
                for (int i = 0; i < posicaoLivre; i++)
                {
                    VisualizarUmChamado(i);
                }
            }
            else
            {
                ApresentarMensagem("O SISTEMA NÃO POSSUI CHAMADOS REGISTRADOS!!", ConsoleColor.Red);
                Console.ReadLine();
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
                Console.WriteLine("\n\t\tEXCLUIR UM CHAMADO NO SISTEMA\n");
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
                            Console.Write("\n\nCONFIRMA A EXCLUSÃO? (S/N): ");
                            string confirmacao = Console.ReadLine();
                            if (confirmacao == "S" || confirmacao == "s")
                            {
                                titulosDosChamados = DeletarUmElementoDeUmArrayDeStrings(titulosDosChamados, idDoChamado);
                                descricaoDosChamados = DeletarUmElementoDeUmArrayDeStrings(descricaoDosChamados, idDoChamado);
                                idsDosChamados = DeletarUmElementoDeUmArrayDeInteiros(idsDosChamados, idDoChamado);
                                datasDeAberturaDosChamados = DeletarUmElementoDeUmArrayDeDateTime(datasDeAberturaDosChamados, idDoChamado);
                                temChamado[RetornaAhPosicaoDoEquipamentoPeloId(idsDosEquipamentosDentroDosChamados[idDoChamado])] = false;
                                idsDosEquipamentosDentroDosChamados = DeletarUmElementoDeUmArrayDeInteiros(idsDosEquipamentosDentroDosChamados, idDoChamado);
                                ApresentarMensagem("O CHAMADO FOI EXCLUÍDO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
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

        static void EditarUmChamado()
        {
            int posicaoLivre = RetornaAhPosicaoLivreDoArrayDeChamados();
            if (posicaoLivre != 0)
            {
                bool idValido = false;
                int idDoChamado = -1;
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\n\t\tEDITAR UM CHAMADO NO SISTEMA\n");
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
                            Console.Write("\n\nCONFIRMA A EDIÇÃO? (S/N): ");
                            string confirmacao = Console.ReadLine();
                            if (confirmacao == "S" || confirmacao == "s")
                            {
                                bool editou = PedeOsDadosDoChamadoEhColocaEmUmaPosicao(idDoChamado, "edição");
                                if (editou == true)
                                {
                                    ApresentarMensagem("O CHAMADO FOI EDITADO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                    Console.ReadLine();
                                }
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

        static void RegistrarUmChamado()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("\n\t\tREGISTRO DE CHAMADOS\n");
            if (RetornaAhPosicaoLivreDoArrayDeEquipamentos() != 0)
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
                ApresentarMensagem("O SISTEMA AINDA NÃO POSSUI EQUIPAMENTOS, POSTANTO NÃO PODEMOS REGISTRAR CHAMADOS!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Red);
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
            bool tituloValido = false, descricaoValida = false, dataAberturaValida = false, idDoEquipamentoValido = false, retorno = false;
            string tituloChamado = "", descricaoChamado = "", dataAbertura = "", idEquipamentoInput = "";
            DateTime dataAberturaDT = new DateTime(01, 01, 01);
            int posicaoDoEquipamentoNoArrayDeEquipamentos = -1, idDoEquipamentoDoUsuario = -1;
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
                    ApresentarMensagem("DATA INVÁLIDA!! INFORME UMA DATA NO SEGUINTE FORMATO (DD/MM/AAAA)\n" +
                        "\n\nTECLE ENTER PARA CONTINUARMOS!!", ConsoleColor.Red);
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
                        idDoEquipamentoValido = true;
                        if (posicaoDoEquipamentoNoArrayDeEquipamentos != -1)
                        {
                            Console.WriteLine("\n\nESTE É O EQUIPAMENTO A SER INCLUSO NO CHAMADO:\n\n");
                            VisualizarUmEquipamento(posicaoDoEquipamentoNoArrayDeEquipamentos);
                            Console.Write("\n\nCONFIRMA A INCLUSAO? (S/N) ");
                            string confirmacao = Console.ReadLine();
                            if (confirmacao == "S" || confirmacao == "s")
                            {
                                temChamado[posicaoDoEquipamentoNoArrayDeEquipamentos] = true;
                                ApresentarMensagem("EQUIPAMENTO INCLUSO COM SUCESSO!!\n\nTECLE ENTER PARA CONTINUARMOS", ConsoleColor.Green);
                                Console.ReadLine();
                            }
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
                if (tituloValido == descricaoValida && descricaoValida == dataAberturaValida && dataAberturaValida == idDoEquipamentoValido && idDoEquipamentoValido == true)
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
            Console.WriteLine("\nData de abertura do chamado: {0}", TransformarDateTimeEmString(datasDeAberturaDosChamados[posicao]));
            Console.WriteLine("\nQuantidade de dias que o chamado está aberto: {0}", RetornaAhQuantidadeDeDiasDaAberturaDeUmChamado(datasDeAberturaDosChamados[posicao]));
            Console.WriteLine("\n\t\tEste é o equipamento do chamado");
            VisualizarUmEquipamento(RetornaAhPosicaoDoEquipamentoPeloId(idsDosEquipamentosDentroDosChamados[posicao]));
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
    }
}