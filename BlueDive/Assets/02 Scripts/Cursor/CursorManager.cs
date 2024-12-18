using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum CursorType
{
    PossibleCursor,
    ImpossibleCursor,
    BackCursor,
    ChargingCursor,
    ChargingEndCursor

}
public class CursorManager : MonoBehaviour
{
    private static CursorManager instance;
    public static CursorManager Instance => instance;

    [Header("Cursor Setting")]
    [SerializeField] private GameObject cursorObject;
    private Animator animator;

    [Header("Cursor Textures")]
    [SerializeField] private Texture2D possibleCursor;
    [SerializeField] private Texture2D impossibleCursor;
    [SerializeField] private Texture2D chargingCursor;
    [SerializeField] private Texture2D chargingEndCursor;

    private CursorType cursorType;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void SetCursorTexture(CursorType cursorType)
    {
        Texture2D cursorTexture = null;
        switch (cursorType)
        {
            case CursorType.PossibleCursor:
                cursorTexture = possibleCursor;
                break;
            case CursorType.ImpossibleCursor:
                cursorTexture = impossibleCursor;
                break;
            case CursorType.ChargingCursor:
                cursorTexture = chargingCursor;
                break;
            case CursorType.ChargingEndCursor:
                cursorTexture = chargingEndCursor;
                break;
        }

        if (cursorTexture != null)
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }
    }

    public void ChangeCursor(CursorType type)
    {
        if (cursorType != type)
        {
            cursorType = type;
            SetCursorTexture(cursorType);
        }
    }
}
