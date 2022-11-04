using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL : MonoBehaviour
{
    public void UrlOpen(string url)
    {
        Application.OpenURL(url);
    }
}
