using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PrecisionBar : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Transform pointer;
    [SerializeField] private Transform pointerLimit;
    private float pointerSpeed;
    [SerializeField, Tooltip("This value should be lower than 1")] private float brakingPercentage;

    private Vector3 targetPosition;
    private bool isMovingLeft;

    public delegate void ExecutedAction();
    public ExecutedAction executedAction;

    public static float precisionPercentage;

    void Start()
    {
        targetPosition = new Vector3(pointerLimit.position.x / brakingPercentage, pointerLimit.position.y, pointerLimit.position.z);
        isMovingLeft = false;
        pointerSpeed = UnityEngine.Random.Range(0.5f, 3f);
    }

    private void Update()
    {
        MovePointer();
        CalculateTargetPosition();
    }

    public void OnStopButton()
    {
        pointerSpeed = 0f;

        precisionPercentage = 0.1f + (pointerLimit.position.x - Mathf.Abs(pointer.position.x)) / pointerLimit.position.x;

        if (precisionPercentage > 1) // Perfect Hit
        {
            precisionPercentage = 1f;
            text.color = Color.yellow;
        }

        text.fontSize = 20f + 20f * precisionPercentage; 
        text.SetText(((int)(precisionPercentage * 100f)).ToString() + "%");

        executedAction.Invoke();
    }

    private void MovePointer()
    {
        pointer.position = Vector3.Lerp(pointer.position, targetPosition, pointerSpeed * Time.deltaTime);
    }

    // brakingPercentage changes how much of the lerp method is being used before changing direction,
    // this prevents the pointer from moving really slow when close to the targetPosition.

    // Lower values will make the pointer movement more "Linear".
    // Higher values will make the pointer brake more at the end.
    private void CalculateTargetPosition()
    {
        if (!isMovingLeft && pointer.position.x >= targetPosition.x * brakingPercentage)
        {
            targetPosition = new Vector3(-pointerLimit.position.x / brakingPercentage, targetPosition.y, targetPosition.z);
            isMovingLeft = true;
            return;
        }

        if (isMovingLeft && pointer.position.x <= targetPosition.x * brakingPercentage)
        {
            targetPosition = new Vector3(pointerLimit.position.x / brakingPercentage, targetPosition.y, targetPosition.z);
            isMovingLeft = false;
        }
    }
}
