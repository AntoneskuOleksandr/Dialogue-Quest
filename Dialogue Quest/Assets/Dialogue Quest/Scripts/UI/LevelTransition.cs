using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [Tooltip("Delay before transitioning to another scene. Corresponds to the FadeIn animation time.")]
    [SerializeField] private float transitionDelay = 1f;

    public void StartChangeScene(int scene)
    {
        gameObject.SetActive(true);
        StartCoroutine(ChangeScene(scene));
    }

    private IEnumerator ChangeScene(int scene)
    {
        yield return new WaitForSeconds(transitionDelay);
        SceneManager.LoadScene(scene);
    }
}
