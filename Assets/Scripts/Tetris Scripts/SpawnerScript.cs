using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public List<GameObject> shapelist;
    List<Shapescript> Tetrominos = new List<Shapescript>();
    [HideInInspector]
    public static Transform[,] board;
    bool end;
    void Start()
    {
        board = new Transform[13, 11];
        GameObject shape = Instantiate(shapelist[Random.Range(0, shapelist.Count)], transform.position , Quaternion.identity);
        shape.transform.parent = transform;
        Tetrominos.Add(shape.transform.GetComponent<Shapescript>());
        end = false;
    }

    void Update()
    {
        if (!end)
        {
            if (shouldSpawn())
            {
                GameObject shape = Instantiate(shapelist[Random.Range(0, shapelist.Count)], transform.position, Quaternion.identity);
                shape.transform.parent = transform;

                Tetrominos.Add(shape.transform.GetComponent<Shapescript>());
            }
        }
        //clearRows();

    }

    bool shouldSpawn()
    {
        foreach (Shapescript sc in Tetrominos)
        {
            if (sc.active)
            {
                return false;
            }
        }
        return true;
    }
    void clearRows()
    {
        for(int j = 0; j < board.GetLength(0); j++)
        {
            if (rowFull(j))
            {
                clearRow(j);
            }
        }
    }

    void clearRow(int row)
    {
        for (int i = 0; i < board.GetLength(1); i++)
        {
            Destroy(board[row, i].gameObject);
            board[row, i] = null;
        }
        for (int i = row ; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] != null)
                {
                    board[i - 1, j] = board[i, j];
                    board[i, j].position += new Vector3(0, -1);
                    board[i, j] = null;
                }
            }

        }
    }

    bool rowFull(int row)
    {
        for(int i = 0; i < board.GetLength(1); i++)
        {
            if(board[row,i] == null)
            {
                return false;
            }

        }
        return true;
    }

    public void EndGame()
    {
        end = true;
        Debug.Log("ENDED");
        printboard();
    }
    public void printboard()
    {
        string whole = "\n";
        for (int i = 12; i >= 0; i--)
        {
            string row = "[";
            for (int j = 0; j < 11; j++)
            {
                if (board[i, j] != null)
                {
                    row += "X, ";
                }
                else
                {
                    row += "O, ";
                }

            }
            row += "]\n";
            whole += row;
        }
        
        Debug.Log(whole);
        Debug.Log(GetScore());

    }
    public float GetScore()
    {
        float filled = 0;
        float total = 0;
        for (int i = 0; i < board.GetLength(0)-2; i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] != null)
                {
                    filled++;
                }
                total++;
            }

        }
        return (filled / total) * 100;
    }
}
