using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Gerencia os mapas carregados com base na posição do jogador.
/// </summary>
public class GerenciadorMundo : MonoBehaviour
{
    public Transform jogador;
    public int raioDeMapasCarregados = 2;

    private Dictionary<string, GameObject> mapasCarregados = new Dictionary<string, GameObject>();

    private void Update()
    {
        AtualizarCarregamento();
    }

    private void AtualizarCarregamento()
    {
        // Posição do mapa atual do jogador (simplificado)
        int mapaX = Mathf.FloorToInt(jogador.position.x / (20 * 10));
        int mapaZ = Mathf.FloorToInt(jogador.position.z / (20 * 10));

        // Carregar mapas no raio
        for (int x = -raioDeMapasCarregados; x <= raioDeMapasCarregados; x++)
        {
            for (int z = -raioDeMapasCarregados; z <= raioDeMapasCarregados; z++)
            {
                string chave = (mapaX + x) + "_" + (mapaZ + z);
                if (!mapasCarregados.ContainsKey(chave))
                {
                    GameObject mapa = new GameObject("Mapa_" + chave);
                    mapa.AddComponent<GeradorMapa>().GerarMapa(mapaX + x, mapaZ + z);
                    mapasCarregados[chave] = mapa;
                }
            }
        }
    }
}
