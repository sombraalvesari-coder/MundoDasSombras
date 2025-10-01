using UnityEngine;

/// <summary>
/// Controla as ações dentro da tela de modificações.
/// </summary>
public class TelaModificacoes : MonoBehaviour
{
    public GerenciadorLogin gerenciador;

    public void VoltarParaTelaPrincipal()
    {
        gerenciador.AbrirTelaPrincipal();
    }
}
