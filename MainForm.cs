using System;
using System.Windows.Forms;

namespace CyberAwarenessChatbot
{
    public partial class MainForm : Form
    {
        private CyberBot bot = new CyberBot();

        public MainForm()
        {
            InitializeComponent();

            // Startup message when form loads
            chatOutput.Text = " Welcome to Cy-Bot — your cybersecurity co-pilot!\n";
            chatOutput.AppendText("Try typing: 'start quiz', 'add task', 'update task', 'privacy', or 'help'.\n\n");

            // Set focus to the input box
            userInput.Focus();
        }

        //  Called when Send button is clicked
        private void sendButton_Click(object sender, EventArgs e) => ProcessInput();

        //  Called when Enter is pressed in input box
        private void userInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessInput();
                e.SuppressKeyPress = true;
            }
        }

        //  Processes chatbot input/output
        private void ProcessInput()
        {
            string input = userInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input)) return;

            // Show user input
            chatOutput.AppendText($" You: {input}\n");

            // Get Cy-Bot reply
            string reply = bot.RespondToInput(input);

            // Display Cy-Bot response
            chatOutput.AppendText($" Cy-Bot: {reply}\n\n");

            userInput.Clear();
            userInput.Focus();
        }

        //  View tasks
        private void taskButton_Click(object sender, EventArgs e)
        {
            var tasks = bot.ListTasks();

            if (tasks.Count == 0)
                chatOutput.AppendText(" Cy-Bot: You currently have no tasks.\n\n");
            else
            {
                chatOutput.AppendText(" Your Current Tasks:\n\n");
                foreach (var task in tasks)
                    chatOutput.AppendText(task + "\n\n");
            }
        }

        //  Start quiz
        private void quizButton_Click(object sender, EventArgs e)
        {
            string intro = bot.RespondToInput("start quiz");
            chatOutput.AppendText($" Cy-Bot: {intro}\n\n");
        }

        //  Show activity log
        private void logButton_Click(object sender, EventArgs e)
        {
            var logs = bot.GetActivityLog();

            if (logs.Count == 0)
                chatOutput.AppendText(" Cy-Bot: You have no activity logged yet.\n\n");
            else
            {
                chatOutput.AppendText(" Recent Activity:\n\n");
                foreach (var log in logs)
                    chatOutput.AppendText("• " + log + "\n");
                chatOutput.AppendText("\n");
            }
        }
    }
}
