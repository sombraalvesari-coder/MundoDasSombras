using System; // Necessário para 'DateTime'

/// <summary>
/// Estrutura de dados que representa um mundo salvo no jogo.
/// </summary>
[Serializable] // Permite que a Unity serialize e visualize no Inspector, se necessário
public class DadosMundo
{
    // Limite de 50 caracteres para o nome.
    public string nomeDoMundo = "Novo Mundo";

    // A data de criação será capturada no momento da criação do mundo.
    public DateTime dataDeCriacao;

    // A data da última vez que o jogador entrou no mundo (usada para ordenação).
    public DateTime dataDaUltimaPartida; 

    // O tempo total de jogo, armazenado como um TimeSpan (horas, minutos, segundos).
    public TimeSpan tempoTotalDeJogo = TimeSpan.Zero; 

    // Indica se o mundo está disponível para ser jogado online (hosteado ou em servidor).
    public bool disponivelOnline = false;

    // Indica se este mundo está marcado como favorito (apenas um permitido por enquanto).
    public bool eFavorito = false; 

    // Caminho da imagem de capa (futura implementação, por agora será null ou um Sprite).
    // public string caminhoDaCapa; 
}