using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolAdder : MonoBehaviour
{
    // Determine the space between the smaller symbols
    [SerializeField]
    private float littleSymbolWidth;
    [SerializeField]
    private float littleSymbolHeight;

    // These are the prefabs that are cloned to create all 81 smaller pieces
    public GameObject smallX;
    public GameObject smallO;

    // These are the arrays that manage the big symbols after a player wins on a smaller board
    [SerializeField]
    private GameObject[] XSymbols;
    [SerializeField]
    private GameObject[] OSymbols;

    // This is a 3x3 array of 3x3 arrays of symbols to manage the 81 smaller symbols
    public GameObject[,] miniXSymbolsArray;
    public GameObject[,] miniOSymbolsArray;

    // This puts all of the 81 small symbols on the board ready to be chosen
    void Start()
    {
        // Establish the row length and collumn height of these arrays of arrays
        miniXSymbolsArray = new GameObject[9, 9];
        miniOSymbolsArray = new GameObject[9, 9];

        // Nested for loops iterate through all 81 spots on the board for the little symbols
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                // This is where the 81 X's and 81 O's are cloned from their prefabs and placed in the scene
                miniXSymbolsArray[i,j] = Instantiate(smallX, new Vector3(i * littleSymbolWidth,j * littleSymbolHeight,0), Quaternion.identity);
                miniOSymbolsArray[i,j] = Instantiate(smallO, new Vector3(i * littleSymbolWidth, j * littleSymbolHeight, 0), Quaternion.identity);
            }
        }
    }

    // This function is called by other classes in order to place a big symbol on the board
    public void AddBigSymbol(int position,bool isCircle)
    {
        if (isCircle)
        {
            OSymbols[position].SetActive(true);
        } else
        {
            XSymbols[position].SetActive(true);
        }
    }
}
