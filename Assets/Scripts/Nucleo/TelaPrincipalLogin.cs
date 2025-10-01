using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla a tela de login inicial.
/// Aqui o jogador informa o nome e escolhe configurações básicas do mundo.
/// </summary>
public class TelaPrincipalLogin : MonoBehaviour
{
    [Header("Referências da Interface")]
    public InputField campoNomeJogador;
    public Toggle caixaGerarIlha;
    public Button botaoCriarMundo;
    public Button botaoCarregarMundo;

    private void Start()
    {
        botaoCriarMundo.onClick.AddListener(CriarNovoMundo);
        botaoCarregarMundo.onClick.AddListener(CarregarMundoExistente);
    }

    private void CriarNovoMundo()
    {
        string nomeJogador = campoNomeJogador.text;
        bool gerarIlha = caixaGerarIlha.isOn;

        // Aqui poderíamos salvar as opções em PlayerPrefs ou classe estática
        PlayerPrefs.SetString("NomeJogador", nomeJogador);
        PlayerPrefs.SetInt("GerarIlha", gerarIlha ? 1 : 0);

        // Carrega a cena principal do jogo (depois criamos essa cena)
        SceneManager.LoadScene("CenaPrincipal");
    }

    private void CarregarMundoExistente()
    {
        // Exemplo simples: apenas abre a cena principal
        SceneManager.LoadScene("CenaPrincipal");
    }
}
