/// <summary>
/// Tipos possíveis de conexão em um bloco.
/// </summary>
public enum TipoConexao
{
    Nenhuma,   // Não conecta nada
    Itens,     // Inventário (baús, funis, fornalhas)
    Fluido,    // Água, lava, líquidos especiais
    Gas,       // Vapores, fumaça, gases
    Energia,   // Energia mágica ou elétrica
    Calor      // Transferência de calor
}
