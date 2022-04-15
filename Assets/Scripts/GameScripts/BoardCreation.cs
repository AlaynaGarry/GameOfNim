using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreation : MonoBehaviour
{
    [SerializeField] GameObject gamePiece;

    public int rows;
    public int TopRowCount;

    Dictionary<int, List<GameObject>> board = new Dictionary<int, List<GameObject>>();
    

    public void StartGame()
    {
        for (int i = 0; i < rows; i++)
        {
            List<GameObject> newList = new List<GameObject> { };
            for (int j = 0; j < TopRowCount + (2 * i); j++)
            {
                newList.Add(gamePiece);
            }
            board.Add(i + 1, newList);
        }   
    }
}
