using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Sistema simples de salvamento e carregamento de chunks em arquivos binários.
/// </summary>
public static class SistemaSalvamento
{
    public static void SalvarChunk(uint[] dadosBlocos, string caminhoArquivo)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream arquivo = File.Create(caminhoArquivo);
        bf.Serialize(arquivo, dadosBlocos);
        arquivo.Close();
    }

    public static uint[] CarregarChunk(string caminhoArquivo)
    {
        if (File.Exists(caminhoArquivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream arquivo = File.Open(caminhoArquivo, FileMode.Open);
            uint[] dadosBlocos = (uint[])bf.Deserialize(arquivo);
            arquivo.Close();
            return dadosBlocos;
        }
        return null;
    }
}
