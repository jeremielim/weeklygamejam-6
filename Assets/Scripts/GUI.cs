using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public Text lureText;
    public NavMeshPatroller nmp;

    void Update()
    {
        lureText.text = "Lures: " + nmp.LureCount();
    }
}
