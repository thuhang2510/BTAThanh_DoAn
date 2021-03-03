using System.Collections.Generic;
using System.Linq;

class Dijkstra
{
    private Graph g;
    private List<string> vertexName;

    public Dijkstra(Graph g, List<string> vertexName)
    {
        this.g = g;
        this.vertexName = vertexName;
    }

    private int timDinhCoDDMin(int[] dist, bool[] visited)
    {
        int min = int.MaxValue;
        int vertex = -1;

        for (int i = 0; i < dist.Length; ++i)
            if (min > dist[i] && visited[i] == false)
            {
                min = dist[i];
                vertex = i;
            }

        return vertex;
    }

    private int[] dijkstra(int uBD, int phuongTien)
    {
        int[] dist = Enumerable.Repeat(int.MaxValue, g.n).ToArray();
        int[] pre = Enumerable.Repeat(-1, g.n).ToArray();
        bool[] visited = new bool[g.n];

        dist[uBD] = 0;

        for (int i = 0; i < g.n; ++i)
        {
            int u = timDinhCoDDMin(dist, visited);

            if (u == -1)
                break;

            visited[u] = true;

            for (int v = 0; v < g.n; ++v)
            {
                if (visited[v] == false && g[u, v].weight > 0 && (g[u, v].vehicle == phuongTien || g[u, v].vehicle == 2))
                {
                    int alt = dist[u] + g[u, v].weight;

                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        pre[v] = u;
                    }
                }
            }
        }

        return pre;
    }

    private (int uBD, int uKT) layDiemBD_KT(string vertexStart, string vertexEnd)
    {
        int uBD = -1;
        int uKT = -1;

        for (int i = 0; i < vertexName.Count; ++i)
        {
            if (vertexName[i] == vertexStart)
                uBD = i;

            if (vertexName[i] == vertexEnd)
                uKT = i;
        }

        return (uBD, uKT);
    }

    public List<string> findPath(string startVertex, string endVertex, int vehicle)
    {
        (int uBD, int uKT) = layDiemBD_KT(startVertex, endVertex);

        if (uBD == -1 || uKT == -1)
            return null;

        int[] pre = dijkstra(uBD, vehicle);

        if (pre[uKT] == -1)
            return null;

        List<string> path = new List<string>();

        path.Add(vertexName[uKT]);

        while (pre[uKT] != -1)
        {
            int vertexFirst = pre[uKT];
            path.Add(vertexName[vertexFirst]);
            uKT = vertexFirst;
        }

        path.Reverse();

        return path;
    }
}