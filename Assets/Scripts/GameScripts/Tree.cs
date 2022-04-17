using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] GameObject gamePiece;
    [SerializeField] GameObject Board;
    [SerializeField] GameObject RowForBoard;

    public int rows;
    public int topRowCount;
    public static int? activeRow;

    static Dictionary<int, List<GameObject>> board = new Dictionary<int, List<GameObject>>();
    
    public void RemovePiece(GameObject piece)
    {
        if(activeRow == null)
        {
            activeRow = piece.GetComponent<GamePiece>().Row;
        }

        int row = piece.GetComponent<GamePiece>().Row;
        if(activeRow == row)
        {
            board[row].Remove(piece);
            if(board[row].Count == 0)
            {
                Destroy(piece.transform.parent.gameObject);
            }
            else
            {
                Destroy(piece);
            }
        }
    }

    public void PopulateTree(int rows, int topRowCount)
    {
        this.rows = rows;
        this.topRowCount = topRowCount;

        for (int i = 0; i < rows; i++)
        {
            GameObject row = Instantiate(RowForBoard, Board.transform);
            List<GameObject> newList = new List<GameObject> { };
            for (int j = 0; j < topRowCount + (2 * i); j++)
            {
                GameObject go = Instantiate(gamePiece, row.transform);
                go.GetComponent<GamePiece>().Row = i;
                newList.Add(go);
            }
            board.Add(i, newList);
        }   
    }



}
