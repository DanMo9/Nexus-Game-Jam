using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DarkRoomBeforeFlashlight : MonoBehaviour
{
    public Rat rat;
    public MessageDisplay messageDisplay;
    public Darkness darkness;
    private Mirror mirror;
    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        mirror = GetComponent<Mirror>();
        mirror.onRatTeleported += () =>
        {
            if (done) return;
            if (rat.inventory.Tools.Any(x => x.type == ToolData.ToolType.Flashlight))
            {
                done = true;
                messageDisplay.SetMessage("Much less scary now that I have a flashlight. Even if it barely works...", 6);
                rat.DisableMovement();
                StartCoroutine(FadeOutDarkness());
            }
            else
            {
                rat.DisableMovement();
                messageDisplay.SetMessage("This is too scary for me. I need to go back", 3);
                StartCoroutine(SendRatBack());
            }
        };
    }

    private IEnumerator SendRatBack()
    {
        yield return new WaitForSeconds(3);
        mirror.TeleportRat(rat);
        rat.EnableMovement();
    }
    
    private IEnumerator FadeOutDarkness()
    {
        yield return darkness.FadeOut();
        rat.EnableMovement();
    }
}
