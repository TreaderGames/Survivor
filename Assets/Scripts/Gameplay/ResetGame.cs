using System.Collections.Generic;

public class ResetGame : Singleton<ResetGame>
{
    List<IReset> resetAbles = new List<IReset>();

    #region Untiy
    private void Start()
    {
        PlayerHealthController.Instance.AddListener(HandlePlayerHealth);
    }
    #endregion    

    #region Public

    public void AddResetableListener(IReset reset)
    {
        resetAbles.Add(reset);
    }

#endregion

    #region Private
    private void ResetMatch()
    {
        foreach (var item in resetAbles)
        {
            item.DoReset();
        }
    }
    #endregion

    #region Callback
    private void HandlePlayerHealth(int health)
    {
        if (health == 0)
        {
            ResetMatch();
        }
    }
    #endregion
}
