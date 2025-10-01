using UnityEngine;

/// <summary>
/// Controla as ações dentro da tela de seleção de personagem.
/// </summary>
public class TelaSelecionarPersonagem : MonoBehaviour
{
    public GerenciadorLogin gerenciador;

    public void VoltarParaTelaPrincipal()
    {
        gerenciador.AbrirTelaPrincipal();
    }
}
