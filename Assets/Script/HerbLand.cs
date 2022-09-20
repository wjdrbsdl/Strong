using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum HerbGrade
{
    Nomal, Rare, Legend
}
public class HerbLand : MonoBehaviour
{
   private HerbGrade m_herbGrade = HerbGrade.Nomal;

   public void DetermineGrade(HerbGrade _grade)
    {
        m_herbGrade = _grade;
        Debug.Log("이 약초밭의 품질은" + _grade);
    }
}
