using UnityEngine;
using System.Collections;

/// <summary>
/// Stats for Units; Strength, Dexterity, Intelligence, Wisdom, Charisma
/// </summary>
public struct stats
{

}

/// <summary>
/// Unit class defines the basic data structure of a unit (Enemy, NPC, Player, etc.).
/// </summary>
public class Unit : MonoBehaviour {

    /// <summary>
    /// ID of Unit.
    /// </summary>
    int m_iID;

    /// <summary>
    /// Name of Unit.
    /// </summary>
    public string m_strName;

    /// <summary>
    /// Info or Description of Unit.
    /// </summary>
    string m_strInfo;

    /// <summary>
    /// Character reference of Unit.
    /// </summary>
    Character m_Character;

    /// <summary>
    /// Speed of Unit.
    /// </summary>
    float m_fSpeed;

    /// <summary>
    /// Class of Unit. (Knight, Summoner, Arcanist, Cleric, Archer, Brute)
    /// </summary>
    public enum Class_Type
    {
        CT_KNIGHT = 0,
        CT_SUMMONER,
        CT_ARCANIST,
        CT_CLERIC,
        CT_ARCHER,
        CT_BRUTE
    }

    /// <summary>
    /// Class Type of Unit.
    /// </summary>
    Class_Type m_CT_ClassTYPE;

    /// <summary>
    /// Current stats of Unit.
    /// </summary>
    public stats m_Stats;

    /// <summary>
    /// Current weapon of Unit.
    /// </summary>
    Weapon m_Weapon;

    /// <summary>
    /// Current health of Unit.
    /// </summary>
    public int m_iHealth;

    /// <summary>
    /// Max Health of Unit.
    /// </summary>
    int m_iMaxHealth;

    /// <summary>
    /// Current mana of Unit.
    /// </summary>
    public int m_iMana;

    /// <summary>
    /// Max Mana of Unit;
    /// </summary>
    int m_iMaxMana;

    /// <summary>
    /// If Unit is currently moving.
    /// </summary>
    bool m_bIsMoving = false;

    /// <summary>
    /// Current target waypoint (Target Destination) of Unit;
    /// </summary>
    private Vector3 m_vec3Waypoint;

    /// <summary>
    /// Moves the unit upwards by a definable number of tile spaces. Default is 1 tile space.
    /// </summary>
    /// <param name="numOfTimes">Number of times to move by. Default is 1.</param>
    void GoUp(int numOfTimes = 1)
    {
        m_Character.m_UpAnimation.Play();
        m_vec3Waypoint.Set(0, PlayerPrefs.GetInt("TileSize") * numOfTimes, 0);
        m_bIsMoving = true;
    }

    /// <summary>
    /// Moves the unit downwards by a definable number of tile spaces. Default is 1 tile space.
    /// </summary>
    /// <param name="numOfTimes">Number of times to move by. Default is 1.</param>
    void GoDown(int numOfTimes = 1)
    {
        m_Character.m_DownAnimation.Play();
        m_vec3Waypoint.Set(0, -PlayerPrefs.GetInt("TileSize") * numOfTimes, 0);
        m_bIsMoving = true;
    }

    /// <summary>
    /// Moves the unit towards the left by a definable number of tile spaces. Default is 1 tile space.
    /// </summary>
    /// <param name="numOfTimes">Number of times to move by. Default is 1.</param>
    void GoLeft(int numOfTimes = 1)
    {
        m_Character.m_LeftAnimation.Play();
        m_vec3Waypoint.Set(-PlayerPrefs.GetInt("TileSize") * numOfTimes, 0, 0);
        m_bIsMoving = true;
    }

    /// <summary>
    /// Moves the unit towards the right by a definable number of tile spaces. Default is 1 tile space.
    /// </summary>
    /// <param name="numOfTimes">Number of times to move by. Default is 1.</param>
    void GoRight(int numOfTimes = 1)
    {
        m_Character.m_RightAnimation.Play();
        m_vec3Waypoint.Set(PlayerPrefs.GetInt("TileSize") * numOfTimes, 0, 0);
        m_bIsMoving = true;
    }

    void FixedUpdate()
    {
        if(m_bIsMoving == true)
        {
            if (m_vec3Waypoint - this.gameObject.transform.position != Vector3.zero)
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, m_vec3Waypoint, m_vec3Waypoint.magnitude * m_fSpeed * Time.deltaTime);
            else
            {
                m_bIsMoving = false;
                m_Character.StopAllAnimation();
            }
        }
    }
}
