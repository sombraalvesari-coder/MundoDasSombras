// ListaMundos.cs

using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Necessário para facilitar a ordenação (OrderBy, ThenBy)

public class ListaMundos : MonoBehaviour
{
    // PREFABS E REFERÊNCIAS DE INTERFACE
    // O prefab para cada item da lista (Prefabs/Interfaces/ItemMundo.prefab)
    public GameObject prefabItemMundo; 
    
    // O objeto 'Content' do Scroll View, onde os itens serão adicionados.
    public Transform conteudoScroll; 

    // Ícones que serão exibidos para a disponibilidade online.
    public Sprite iconeDisponivel;
    public Sprite iconeIndisponivel;

    // DADOS
    private List<DadosMundo> listaDeMundosSalvos = new List<DadosMundo>();
    
    // Apenas para testes visuais
    private void Start()
    {
        // ----------------------------------------------------
        // DADOS DE EXEMPLO (SERÃO SUBSTITUÍDOS PELO SALVAMENTO REAL)
        // ----------------------------------------------------
        
        // Mundo Favorito (deve aparecer primeiro)
        listaDeMundosSalvos.Add(new DadosMundo 
        { 
            nomeDoMundo = "Meu Mundo Favorito", 
            dataDeCriacao = System.DateTime.Now.AddDays(-50), 
            dataDaUltimaPartida = System.DateTime.Now.AddHours(-1), // Mais recente
            tempoTotalDeJogo = System.TimeSpan.FromHours(100),
            disponivelOnline = true, 
            eFavorito = true 
        });

        // Mundo Antigo (deve aparecer por último)
        listaDeMundosSalvos.Add(new DadosMundo 
        { 
            nomeDoMundo = "Mundo Esquecido", 
            dataDeCriacao = System.DateTime.Now.AddYears(-2), 
            dataDaUltimaPartida = System.DateTime.Now.AddMonths(-6), // Mais antigo
            tempoTotalDeJogo = System.TimeSpan.FromHours(5),
            disponivelOnline = false, 
            eFavorito = false
        });

        // Mundo Normal (deve aparecer entre os outros)
        listaDeMundosSalvos.Add(new DadosMundo 
        { 
            nomeDoMundo = "Projeto Base", 
            dataDeCriacao = System.DateTime.Now.AddDays(-10), 
            dataDaUltimaPartida = System.DateTime.Now.AddDays(-2), // Intermediário
            tempoTotalDeJogo = System.TimeSpan.FromHours(45),
            disponivelOnline = true, 
            eFavorito = false
        });
        
        AtualizarLista();
    }
    
    /// <summary>
    /// Limpa o scroll e popula-o novamente com os mundos, aplicando a ordenação.
    /// </summary>
    public void AtualizarLista()
    {
        // 1. Limpar itens antigos (Destrói todos os filhos do Content)
        foreach (Transform filho in conteudoScroll)
        {
            Destroy(filho.gameObject);
        }
        
        // 2. ORDENAÇÃO
        // Regra: Favorito (eFavorito = true) primeiro, depois data da última partida (mais recente primeiro)
        var mundosOrdenados = listaDeMundosSalvos
            .OrderByDescending(mundo => mundo.eFavorito) // True (favorito) vai para o topo
            .ThenByDescending(mundo => mundo.dataDaUltimaPartida) // Mais recente vai para o topo
            .ToList();
        
        // 3. POPULAR A LISTA
        foreach (var mundo in mundosOrdenados)
        {
            // Cria uma nova instância do prefab de item do mundo dentro do Content.
            GameObject novoItem = Instantiate(prefabItemMundo, conteudoScroll);
            
            // Tenta obter o script do configurador.
            ConfiguradorItemMundo configurador = novoItem.GetComponent<ConfiguradorItemMundo>();

            if (configurador != null)
            {
                // Chama a função de configuração do item, passando o próprio 'ListaMundos' como gerenciador
                configurador.Configurar(mundo, this, iconeDisponivel, iconeIndisponivel);
            }
            else
            {
                Debug.LogError("O ItemMundo.prefab não possui o script ConfiguradorItemMundo.cs anexado! Verifique o prefab.");
            }
        }
    }

    /// <summary>
    /// Gerencia a lógica de favoritar/desfavoritar um mundo.
    /// Chamado pelo ConfiguradorItemMundo ao clicar no botão Favoritar.
    /// </summary>
    public void AlternarFavorito(DadosMundo mundoSelecionado, bool novoEstado)
    {
        // Lógica para garantir que apenas UM mundo seja favorito (regra do projeto)
        if (novoEstado)
        {
            // 1. Desfavoritar todos os outros mundos
            foreach (var mundo in listaDeMundosSalvos)
            {
                mundo.eFavorito = false;
            }
        }
        
        // 2. Aplicar o novo estado ao mundo selecionado
        mundoSelecionado.eFavorito = novoEstado;
        
        // 3. Reordenar e redesenhar a lista para refletir a mudança
        // Isso fará com que o favorito vá para o topo
        AtualizarLista();
        
        // FUTURO: Salvar a mudança de estado do mundo no disco.
        Debug.Log($"Mundo '{mundoSelecionado.nomeDoMundo}' agora é Favorito: {novoEstado}");
    }
}