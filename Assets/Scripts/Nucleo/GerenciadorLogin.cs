using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla a exibição dos painéis da tela de login.
/// </summary>
public class GerenciadorLogin : MonoBehaviour
{
    public GameObject telaPrincipal;
    public GameObject telaCarregarMundo;
    public GameObject telaModificacoes;
    public GameObject telaSelecionarPersonagem;

    /// <summary>
    /// Exibe apenas a tela principal.
    /// </summary>
    void Start()
    {
        MostrarTelaPrincipal();
    }

    public void MostrarTelaPrincipal()
    {
        telaPrincipal.SetActive(true);
        telaCarregarMundo.SetActive(false);
        telaModificacoes.SetActive(false);
        telaSelecionarPersonagem.SetActive(false);
    }

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