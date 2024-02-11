using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    public Image BackGround;
    public Button skipDialogue;
    public Animator animator;
    private Sprite newBackGround;

    public void SetNewBackGround(Sprite backGround)
    {
        newBackGround = backGround;
        skipDialogue.interactable = false;
        animator.SetTrigger("SetNewBG");
    }

    //Use by the animator to change the background when alphaGroup is set to 0 
    public void ChangeBackGround()
    {
        BackGround.sprite = newBackGround;
    }

    public float GetAnimationTime()
    {
        return 2f;
    }

    //Use by the animator to enable skip button interactivity at the end of the animation
    public void EnableSkipDialogueButton()
    {
        skipDialogue.interactable = true;
    }
}
