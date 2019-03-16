using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUpdater : MonoBehaviour {

    [SerializeField]
    public Image foregroundImage;
    public Health health;

    private float updateSpeedSeconds { get; set; } = .5f;
    
    void Start() {
        health.OnHealthChangeEvent += HandleHealthChanged;
    }

    private void HandleHealthChanged(float currentHealth) {
        StartCoroutine(ChangeToPercent(currentHealth / health.maxHealth));
    }

    private IEnumerator ChangeToPercent(float percent) {
        float preChangePercent = foregroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds) {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePercent, percent, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = percent;
    }

    private void LateUpdate() {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
