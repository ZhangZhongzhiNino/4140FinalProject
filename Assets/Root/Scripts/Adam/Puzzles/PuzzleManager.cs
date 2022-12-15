using System;
using System.Collections;
using System.Collections.Generic;
using Root.Scripts.Adam.Puzzles;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<GameObject> _pieces;
    private PieceChecker _pieceChecker;
    private bool _puzzleSolved = true;
    [SerializeField] private ParticleSystem ps;

    private void FixedUpdate()
    {
        _puzzleSolved = true;
        foreach (GameObject piece in _pieces)
        {
            _pieceChecker = piece.gameObject.GetComponent<PieceChecker>();
            
            if (_pieceChecker.PuzzleStateCheck() == false) _puzzleSolved = false;
        }

        if (_puzzleSolved)
        {
            Debug.Log("Puzzle Solved");
            ps.gameObject.SetActive(true);
        }
    }
}
