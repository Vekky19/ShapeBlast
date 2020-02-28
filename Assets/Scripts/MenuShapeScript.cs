using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuShapeScript : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (this.tag == "Square")
            {
                SceneManager.LoadScene("Level_Square");
            }
            if (this.tag == "Circle")
            {
                SceneManager.LoadScene("Level_Circle");
            }
            if (this.tag == "Triangle")
            {
                SceneManager.LoadScene("Level_Triangle");
            }
            if (this.tag == "Pentagon")
            {
                SceneManager.LoadScene("Level_Pentagon");
            }
        }
    }
}
