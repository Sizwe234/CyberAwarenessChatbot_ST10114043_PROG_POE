using System;
using System.Collections.Generic;

public class TaskManager
{
    // Stores all tasks the user creates
    private List<TaskItem> tasks = new List<TaskItem>();

    /// <summary>
    /// Adds a new task with a title, description, and optional reminder date.
    /// </summary>
    public string AddTask(string title, string description, DateTime? reminder = null)
    {
        tasks.Add(new TaskItem
        {
            Title = title,
            Description = description,
            Reminder = reminder
        });

        return $" Task added: '{title}'. Reminder set for {reminder?.ToShortDateString() ?? "None"}.";
    }

    /// <summary>
    /// Updates the title and description of a task that matches the given old title.
    /// </summary>
    public bool UpdateTask(string oldTitle, string newTitle, string newDescription)
    {
        foreach (var task in tasks)
        {
            if (task.Title.Equals(oldTitle, StringComparison.OrdinalIgnoreCase))
            {
                task.Title = newTitle;
                task.Description = newDescription;
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Deletes a task by matching its title (case-insensitive).
    /// </summary>
    public bool DeleteTask(string title)
    {
        var taskToDelete = tasks.Find(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (taskToDelete != null)
        {
            tasks.Remove(taskToDelete);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns a nicely formatted list of all current tasks.
    /// </summary>
    public List<string> GetAllTasks()
    {
        List<string> output = new List<string>();
        int i = 1;

        foreach (var task in tasks)
        {
            output.Add(
                $"Task {i++}:\n" +
                $"• Title: {task.Title}\n" +
                $"• Description: {task.Description}\n" +
                $"• Reminder: {(task.Reminder.HasValue ? task.Reminder.Value.ToShortDateString() : "None")}"
            );
        }

        return output;
    }

    /// <summary>
    /// Represents each individual task with a title, description, and optional reminder.
    /// </summary>
    public class TaskItem
    {
        public required string Title { get; set; }          // Must be provided at initialization
        public required string Description { get; set; }    // Must be provided at initialization
        public DateTime? Reminder { get; set; }             // Optional reminder date
    }
}