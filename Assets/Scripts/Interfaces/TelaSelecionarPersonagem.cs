using UnityEngine;

/// <summary>
/// Tela para seleção de personagem (placeholder).
/// </summary>
public class TelaSelecionarPersonagem : MonoBehaviour
{
    public GerenciadorLogin gerenciador;

    public void BotaoVoltar()
    {
        gerenciador.MostrarTelaPrincipal();
    }
}
