using UnityEngine;

/// <summary>
/// Representa os dados de um tipo de bloco do jogo.
/// </summary>
[System.Serializable]
public class DadosBloco
{
    public uint id;               // Identificador único do bloco
    public string nome;           // Nome completo do bloco
    public bool solido;           // Se o jogador pode atravessar ou não
    public bool transparente;     // Se deixa a luz passar
    public Texture textura;       // Textura associada

    // 🔥 Sistema de temperatura
    public float temperaturaAtual = 20.0f;   // Temperatura inicial do bloco (em graus)
    public float temperaturaMaxima = 2000f;  // Limite máximo de temperatura
    public float temperaturaMinima = -100f;  // Limite mínimo de temperatura

    /// <summary>
    /// Conexões em cada uma das seis faces do bloco:
    /// 0 = Superior
    /// 1 = Inferior
    /// 2 = Esquerda
    /// 3 = Direita
    /// 4 = Frontal
    /// 5 = Traseira
    /// </summary>
    public ConexaoFace[] conexoes = new ConexaoFace[6]
    {
        new ConexaoFace(), // Superior
        new ConexaoFace(), // Inferior
        new ConexaoFace(), // Esquerda
        new ConexaoFace(), // Direita
        new ConexaoFace(), // Frontal
        new ConexaoFace()  // Traseira
    };

    /// <summary>
    /// Aplica transferência de calor entre este bloco e outro, considerando as faces conectadas.
    /// </summary>
    public void TransferirCalor(DadosBloco outroBloco, int indiceFaceLocal, int indiceFaceOutro)
    {
        ConexaoFace minhaFace = conexoes[indiceFaceLocal];
        ConexaoFace faceOutro = outroBloco.conexoes[indiceFaceOutro];

        // Só transfere se ambas as faces permitirem calor
        if (minhaFace.transmiteCalor && faceOutro.transmiteCalor)
        {
            float diferenca = temperaturaAtual - outroBloco.temperaturaAtual;

            // Se houver diferença, troca calor proporcionalmente à eficiência
            if (Mathf.Abs(diferenca) > 0.01f)
            {
                float transferencia = diferenca * 0.1f * minhaFace.eficienciaTermica * faceOutro.eficienciaTermica;

                temperaturaAtual -= transferencia;
                outroBloco.temperaturaAtual += transferencia;

                // Limita às temperaturas máximas e mínimas
                temperaturaAtual = Mathf.Clamp(temperaturaAtual, temperaturaMinima, temperaturaMaxima);
                outroBloco.temperaturaAtual = Mathf.Clamp(outroBloco.temperaturaAtual, outroBloco.temperaturaMinima, outroBloco.temperaturaMaxima);
            }
        }
    }
}
