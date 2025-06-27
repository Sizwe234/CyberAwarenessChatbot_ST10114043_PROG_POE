using System;
using System.Collections.Generic;
using System.Linq;

public class CyberBot
{
    private string userName = "User";
    private string? interestTopic = null;

    private ActivityLogger logger;
    private TaskManager taskManager;
    private QuizManager quizManager;

    public CyberBot()
    {
        logger = new ActivityLogger();
        taskManager = new TaskManager();
        quizManager = new QuizManager();
    }

    public void SetUserName(string name)
    {
        userName = string.IsNullOrWhiteSpace(name) ? "User" : name;
    }

    public string RespondToInput(string input)
    {
        string lower = input.ToLowerInvariant().Trim();

        //  NLP-style QUIZ TRIGGERS 
        string[] quizTriggers = { "quiz", "test", "take quiz", "start challenge", "cyber quiz" };
        if (quizTriggers.Any(phrase => lower.Contains(phrase)))
        {
            logger.Log("Quiz started.");
            return quizManager.StartQuiz();
        }

        //  NLP-style TASK ADDITION 
        if (lower.Contains("add task") || lower.Contains("new reminder") || lower.Contains("note this down"))
        {
            logger.Log("User started task creation.");
            return "Please enter the task like this:\nTitle - Description - DaysUntilReminder";
        }

        if (lower.Split('-').Length == 3)
        {
            var parts = lower.Split('-');
            string title = ToTitleCase(parts[0].Trim());
            string description = ToTitleCase(parts[1].Trim());
            bool valid = int.TryParse(parts[2].Trim(), out int days);

            if (!valid) return " Please provide the days as a number, like '3'.";

            string confirm = AddTask(title, description, days);
            logger.Log($"Task added: {title}");
            return confirm + "\nYou can view tasks anytime by saying 'show my tasks'.";
        }

        // NLP-style QUIZ ANSWERS
        if (!quizManager.IsComplete && quizManager.IsInProgress)
        {
            return quizManager.SubmitAnswer(lower);
        }

        //  NLP-style UPDATE TASK 
        if (lower.StartsWith("update -"))
        {
            var parts = lower.Split('-');
            if (parts.Length == 4)
            {
                string oldTitle = parts[1].Trim();
                string newTitle = parts[2].Trim();
                string newDesc = parts[3].Trim();

                bool updated = taskManager.UpdateTask(oldTitle, newTitle, newDesc);
                if (updated)
                {
                    logger.Log($"Task '{oldTitle}' updated.");
                    return $"Updated: '{oldTitle}' → '{newTitle}'";
                }
                return $" Task '{oldTitle}' not found.";
            }
            return " Format to update: update - oldTitle - newTitle - newDescription";
        }

        //  DELETE TASK 
        if (lower.StartsWith("delete task") || lower.StartsWith("remove"))
        {
            string[] tokens = lower.Split(' ', 3);
            if (tokens.Length >= 3)
            {
                string titleToDelete = tokens[2].Trim();
                bool deleted = taskManager.DeleteTask(titleToDelete);
                if (deleted)
                {
                    logger.Log($"Deleted task: {titleToDelete}");
                    return $"Task '{titleToDelete}' removed.";
                }
                return $" I couldn’t find a task called '{titleToDelete}'.";
            }
            return "Please say: delete task taskName";
        }

        //  NLP-style ACTIVITY LOG 
        if (lower.Contains("log") || lower.Contains("activity"))
        {
            var logs = logger.GetRecentActivity();
            return logs.Count > 0 ? string.Join("\n", logs) : "No activities logged yet.";
        }

        // NLP-style SHOW TASKS
        if (lower.Contains("show tasks") || lower.Contains("view tasks") || lower.Contains("what’s on my list"))
        {
            var taskList = taskManager.GetAllTasks();
            return taskList.Count > 0 ? string.Join("\n\n", taskList) : "🗒️ You don’t have any tasks saved yet.";
        }

        //  SUGGESTIONS / REMINDERS
        if (lower.Contains("remind") || lower.Contains("what can i do") || lower.Contains("suggest") || lower.Contains("i'm bored"))
        {
            return " Here are some ideas:\n• Take the quiz\n• Add a security task\n• Ask for a cyber tip\n• Type 'help' for more options";
        }

        //  NLP-style HELP / COMMANDS 
        if (lower.Contains("help") || lower.Contains("commands") || lower.Contains("what can you do"))
        {
            return " I can help you with:\n• Adding or updating tasks\n• Cybersecurity tips\n• A 10-question awareness quiz\n• Tracking your activity\nSay things like: 'start quiz', 'add task', 'show my tasks', or 'privacy tips'.";
        }

        //  SECURITY / PRIVACY QUESTIONS 
        if (lower.Contains("phishing") || lower.Contains("scam"))
            return quizManager.GetRandomPhishingTip();

        if (lower.Contains("password"))
            return " Use a password manager, create long passwords, and never reuse them!";

        if (lower.Contains("privacy") || lower.Contains("2fa"))
            return " Protect your privacy by enabling 2FA, adjusting your app permissions, and reviewing your social settings regularly.";

        //  PART 1 INTEGRATION POINT (console switch) 
        if (lower.Contains("switch to console"))
        {
            logger.Log("User requested console mode.");
            RunConsoleMode(); // Simulates calling Part 1
            return " Switching to console mode... (not implemented in GUI)";
        }

        return " I didn't understand that. Type 'help' for suggestions or try rephrasing.";
    }

    public List<string> GetActivityLog() => logger.GetRecentActivity();

    public string AddTask(string title, string description, int days)
    {
        return taskManager.AddTask(title, description, DateTime.Now.AddDays(days));
    }

    public List<string> ListTasks() => taskManager.GetAllTasks();

    public string AnswerQuiz(string answer)
    {
        string reply = quizManager.SubmitAnswer(answer);
        if (quizManager.IsComplete)
        {
            logger.Log($"Quiz finished. Score: {quizManager.Score}/{quizManager.Total}");
        }
        return reply;
    }

    private void RunConsoleMode()
    {
        // Simulated placeholder — optionally call Part 1 console logic here
        // ConsoleApp.Main(); (if that class is available)
    }

    private string ToTitleCase(string input) =>
        System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
}
