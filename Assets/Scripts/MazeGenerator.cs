using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int width, height;
    public GameObject sonido;
    // Genera un numero aleatorio entero entre dos números
    public int Random(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }
    // Busca en un array de dos dimensiones interpretado como un mapa, si la posicion esta vacia o no
    public bool place_free(int[,] map, int x, int y)
    {
        return map[x, y] == 0;
    }
    // Genera el suelo y paredes con un mapa creado
    public void Materializar_nivel(int[,] map, int minx, int miny)
    {
        for (int xm = 1; xm < map.GetLength(0) - 1; xm++)
        {
            for (int ym = 1; ym < map.GetLength(1) - 1; ym++)
            {
                bool left = place_free(map, xm - 1, ym);
                bool right = place_free(map, xm + 1, ym);
                bool front = place_free(map, xm, ym + 1);
                bool back = place_free(map, xm, ym - 1);
                bool fleft = place_free(map, xm - 1, ym + 1);
                bool fright = place_free(map, xm + 1, ym + 1);
                bool bleft = place_free(map, xm - 1, ym - 1);
                bool bright = place_free(map, xm + 1, ym - 1);
                bool htile = false;
                if (map[xm, ym] == 1)
                {
                    htile = true;
                }
                else
                {
                    htile = false;
                }
                int tile = 0;
                if (front && left && back && !right)
                {
                    tile = 1;
                }
                if (front && !left && !right && back)
                {
                    tile = 2;
                }
                if (front && right && back && !left)
                {
                    tile = 3;
                }
                if (left && front && right && !back)
                {
                    tile = 4;
                }
                if (left && !front && !back && right)
                {
                    tile = 5;
                }
                if (left && back && right && !front)
                {
                    tile = 6;
                }
                if (left && front && !right && !back && !bright)
                {
                    tile = 7;
                }
                if (!left && front && !right && !back && !bleft && !bright)
                {
                    tile = 8;
                }
                if (!left && front && right && !back && !bleft)
                {
                    tile = 9;
                }
                if (left && !front && !back && !right && !fright && !bright)
                {
                    tile = 10;
                }
                if (!left && !fleft && !front && !fright && !right && !bright && !back && !bleft)
                {
                    tile = 11;
                }
                if (!left && !front && !back && right && !fleft && !bleft)
                {
                    tile = 12;
                }
                if (left && back && !right && !front && !fright)
                {
                    tile = 13;
                }
                if (!left && !front && !right && !fleft && !fright && back)
                {
                    tile = 14;
                }
                if (!left && back && right && !fleft && !front)
                {
                    tile = 15;
                }
                if (left && front && bright && !back && !right)
                {
                    tile = 16;
                }
                if (!left && front && !back && !right && bleft && bright)
                {
                    tile = 17;
                }
                if (!left && front && bleft && !back && right)
                {
                    tile = 18;
                }
                if (left && !right && !front && !back && fright && bright)
                {
                    tile = 19;
                }
                if (!left && !right && !front && !back && fleft && fright && bleft && bright)
                {
                    tile = 20;
                }
                if (!left && right && !front && !back && fleft && bleft)
                {
                    tile = 21;
                }
                if (left && back && !front && !right && fright)
                {
                    tile = 22;
                }
                if (!left && !front && !right && back && fleft && fright)
                {
                    tile = 23;
                }
                if (!left && right && !front && back && fleft)
                {
                    tile = 24;
                }
                if (!left && !front && !right && !back && bright && !fright && !fleft && !bleft)
                {
                    tile = 25;
                }
                if (!left && !right && !front && !fleft && !fright && !back && bleft && bright)
                {
                    tile = 26;
                }
                if (bleft && !left && !fleft && !front && !fright && !right && !bright && !back)
                {
                    tile = 27;
                }
                if (!front && !fleft && !left && !bleft && !back && !right && fright && bright)
                {
                    tile = 28;
                }
                if (!front && !fright && !right && !bright && !back && !left && fleft && bleft)
                {
                    tile = 29;
                }
                if (!front && !fleft && !left && !bleft && !back && !bright && !right && fright)
                {
                    tile = 30;
                }
                if (!front && !left && !bleft && !back && !bright && !right && fright && fleft)
                {
                    tile = 31;
                }
                if (!front && !left && !bleft && !back && !bright && !right && !fright && fleft)
                {
                    tile = 32;
                }
                if (front && !left && !bleft && !back && !right && bright)
                {
                    tile = 33;
                }
                if (front && !left && bleft && !back && !bright && !right)
                {
                    tile = 34;
                }
                if (!front && left && !back && !right && bright && !fright)
                {
                    tile = 35;
                }
                if (!front && !left && !back && right && bleft && !fleft)
                {
                    tile = 36;
                }
                if (!front && left && !back && !right && fright && !bright)
                {
                    tile = 37;
                }
                if (!front && !left && !back && right && fleft && !bleft)
                {
                    tile = 38;
                }
                if (!front && !left && back && !right && fright && !fleft)
                {
                    tile = 39;
                }
                if (!front && !left && back && !right && fleft && !fright)
                {
                    tile = 40;
                }
                if (!front && !fleft && !left && !right && !bright && !back && bleft && fright)
                {
                    tile = 41;
                }
                if (!front && !fright && !left && !right && !bleft && !back && bright && fleft)
                {
                    tile = 42;
                }
                if (!front && !right && !left && !fleft && !back && fright && bright && bleft)
                {
                    tile = 43;
                }
                if (!front && !right && !left && fleft && !back && !fright && bright && bleft)
                {
                    tile = 44;
                }
                if (!front && !right && !left && fleft && !back && fright && bright && !bleft)
                {
                    tile = 45;
                }
                if (!front && !right && !left && fleft && !back && fright && !bright && bleft)
                {
                    tile = 46;
                }
                if (left && fleft && front && fright && right && bright && back && bleft)
                {
                    tile = 0;
                }
                if (htile)
                {
                    if (Resources.Load("Prefabs/Tile " + tile) != null)
                    {
                        GameObject np = (GameObject)Instantiate(Resources.Load("Prefabs/Tile " + tile));
                        np.transform.position = new Vector3((xm - 1 - Mathf.Abs(minx)) * 10, 0f, (ym - 1 - Mathf.Abs(miny)) * 10);
                        np.name = "Tile " + tile;
                    }
                }
            }
        }
    }
    public bool Maze_completed(int[,] dg_maze)
    {
        int gw = (int)(dg_maze.GetLength(0) / 2);
        int gh = (int)(dg_maze.GetLength(1) / 2);

        int gy = 0;
        bool re = true;
        while (gy <= gh && re)
        {
            int gx = 0;
            while (gx <= gw && re)
            {
                if (dg_maze[gx * 2, gy * 2] == 0)
                {
                    re = false;
                }
                gx++;
            }
            gy++;
        }
        return re;
    }
    public bool Have_Neighbor(int[,] dg_maze, int x,int y)
    {
        int gw = dg_maze.GetLength(0);
        int gh = dg_maze.GetLength(1);
        return ((x + 2 <= gw) && dg_maze[x + 2, y] == 0)
            || ((x - 2 >= 0) && dg_maze[x - 2, y] == 0)
            || ((y + 2 <= gh) && dg_maze[x, y + 2] == 0)
            || ((y - 2 >= 0) && dg_maze[x, y - 2] == 0);
    }
    public int[] FirstEmpty(int[,] dg_maze)
    {
        int gw = (int)(dg_maze.GetLength(0) / 2) * 2;
        int gh = (int)(dg_maze.GetLength(1) / 2) * 2;
        int gy = 0;
        int[] p = new int[2];
        p[0] = 0;
        p[1] = 0;
        bool re = true;
        while ((gy <= gh) && re)
        {
            int gx = 0;
            while (gx <= gw && re)
            {
                if (dg_maze[gx, gy] == 0)
                {
                    if ((gx + 2 <= gw) && dg_maze[gx + 2, gy] != 0)
                    {
                        dg_maze[gx + 1, gy] = 1;
                        re = false;
                    }
                    else
                    if ((gx - 2 >= 0) && dg_maze[gx - 2, gy] != 0)
                    {
                        dg_maze[gx - 1, gy] = 1;
                        re = false;
                    }
                    else
                    if ((gy + 2 <= gh) && dg_maze[gx, gy + 2] != 0)
                    {
                        dg_maze[gx, gy + 1] = 1;
                        re = false;
                    }
                    else
                    if ((gy - 2 >= 0) && dg_maze[gx, gy - 2] != 0)
                    {
                        dg_maze[gx, gy - 1] = 1;
                        re = false;
                    }
                    if (!re)
                    {
                        dg_maze[gx, gy] = 1;
                        p[0] = gx;
                        p[1] = gy;
                    }
                }
                if (re)
                {
                    gx += 2;
                }
            }
            if (re)
            {
                gy += 2;
            }
        }
        return p;
    }
    public int[,] HuntAndKill(int width, int height)
    {
        int gw = width;
        int gh = height;
        int[,] dg_maze = new int[(int)(gw / 2) * 2 + 1, (int)(gh / 2) * 2 + 1];
        for (int gy = 0; gy < gh; gy++)
        {
            for (int gx = 0; gx < gw; gx++)
            {
                dg_maze[gx, gy] = 0;
            }
        }
        int ax = (int)(Random(0,gw+1) / 2) * 2;
        int ay = (int)(Random(0,gh+1) / 2) * 2;
        while (!Maze_completed(dg_maze))
        {
            while (Have_Neighbor(dg_maze, ax, ay))
            {
                int dx = 0;
                int dy = 0;
                int dir = Random(0,4);
                switch (dir)
                {
                    case 0:
                        if (ax + 2 <= gw)
                        {
                            ax += 2;
                            dx = -1;
                        }
                        break;
                    case 1:
                        if (ax - 2 >= 0)
                        {
                            ax -= 2;
                            dx = 1;
                        }
                        break;
                    case 2:
                        if (ay + 2 <= gh)
                        {
                            ay += 2;
                            dy = -1;
                        }
                        break;
                    case 3:
                        if (ay - 2 >= 0)
                        {
                            ay -= 2;
                            dy = 1;
                        }
                        break;
                }
                if (dg_maze[ax, ay] == 0)
                {
                    dg_maze[ax, ay] = 1;
                    dg_maze[ax + dx, ay + dy] = 1;
                }
            }
            int[] ap = FirstEmpty(dg_maze);
            ax = ap[0];
            ay = ap[1];
        }
        int[,] dg_final = new int[gw+2,gh+2];
        for (int gy = 0; gy < gh+2; gy++)
        {
            for (int gx = 0; gx < gw+2; gx++)
            {
                dg_final[gx, gy] = 0;
            }
        }
        for (int gy = 0; gy < gh; gy++)
        {
            for (int gx = 0; gx < gw; gx++)
            {
                dg_final[gx+1, gy+1] = dg_maze[gx,gy];
            }
        }
        return dg_final;
    }
    public int[,] map;
    public GameObject[] gos;
    void Start()
    {
        UnityEngine.Random.InitState(System.Environment.TickCount);
        int[,] map = HuntAndKill(this.width,this.height);
        Materializar_nivel(map,0,0);
        sonido.GetComponent<Transform>().position = new Vector3((this.width-1) * 10,-3.2f,(this.height-1) * 10);
    }
    void Update()
    {

    }
}
