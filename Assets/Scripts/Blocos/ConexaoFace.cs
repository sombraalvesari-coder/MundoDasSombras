using UnityEngine;

/// <summary>
/// Representa as informações de conexão em uma face específica de um bloco.
/// </summary>
[System.Serializable]
public class ConexaoFace
{
    public TipoConexao tipoConexao = TipoConexao.Nenhuma; // Qual o tipo de conexão
    public int capacidade = 0;                            // Quantidade máxima suportada
    public int forca = 0;                                 // Intensidade ou taxa de transferência

    // 🔥 Propriedades específicas para calor
    public bool transmiteCalor = false;                   // Se esta face permite troca de calor
    public float eficienciaTermica = 1.0f;                // Eficiência de condução térmica (1 = normal, 0.5 = perde metade, etc.)
}
