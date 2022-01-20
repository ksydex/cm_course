using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Models;

public class ResultsManager
{
    public static ResultsManager instance = new ResultsManager();
    [CanBeNull] public static UserResult current;

    public readonly List<UserResult> results = new List<UserResult>();

    public string resultsInText => results.Aggregate("", (acc, x) => acc + $"{x.Id}. {x.UserName} - {x.ResultText} \n");

    public void Add(UserResult result)
    {
        result.Id = results.Count + 1;
        results.Add(result);
        current = result;
    }
}