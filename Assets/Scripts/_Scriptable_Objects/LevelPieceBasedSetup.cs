using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "LevelManager/Level", order = 1)]
public class LevelPieceBasedSetup : ScriptableObject
{
    public ArtManager.ArtType artType;
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;
    public int piecesStartnumber = 3;
    public int piecesnumber = 5;
    public int piecesEndnumber = 1;
}
