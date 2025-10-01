using UnityEngine;

/// <summary>
/// Gera um mapa composto por vários chunks.
/// </summary>
public class GeradorMapa : MonoBehaviour
{
    public int tamanhoMapaEmChunksX = 10;
    public int tamanhoMapaEmChunksZ = 10;
    public int sementeBase = 12345;

    public GameObject prefabChunk;

    public void GerarMapa(int coordenadaMapaX, int coordenadaMapaZ)
    {
        for (int x = 0; x < tamanhoMapaEmChunksX; x++)
        {
            for (int z = 0; z < tamanhoMapaEmChunksZ; z++)
            {
                Vector3 posicao = new Vector3((coordenadaMapaX * tamanhoMapaEmChunksX + x) * 20, 0, (coordenadaMapaZ * tamanhoMapaEmChunksZ + z) * 20);
                GameObject novoChunk = Instantiate(prefabChunk, posicao, Quaternion.identity);
                GeradorChunk scriptChunk = novoChunk.GetComponent<GeradorChunk>();
                scriptChunk.InicializarDados();
                scriptChunk.GerarMalha();
            }
        }
    }
}
