using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animations : MonoBehaviour
{
    Vector3 originalPosition;
    Vector3 originalRotation;

    Vector3 basePosition;
    Vector3 baseRotation;

    [Header("CONFIG")]
    [SerializeField] bool verticalBob; 
    [SerializeField] float verticalBobIntensity;

    [SerializeField] bool rotationBob;
    [SerializeField] float rotationBobIntensity;

    void Start()
    {
        originalPosition = gameObject.transform.position;
        originalRotation = gameObject.transform.rotation.eulerAngles;

        basePosition = originalPosition;
        baseRotation = originalRotation;
    }

    void Update()
    {
        if (verticalBob) VerticalBob();
        if (rotationBob) RotationBob();
    }

    private void VerticalBob()
    {
        gameObject.transform.position = new Vector3(
            basePosition.x,
            basePosition.y + Mathf.Sin(Time.time) * verticalBobIntensity,
            basePosition.z
        );
    }

    private void RotationBob()
    {
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(
            baseRotation.x,
            baseRotation.y,
            baseRotation.z + Mathf.Sin(Time.time) * rotationBobIntensity * transform.localScale.x
        ));
    }

    public void Attack()
    {
        StartCoroutine(AttackAnimation());
    }

    private IEnumerator AttackAnimation()
    {
        float animationProgress = 0f;
        while (animationProgress < 1f)
        {
            animationProgress += Time.deltaTime / 0.5f;

            baseRotation = new Vector3(
                baseRotation.x,
                baseRotation.y,
                Mathf.Lerp(baseRotation.z, transform.localScale.x * -90f, animationProgress)
            );

            yield return null;
        }

        animationProgress = 0f;
        while (animationProgress < 1f)
        {
            animationProgress += Time.deltaTime / 0.5f;

            baseRotation = new Vector3(
                baseRotation.x,
                baseRotation.y,
                Mathf.Lerp(baseRotation.z, originalRotation.z, animationProgress)
            );

            yield return null;
        }

        baseRotation = originalRotation;
    }

    public void Heal()
    {
        StartCoroutine(HealAnimation());
    }

    private IEnumerator HealAnimation()
    {
        float animationProgress = 0f;
        while (animationProgress < 1f)
        {
            animationProgress += Time.deltaTime / 0.5f;

            basePosition = new Vector3(
                basePosition.x,
                Mathf.Lerp(basePosition.y, originalPosition.y + 1f, animationProgress),
                basePosition.z
            );

            yield return null;
        }

        animationProgress = 0f;
        while (animationProgress < 1f)
        {
            animationProgress += Time.deltaTime / 0.5f;

            basePosition = new Vector3(
                basePosition.x,
                Mathf.Lerp(basePosition.y, originalPosition.y, animationProgress),
                basePosition.z
            );

            yield return null;
        }

        basePosition = originalPosition;
    }
}
