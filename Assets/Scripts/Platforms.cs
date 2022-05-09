using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public static bool isDestroyed;
    private PlatformManager _paltformMangaer;
    private void OnEnable()
    {
        _paltformMangaer = GameObject.FindObjectOfType<PlatformManager>();
        isDestroyed = false;
    }
    private void OnBecameInvisible()
    {
        //Rmoves invisble platform
        //_paltformMangaer.RecyclePlatforms(this.gameObject);
        Destroy(this.gameObject);
        isDestroyed = true;
    }
}
