using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject Square;
    public List<Color> colorList;
    public int height;
    public int width;
    GameObject[,] board;
    int[,] colorBoard ;

    void Start()
    {
        board = new GameObject[height, width];
        colorBoard = new int[height, width];
        generate_board();
    }

    // Update is called once per frame
    void Update()
    {
        update_board();
    }

    void generate_board()
    {
        for(int i = 0; i < height; i++)
        {
            for( int j = 0; j < width; j++)
            {
                colorBoard[i, j] = 0;
                board[i,j] = Instantiate(Square, transform.position +new Vector3(j,i,0), Quaternion.identity);
                board[i, j].transform.parent = transform;
            }
        }

    }

    void update_board()
    {
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {


                board[i, j].transform.GetComponent<SpriteRenderer>().color = colorList[colorBoard[i, j]];

            }
        }
    }
}
