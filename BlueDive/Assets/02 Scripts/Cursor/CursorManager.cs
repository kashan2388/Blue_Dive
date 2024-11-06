using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CursorType
{
    PossibleCursor,
    ImpossibleCursor,
    ChargingCursor,
    ChargingEndCursor,

}
public class CursorManager : MonoBehaviour
{
    private static CursorManager instance;
}
