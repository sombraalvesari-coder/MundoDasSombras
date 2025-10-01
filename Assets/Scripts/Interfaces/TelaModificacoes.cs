using UnityEngine;

/// <summary>
/// Tela para gerenciar modificações (mods).
/// </summary>
public class TelaModificacoes : MonoBehaviour
{
    public GerenciadorLogin gerenciador;

    public void BotaoVoltar()
    {
        gerenciador.MostrarTelaPrincipal();
    }

    public void BotaoNovaModificacao()
    {
        Debug.Log("Criar nova modificação (ainda não implementado)");
    }

    public void BotaoEditarModificacao()
    {
        Debug.Log("Editar modificação existente (ainda não implementado)");
    }

    public void BotaoApagarModificacao()
    {
        Debug.Log("Apagar modificação (ainda não implementado)");
    }

    public void BotaoLojaFree()
    {
        Debug.Log("Abrir loja de modificações (ainda não implementado)");
    }
}
