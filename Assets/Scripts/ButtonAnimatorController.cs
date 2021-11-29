using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimatorController : MonoBehaviour
{

    public Button button;
    public Animator animator;

    public void OnPointerEnter()
    {
        //animator.SetBool("isFocused", true);
        animator.SetTrigger("onFocus");
    }

    public void OnPointerExit()
    {
        //animator.SetBool("isFocused", false);
        animator.SetTrigger("offFocus");
    }

}
