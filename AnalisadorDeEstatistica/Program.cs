
List<double> dados = new List<double> { 1, 2, 2, 3, 4, 5, 5, 5, 6 };

double media = CalcularMedia(dados);
double mediana = CalcularMediana(dados);
List<double> moda = CalcularModa(dados);
double variancia = CalcularVariancia(dados, media);
double desvioPadrao = Math.Sqrt(variancia);

while (true)
{
    Console.WriteLine("\n===");
    Console.WriteLine("Bem-vindo ao analisador de estatística.");
    Console.WriteLine("===\n");
    Thread.Sleep(1000);

    Console.WriteLine("O conjunto numérico usado nas estatisticas é: " + string.Join(", ", dados) + "\n");
    Console.WriteLine("Digite agora o numero da opção da estatística que deseja: \n\n");
    Thread.Sleep(3000);

    Console.WriteLine("Opção 1: Média...");
    Console.WriteLine("Opção 2: Mediana...");
    Console.WriteLine("Opção 3: Moda...");
    Console.WriteLine("Opção 4: Variancia...");
    Console.WriteLine("Opção 5: Desvio Padrão...");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            ExibeMedia();
            break;

        case "2": 
            ExibeMediana();
            break;

        case "3":
            ExibeModa();
            break;

        case "4":
            ExibeVariancia();
            break;

        case "5":
            ExibeDesvioPadrao();
            break;

        default:
            Console.WriteLine("Opção inválida, digite apenas opções indicadas acima..");
            Thread.Sleep(5000);
            Console.Clear();
            break;
    }
}


void ExibeDesvioPadrao()
{
    Console.WriteLine("\n\nO desvio padrão é a raiz quadrada da variância e fornece uma medida da dispersão dos dados");
    Console.Write($"\nO desvio padrão dos números é {desvioPadrao}.\n");
    Console.ReadKey();
    Console.Clear();
}

void ExibeVariancia()
{
    Console.WriteLine("\n\nA variância mede a dispersão dos valores em relação á média.");
    Console.WriteLine("É a média dos quadrados das diferenças entre cada valor e a média.");
    Console.Write($"\nA variancia dos números é {variancia}.\n");
    Console.ReadKey();
    Console.Clear();
}

void ExibeModa()
{
    Console.WriteLine("\n\nA moda é o valor que aparece com mais frequência em um conjunto de dados.");
    Console.WriteLine("Pode haver mais de uma moda se vários valores tiverem a mesma frequência máxima.");
    Console.Write("\nModa: " + string.Join(", ", moda) + "\n");
    Console.ReadKey();
    Console.Clear();
}

void ExibeMediana()
{
    Console.WriteLine("\n\nA mediana é o valor central de um conjunto de dados ordenado.");
    Console.WriteLine("Se o número de dados for ímpar, a mediana é o valor do meio.");
    Console.WriteLine("Se for par, a mediana é a média dos dois valores centrais.");
    Console.Write($"\nA mediana dos números é {mediana}.\n");
    Console.ReadKey();
    Console.Clear();
}

void ExibeMedia()
{
    Console.WriteLine("\n\nA média é a soma de todos os valores dividida pelo número de valores.");
    Console.Write($"\nA média dos números é {media}.\n");
    Console.ReadKey();
    Console.Clear();
}


static double CalcularVariancia(List<double> dados, double media)
{
    return dados.Sum(d => Math.Pow(d - media, 2)) / dados.Count;
}

static List<double> CalcularModa(List<double> dados)
{
    var frequencia = dados.GroupBy(n => n).
        Select(g => new { Valor = g.Key, Contagem = g.Count() }).
        OrderByDescending(g => g.Contagem).ToList();

    int maxContagem = frequencia.First().Contagem;

    return frequencia.Where(g => g.Contagem == maxContagem).
        Select(g => g.Valor).ToList();
}

static double CalcularMediana(List<double> dados)
{
    var dadosOrdenados = dados.OrderBy(n => n).ToList();
    int n = dadosOrdenados.Count;

    if(n % 2 == 0)
    {
        return (dadosOrdenados[n / 2 - 1] + dadosOrdenados[n / 2]) / 2.0;
    }
    else
    {
        return dadosOrdenados[n / 2];
    }
}

static double CalcularMedia(List<double> dados)
{
    return dados.Average();
}