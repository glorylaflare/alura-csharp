// See https://aka.ms/new-console-template for more information

//<string> listaDeBandas = new List<string>();
Dictionary<string, List<double>> dicionarioDeBandas = new Dictionary<string, List<double>>() 
{
    { "U2", new List<double> { 8.5, 9.0, 7.5 } },
    { "Foo Fighters", new List<double> { 9.0, 6.5, 7.0 } }
};

void ExibirMensagemDeBoasVindas()
{
    ExibirLogo();
    Console.WriteLine("Olá, usuário!");
    Console.WriteLine("Este programa irá reproduzir sons de tela.");
    Console.WriteLine("Pressione qualquer tecla para continuar...");
    Console.ReadKey();
}

ExibirMensagemDeBoasVindas();

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(new string('*', 40));
    Console.WriteLine("Bem-vindo(a) ao ScreenSound");
}

void ExibirMenu()
{
    Console.WriteLine("\nSelecione uma opção:");
    Console.WriteLine("1. Registrar uma banda");
    Console.WriteLine("2. Lista bandas");
    Console.WriteLine("3. Avaliar uma banda");
    Console.WriteLine("4. Média da avaliação de uma banda");
    Console.WriteLine("5. Sair");
    var opcao = int.Parse(Console.ReadLine());

    // Em caso das condições estarem associadas é melhor optar por um Switch ao invés de Ifs
    switch (opcao)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            ListarBandas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            MediaAvaliacaoBanda();
            break;
        case 5:
            Console.WriteLine("Saindo do programa...");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            ExibirMenu();
            break;
    }
}

ExibirMenu();

void RegistrarBanda()
{
     Console.Clear();
     ExibirTituloDaOpcao("Registrar Banda");
     Console.Write("Digite o nome da banda: ");
     string nomeBanda = Console.ReadLine()!;
     // Interpolando a string para exibir o nome da banda
     Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso! Pressione qualquer tecla para continuar...");
     //listaDeBandas.Add(nomeBanda);
     dicionarioDeBandas.Add(nomeBanda, new List<double>());
     Thread.Sleep(2000); // Pausa de 2 segundos para o usuário ler a mensagem
     Console.Clear();
     ExibirMenu();
}

void ListarBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Lista de Bandas Registradas");
    //foreach (var banda in listaDeBandas) Console.WriteLine($"Banda: {banda}");
    foreach (var banda in dicionarioDeBandas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;
    if (dicionarioDeBandas.ContainsKey(nomeBanda))
    {
        Console.Write("Digite a avaliação (0 a 10): ");
        double avaliacao = double.Parse(Console.ReadLine()!);
        if (avaliacao is >= 0 and <= 10)
        {
            dicionarioDeBandas[nomeBanda].Add(avaliacao);
            Console.WriteLine($"Avaliação {avaliacao} registrada para a banda {nomeBanda} com sucesso!");
        }
        else
        {
            Console.WriteLine("Avaliação inválida. Deve ser entre 0 e 10.");
        }
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não está registrada.");
    }
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void MediaAvaliacaoBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média da Avaliação de uma Banda");
    Console.Write("Digite o nome da banda para calcular a média: ");
    string nomeBanda = Console.ReadLine()!;
    double somaDasAvaliacoes = 0;
    if (dicionarioDeBandas.ContainsKey(nomeBanda))
    {
        if (dicionarioDeBandas[nomeBanda].Count > 0)
        {
            List<double> avaliacoes = dicionarioDeBandas[nomeBanda];
            Console.WriteLine($"A média das avaliações da banda {nomeBanda} é {avaliacoes.Average():F2}");
        }
        else
        {
            Console.WriteLine($"A banda {nomeBanda} não possui avaliações registradas.");
        }
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não está registrada.");
    }
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    Console.Clear();
    Console.WriteLine(new string('*',  quantidadeDeLetras));
    Console.WriteLine(titulo);
    Console.WriteLine(new string('*',  quantidadeDeLetras));
}