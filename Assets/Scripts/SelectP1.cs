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
        if (player1.Color > 1 && player1.Color != player2.Color)
        {
            player2.Color = player1.Color;
            player2.UpdateColor();
            player1.Color = 0;
            player1.UpdateColor();
        }

        selectedPiece.Clear();
    }
}
