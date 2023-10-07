using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Material> materials;
    public List<Color> enemiesColors;
    public List<Color> groundColors;
    public List<GameObject> levels;
    public Transform target;

    void Start()
    {
        ChangeColors();

        for (int i = 0; i < enemiesColors.Count; i++)
        {
            var colorEnemye = Random.Range(0, enemiesColors.Count - 1);
            var colorGround = Random.Range(0, groundColors.Count - 1);

            materials[0].SetColor("_Color", enemiesColors[colorEnemye]);
            materials[1].SetColor("_Color", groundColors[colorGround]);
        }

        int randomLevel = Random.Range(0, levels.Count);

        Instantiate(levels[randomLevel], target.transform.position, Quaternion.identity, target.transform);

        Debug.Log("Level: " + randomLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeColors()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].SetColor("_Color", Color.blue);
        }
    }
}
