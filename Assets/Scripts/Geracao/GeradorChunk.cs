using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Responsável por gerar os dados e a malha de um único chunk.
/// Cada chunk possui largura e profundidade fixas e altura máxima do mundo.
/// </summary>
public class GeradorChunk : MonoBehaviour
{
    [Header("Configurações do Chunk")]
    public int tamanhoChunkLargura = 20;
    public int tamanhoChunkProfundidade = 20;
    public int alturaDoMundo = 300;

    public int coordenadaChunkX;
    public int coordenadaChunkZ;

    private uint[] dadosBlocos;
    private MeshFilter filtroDeMalha;
    private MeshRenderer renderizadorDeMalha;

    private void Awake()
    {
        dadosBlocos = new uint[tamanhoChunkLargura * tamanhoChunkProfundidade * alturaDoMundo];
        filtroDeMalha = gameObject.AddComponent<MeshFilter>();
        renderizadorDeMalha = gameObject.AddComponent<MeshRenderer>();
    }

    /// <summary>
    /// Inicializa os blocos do chunk.
    /// Exemplo simples: até altura 10 preenche com pedra, acima é ar.
    /// </summary>
    public void InicializarDados()
    {
        for (int x = 0; x < tamanhoChunkLargura; x++)
        {
            for (int z = 0; z < tamanhoChunkProfundidade; z++)
            {
                for (int y = 0; y < alturaDoMundo; y++)
                {
                    if (y < 10) // simples teste inicial
                        SetBloco(x, y, z, 1); // 1 = pedra
                    else
                        SetBloco(x, y, z, 0); // 0 = ar
                }
            }
        }
    }

    /// <summary>
    /// Gera a malha do chunk renderizando apenas as faces visíveis.
    /// </summary>
    public void GerarMalha()
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangulos = new List<int>();

        for (int x = 0; x < tamanhoChunkLargura; x++)
        {
            for (int z = 0; z < tamanhoChunkProfundidade; z++)
            {
                for (int y = 0; y < alturaDoMundo; y++)
                {
                    uint bloco = GetBloco(x, y, z);
                    if (bloco == 0) continue; // não renderiza ar

                    // Para cada bloco, verificar vizinhos e adicionar apenas faces externas
                    if (VizinhoTransparente(x + 1, y, z)) AdicionarFace(vertices, triangulos, new Vector3(x + 1, y, z), Vector3.right);
                    if (VizinhoTransparente(x - 1, y, z)) AdicionarFace(vertices, triangulos, new Vector3(x, y, z), Vector3.left);
                    if (VizinhoTransparente(x, y + 1, z)) AdicionarFace(vertices, triangulos, new Vector3(x, y + 1, z), Vector3.up);
                    if (VizinhoTransparente(x, y - 1, z)) AdicionarFace(vertices, triangulos, new Vector3(x, y, z), Vector3.down);
                    if (VizinhoTransparente(x, y, z + 1)) AdicionarFace(vertices, triangulos, new Vector3(x, y, z + 1), Vector3.forward);
                    if (VizinhoTransparente(x, y, z - 1)) AdicionarFace(vertices, triangulos, new Vector3(x, y, z), Vector3.back);
                }
            }
        }

        Mesh malha = new Mesh();
        malha.vertices = vertices.ToArray();
        malha.triangles = triangulos.ToArray();
        malha.RecalculateNormals();

        filtroDeMalha.mesh = malha;
    }

    private bool VizinhoTransparente(int x, int y, int z)
    {
        if (x < 0 || x >= tamanhoChunkLargura || z < 0 || z >= tamanhoChunkProfundidade || y < 0 || y >= alturaDoMundo)
            return true; // fora do chunk consideramos ar
        return GetBloco(x, y, z) == 0;
    }

    private void AdicionarFace(List<Vector3> vertices, List<int> triangulos, Vector3 posicao, Vector3 direcao)
    {
        int verticeInicial = vertices.Count;

        // Criação simplificada de face (um quadrado)
        vertices.Add(posicao);
        vertices.Add(posicao + Vector3.up);
        vertices.Add(posicao + Vector3.up + direcao);
        vertices.Add(posicao + direcao);

        triangulos.Add(verticeInicial);
        triangulos.Add(verticeInicial + 1);
        triangulos.Add(verticeInicial + 2);
        triangulos.Add(verticeInicial);
        triangulos.Add(verticeInicial + 2);
        triangulos.Add(verticeInicial + 3);
    }

    private int CalcularIndice(int x, int y, int z)
    {
        return x + z * tamanhoChunkLargura + y * tamanhoChunkLargura * tamanhoChunkProfundidade;
    }

    public void SetBloco(int x, int y, int z, uint id)
    {
        dadosBlocos[CalcularIndice(x, y, z)] = id;
    }

    public uint GetBloco(int x, int y, int z)
    {
        return dadosBlocos[CalcularIndice(x, y, z)];
    }
}
