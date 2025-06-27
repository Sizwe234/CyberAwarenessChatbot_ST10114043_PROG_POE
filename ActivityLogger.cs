using System;
using System.Collections.Generic;

public class ActivityLogger
{
    // Stores user actions with timestamps
    private List<string> log = new List<string>();

    // Adds a new action to the log
    public void Log(string action)
    {
        string timestamp = DateTime.Now.ToString("HH:mm:ss");
        log.Add($"{timestamp} - {action}");

        // Keep log limited to the 10 most recent actions
        if (log.Count > 10)
        {
            log.RemoveAt(0);
        }
    }

    // Returns a copy of the log to display to the user
    public List<string> GetRecentActivity()
    {
        return new List<string>(log);
    }
}