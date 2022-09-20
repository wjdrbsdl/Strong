using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerHerbLand : MonoBehaviour
{
    [SerializeField] private HerbLand m_herbLandObj;

    private void Start()
    {
        MakeHerbLand();
    }

    public void MakeHerbLand()
    {
       HerbLand insHerb = Instantiate(m_herbLandObj, new Vector3(10,10,10), Quaternion.identity);
        insHerb.DetermineGrade(HerbGrade.Legend);
    }
}
