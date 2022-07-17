using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBoss : MonoBehaviour
{
    [SerializeField] private HealthBoss bossrHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = bossrHealth.currentHealth / 1340;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = bossrHealth.currentHealth / 1340;
    }
}
