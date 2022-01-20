using System.Collections.Generic;
using JetBrains.Annotations;
using Models;

public class ResultsManager
{
    public static ResultsManager instance = new ResultsManager();
    [CanBeNull] public static UserResult current;

    public readonly List<UserResult> results = new List<UserResult>();

    public void Add(UserResult result)
    {
        result.Id = results.Count;
        results.Add(result);
        current = result;
    }
}