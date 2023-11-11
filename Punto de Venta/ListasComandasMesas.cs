using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ListasComandasMesas
{
    public static List<List<string>> Comandas { get; private set; }
    public static List<List<string>> Mesas { get; private set; }

    static ListasComandasMesas()
    {
        Comandas = new List<List<string>>();
        Mesas = new List<List<string>>();

        for (int i = 0; i < 20; i++)
        {
            Comandas.Add(new List<string>());
        }

        for (int i = 0; i < 20; i++)
        {
            Mesas.Add(new List<string>());
        }

    }
    public static bool TodasLasMesasEstanVacias()
    {
        // Verifica si TODAS las listas dentro de Mesas están vacías
        return Mesas.All(mesa => mesa.Count == 0);
    }
}