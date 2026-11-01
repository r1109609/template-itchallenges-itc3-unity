
using UnityEngine;
using System.Collections;

public class SpelerController : MonoBehaviour
{
    public float snelheid = 5f;
    private float normaleSnelheid;
    private Coroutine boostCoroutine;

    public GameObject blauweGloed;

    private Animator animator;

    private void Start()
    {
        normaleSnelheid = snelheid;
        animator = GetComponentInChildren<Animator>();

        if (blauweGloed != null)
            blauweGloed.SetActive(false);
    }

    private void Update()
    {
        float beweging = Input.GetAxisRaw("Horizontal");

        transform.Translate(
            Vector3.right * beweging * snelheid * Time.deltaTime
        );

        if (animator != null)
            animator.SetFloat("Beweging", Mathf.Abs(beweging));
    }

    public void ActiveerSnelheidsboost(float boostSnelheid, float duur)
    {
        if (boostCoroutine != null)
            StopCoroutine(boostCoroutine);

        boostCoroutine = StartCoroutine(
            Snelheidsboost(boostSnelheid, duur)
        );
    }

    private IEnumerator Snelheidsboost(float boostSnelheid, float duur)
    {
        snelheid = boostSnelheid;

        if (blauweGloed != null)
            blauweGloed.SetActive(true);

        yield return new WaitForSeconds(duur);

        snelheid = normaleSnelheid;

        if (blauweGloed != null)
            blauweGloed.SetActive(false);

        boostCoroutine = null;
    }
}
