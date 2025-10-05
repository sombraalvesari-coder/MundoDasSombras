// ConfiguradorItemMundo.cs

using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System;

/// <summary>
/// Controla a exibição e o comportamento de um item individual na lista de mundos.
/// </summary>
public class ConfiguradorItemMundo : MonoBehaviour
{
    // REFERÊNCIAS DE INTERFACE
    // Textos (Estes estão diretamente no PainelTemplateMundo)
    public TextMeshProUGUI textoNomeMundo;
    public TextMeshProUGUI textoDataCriacao;
    public TextMeshProUGUI textoTempoJogo;
    
    // Imagens e Botões (Estes estão dentro do PainelInterativo, mas a referência é direta)
    public Image imagemCapa;
    public Button botaoFavorito; 
    public Image iconeDisponibilidade; // Ícone que mostra status online/offline

    // DADOS
    private DadosMundo dadosDoMundo;
    private ListaMundos gerenciadorLista; 

    /// <summary>
    /// Configura o item com os dados do mundo e referências necessárias.
    /// </summary>
    public void Configurar(DadosMundo dados, ListaMundos gerenciador, Sprite iconeDisponivel, Sprite iconeIndisponivel)
    {
        this.dadosDoMundo = dados;
        this.gerenciadorLista = gerenciador;

        // 1. PREENCHIMENTO DOS TEXTOS
        textoNomeMundo.text = dados.nomeDoMundo;
        
        // Formato: dd/mm/aaaa
        textoDataCriacao.text = "Data Criado: " + dados.dataDeCriacao.ToString("dd/MM/yyyy");
        
        // Formato: aa/mm/dd/hh:mm:ss
        // Cálculo simplificado de anos/meses/dias/horas
        string tempo = $"{dados.tempoTotalDeJogo.Days / 365}a / {dados.tempoTotalDeJogo.Days % 365 / 30}m / {dados.tempoTotalDeJogo.Days % 30}d / {dados.tempoTotalDeJogo.Hours:D2}:{dados.tempoTotalDeJogo.Minutes:D2}:{dados.tempoTotalDeJogo.Seconds:D2}";
        textoTempoJogo.text = "Tempo de Jogo: " + tempo;

        // 2. DISPONIBILIDADE ONLINE (Apenas o ícone será preenchido)
        if (dados.disponivelOnline)
        {
            iconeDisponibilidade.sprite = iconeDisponivel;
            iconeDisponibilidade.color = Color.green;
        }
        else
        {
            iconeDisponibilidade.sprite = iconeIndisponivel;
            iconeDisponibilidade.color = Color.red;
        }
        
        // 3. FAVORITAR
        AtualizarVisualFavorito(dados.eFavorito);
        
        // Configura o clique no botão para chamar a função de favoritar
        botaoFavorito.onClick.RemoveAllListeners();
        botaoFavorito.onClick.AddListener(AoClicarEmFavoritar);
    }

    private void AoClicarEmFavoritar()
    {
        bool novoEstado = !dadosDoMundo.eFavorito;
        gerenciadorLista.AlternarFavorito(dadosDoMundo, novoEstado);
    }
    
    /// <summary>
    /// Atualiza o visual do botão de favorito.
    /// </summary>
    public void AtualizarVisualFavorito(bool favorito)
    {
        // Exemplo: Mudar a cor do botão favorito para amarelo se for favorito
        Color cor = favorito ? Color.yellow : Color.white;
        botaoFavorito.GetComponent<Image>().color = cor;
    }
}