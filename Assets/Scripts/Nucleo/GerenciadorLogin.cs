using UnityEngine;

/// <summary>
/// Controla a exibição dos painéis da tela de login.
/// </summary>
public class GerenciadorLogin : MonoBehaviour
{
    [Header("Referências dos Painéis")]
    public GameObject painelTelaPrincipal;
    public GameObject painelCarregarMundo;
    public GameObject painelCriarModificacoes;
    public GameObject painelSelecionarPersonagem;

    /// <summary>
    /// Esconde todos os painéis.
    /// </summary>
    private void EsconderTodos()
    {
        painelTelaPrincipal.SetActive(false);
        painelCarregarMundo.SetActive(false);
        painelCriarModificacoes.SetActive(false);
        painelSelecionarPersonagem.SetActive(false);
    }

    public void AbrirTelaPrincipal()
    {
        EsconderTodos();
        painelTelaPrincipal.SetActive(true);
    }

    public void AbrirTelaCarregarMundo()
    {
        EsconderTodos();
        painelCarregarMundo.SetActive(true);
    }

    public void AbrirTelaModificacoes()
    {
        EsconderTodos();
        painelCriarModificacoes.SetActive(true);
    }

    public void AbrirTelaSelecionarPersonagem()
    {
        EsconderTodos();
        painelSelecionarPersonagem.SetActive(true);
    }
}
