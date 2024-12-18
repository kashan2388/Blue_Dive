using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    [Header("Stage Boundaries")]
    [Tooltip("스테이지의 최상단 위치")]
    [SerializeField] private Transform topBoundary;
    [Tooltip("스테이지의 최하단 위치")]
    [SerializeField] private Transform bottomBoundary;
    [SerializeField] private Transform playerSpawnPoint;

    [Header("Stage Events")]
    [Tooltip("높이에 따라 트리거되는 이벤트 리스트")]
    [SerializeField] private List<HeightEvent> heightEvents;

    [Header("Debug Info")]
    [Tooltip("플레이어의 현재 높이 (디버깅용)")]
    [SerializeField] private float playerCurrentHeight;

    private HashSet<int> triggeredEventIndices = new HashSet<int>();
    private float previousPlayerHeight;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (Player.Instance != null && playerSpawnPoint != null)
        {
            Player.Instance.transform.position = playerSpawnPoint.position;
            previousPlayerHeight = Player.Instance.transform.position.y;
        }
    }

    private void Update()
    {
        if (Player.Instance == null) return;

        playerCurrentHeight = Player.Instance.transform.position.y;

        CheckHeightEvents(playerCurrentHeight);

        previousPlayerHeight = playerCurrentHeight;
    }

    private void CheckHeightEvents(float currentHeight)
    {
        for (int i = 0; i < heightEvents.Count; i++)
        {
            HeightEvent heightEvent = heightEvents[i];

            bool isDescending = currentHeight < previousPlayerHeight;
            bool isAscending = currentHeight > previousPlayerHeight;

            if (isDescending && currentHeight <= heightEvent.triggerHeight && !triggeredEventIndices.Contains(i))
            {
                ExecuteHeightEvent(heightEvent, true);
                triggeredEventIndices.Add(i);
            }
            else if (isAscending && currentHeight > heightEvent.triggerHeight && triggeredEventIndices.Contains(i))
            {
                ExecuteHeightEvent(heightEvent, false);
                triggeredEventIndices.Remove(i);
            }
        }
    }

    private void ExecuteHeightEvent(HeightEvent heightEvent, bool isDescending)
    {
        if (isDescending)
        {
            foreach (GameObject obj in heightEvent.activateObjects)
            {
                if (obj != null) obj.SetActive(true);
            }
            foreach (GameObject obj in heightEvent.deactivateObjects)
            {
                if (obj != null) obj.SetActive(false);
            }
            heightEvent.onDescendingEvent?.Invoke();
        }
        else
        {
            foreach (GameObject obj in heightEvent.activateObjects)
            {
                if (obj != null) obj.SetActive(false);
            }
            foreach (GameObject obj in heightEvent.deactivateObjects)
            {
                if (obj != null) obj.SetActive(true);
            }
            heightEvent.onAscendingEvent?.Invoke();
        }
    }

    public void ResetEvents()
    {
        triggeredEventIndices.Clear();
        Debug.Log("All height events have been reset.");
    }
}

[System.Serializable]
public class HeightEvent
{
    [Tooltip("이벤트가 실행되는 높이")]
    public float triggerHeight;

    [Tooltip("이 높이에서 활성화할 오브젝트들")]
    public List<GameObject> activateObjects;

    [Tooltip("이 높이에서 비활성화할 오브젝트들")]
    public List<GameObject> deactivateObjects;

    [Tooltip("내려갈 때 발생하는 이벤트")]
    public UnityEvent onDescendingEvent;

    [Tooltip("올라갈 때 발생하는 이벤트")]
    public UnityEvent onAscendingEvent;
}

