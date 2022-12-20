using UnityEngine;

public class Core : MonoBehaviour
{
    public Color currentColor = Color.gray;
    private Material coreMaterial = null;

    public void SetColor(Color targetColor)
    {
        currentColor = targetColor;
        coreMaterial.SetColor("", currentColor);
    }
}
