using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayParticlesOnSceneLoad : MonoBehaviour
{
    ParticleSystem particleSystem;
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Play();
    }
}
