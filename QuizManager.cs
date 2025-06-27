using System;
using System.Collections.Generic;

public class QuizManager
{
    private List<Question> questions;
    private int current = -1;
    public int Score { get; private set; }
    public int Total => questions.Count;

    // NEW: Tracks quiz progress state
    public bool IsInProgress => current >= 0 && current < questions.Count;
    public bool IsComplete => current >= questions.Count;

    private List<string> phishingTips = new List<string>
    {
        "Always check the sender's email address carefully.",
        "Don't click suspicious links — hover to preview them.",
        "Ignore messages asking for your password or banking info urgently."
    };

    public QuizManager()
    {
        questions = new List<Question>
        {
            new Question("True or False: You should reuse passwords for convenience.", "False"),
            new Question("What does 2FA stand for?", "Two-factor authentication"),
            new Question("Is a VPN used to hide your IP address?", "Yes"),
            new Question("Should you update your software regularly?", "Yes"),
            new Question("True or False: It's safe to use public Wi-Fi without a VPN.", "False"),
            new Question("What's the first thing to do if you suspect phishing?", "Report it"),
            new Question("True or False: Antivirus software protects against all threats.", "False"),
            new Question("Is it a good idea to click unknown email links?", "No"),
            new Question("True or False: Emails from your bank will always use your name.", "False"),
            new Question("What's a sign of a scam website?", "Misspelled URLs")
        };
    }

    public string StartQuiz()
    {
        current = 0;
        Score = 0;
        return $"Quiz started!\nQuestion 1: {questions[current].Text}";
    }

    public string SubmitAnswer(string input)
    {
        if (IsComplete)
            return $"Quiz complete! You already scored {Score} out of {Total}.";

        string response;

        // Compare answer (case-insensitive)
        if (questions[current].IsCorrect(input))
        {
            Score++;
            response = "Correct!";
        }
        else
        {
            response = $"Incorrect. The correct answer was: {questions[current].Answer}";
        }

        current++;

        if (!IsComplete)
        {
            return $"{response}\n\nNext Question {current + 1}: {questions[current].Text}";
        }

        // Quiz is done – give summary feedback
        return $"{response}\n\nQuiz complete! You scored {Score} out of {Total}.\n"
             + (Score >= 7 ? "Well done! You have strong cybersecurity knowledge." : "Keep learning — cybersecurity is a journey.");
    }

    public string GetRandomPhishingTip()
    {
        Random rand = new Random();
        return "Phishing Tip: " + phishingTips[rand.Next(phishingTips.Count)];
    }

    // Inner class that defines each quiz question and its correct answer
    private class Question
    {
        public string Text;
        public string Answer;

        public Question(string text, string answer)
        {
            Text = text;
            Answer = answer;
        }

        public bool IsCorrect(string input)
        {
            return input.Trim().ToLowerInvariant() == Answer.ToLowerInvariant();
        }
    }
}