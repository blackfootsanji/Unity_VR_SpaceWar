#pragma strict



function Update ()
{
	if (Input.GetKey(KeyCode.Escape) || Input.GetButtonDown("Cancel"))
	{
		Application.Quit();
	}

}