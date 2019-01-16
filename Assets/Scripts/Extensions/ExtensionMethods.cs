using UnityEngine;

public static class ExtensionMethods
{
    public static bool ContainsParameter(this Animator animator, string parameterName)
    {
        bool result = false;

        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name == parameterName)
            {
                result = true;
            }
        }

        return result;
    }
}