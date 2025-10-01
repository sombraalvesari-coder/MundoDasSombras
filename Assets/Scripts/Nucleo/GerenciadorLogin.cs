using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gerencia a navegação entre as telas do login.
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

    public void AbrirTelaCarregarMundo()
    {
        telaPrincipal.SetActive(false);
        telaCarregarMundo.SetActive(true);
    }

    public void AbrirTelaModificacoes()
    {
        telaPrincipal.SetActive(false);
        telaModificacoes.SetActive(true);
    }

    public void AbrirTelaSelecionarPersonagem()
    {
        telaPrincipal.SetActive(false);
        telaSelecionarPersonagem.SetActive(true);
    }
}
