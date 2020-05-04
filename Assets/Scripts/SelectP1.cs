using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectP1 : MonoBehaviour
{
    private static IList<Piece> selectedPiece;

    private void Awake()
    {
        selectedPiece = new List<Piece>();
    }

    public void SelectPiece()
    {
        var piece = GetComponent<Piece>();

        selectedPiece.Add(piece);
        Debug.Log(selectedPiece.Count);

        if (selectedPiece.Count > 1)
        {
            AttackPieces();
        }
    }

    private void AttackPieces()
    {
        var player1 = selectedPiece[0];
        var player2 = selectedPiece[1];
        if (player1.Color > 1 && player1.Color != player2.Color && player2.Black == false 
            && isAdjacent(player1, player2, Board.Instance.pieces.GetLength(0)
))
        {
            player2.Color = player1.Color;
            player2.UpdateColor();
            player1.Color = 0;
            player1.UpdateColor();
        }

        selectedPiece.Clear();
    }

    private bool isAdjacent(Piece player1, Piece player2, int Width)
    {
        Debug.Log(Width);
        var xP1 = player1.transform.GetSiblingIndex() / Width;
        var yP1 = player1.transform.GetSiblingIndex() % Width;

        var xP2 = player2.transform.GetSiblingIndex() / Width;
        var yP2 = player2.transform.GetSiblingIndex() % Width;

        if (xP1 == xP2 && (yP1 - 1) == yP2)
        {
            return true;
        }

        if ((xP1 - 1) == xP2 && yP1 == yP2)
        {
            return true;
        }

        if ((xP1 + 1) == xP2 && yP1 == yP2)
        {
            return true;
        }

        if (xP1 == xP2 && (yP1 + 1) == yP2)
        {
            return true;
        }

        return false;
    }
}

