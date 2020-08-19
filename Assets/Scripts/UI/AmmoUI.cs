using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public Text label;

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="show"></param>
    public void Display(bool show)
    {
        this.label.enabled = show;
    }

    /// =========================================================
    /// <summary>
    ///
    /// </summary>
    /// <param name="current"></param>
    /// <param name="max"></param>
    public void SetAmmo(int current, int max)
    {
        this.label.text = $"{current} / {max}";
    }
}
