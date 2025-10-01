using UnityEngine;

/// <summary>
/// Lógica da tela principal de login.
/// </summary>
public class GerenciadorTelaLogin : MonoBehaviour
{
    public GerenciadorLogin gerenciador;

    public void BotaoCarregarMundo()
    {
        gerenciador.AbrirTelaCarregarMundo();
    }

    public void BotaoCriarModificacoes()
    {
        gerenciador.AbrirTelaModificacoes();
    }

    public void BotaoSelecionarPersonagem()
    {
        gerenciador.AbrirTelaSelecionarPersonagem();
    }
}
