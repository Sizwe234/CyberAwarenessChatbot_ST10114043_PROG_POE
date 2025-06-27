namespace CyberAwarenessChatbot
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chatOutput = new System.Windows.Forms.RichTextBox();
            this.userInput = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.taskButton = new System.Windows.Forms.Button();
            this.quizButton = new System.Windows.Forms.Button();
            this.logButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatOutput
            // 
            this.chatOutput.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chatOutput.Location = new System.Drawing.Point(0, 0);
            this.chatOutput.Name = "chatOutput";
            this.chatOutput.ReadOnly = true;
            this.chatOutput.Size = new System.Drawing.Size(799, 233);
            this.chatOutput.TabIndex = 0;
            this.chatOutput.Text = "";
            // 
            // userInput
            // 
            this.userInput.Location = new System.Drawing.Point(2, 233);
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(349, 23);
            this.userInput.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(0, 273);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // taskButton
            // 
            this.taskButton.Location = new System.Drawing.Point(81, 273);
            this.taskButton.Name = "taskButton";
            this.taskButton.Size = new System.Drawing.Size(75, 23);
            this.taskButton.TabIndex = 3;
            this.taskButton.Text = "View Tasks";
            this.taskButton.UseVisualStyleBackColor = true;
            this.taskButton.Click += new System.EventHandler(this.taskButton_Click);
            // 
            // quizButton
            // 
            this.quizButton.Location = new System.Drawing.Point(162, 273);
            this.quizButton.Name = "quizButton";
            this.quizButton.Size = new System.Drawing.Size(75, 23);
            this.quizButton.TabIndex = 4;
            this.quizButton.Text = "Start Quiz";
            this.quizButton.UseVisualStyleBackColor = true;
            this.quizButton.Click += new System.EventHandler(this.quizButton_Click); // ✅ Fixed
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(254, 273);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(75, 23);
            this.logButton.TabIndex = 5;
            this.logButton.Text = "Show Log";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.quizButton);
            this.Controls.Add(this.taskButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.userInput);
            this.Controls.Add(this.chatOutput);
            this.Name = "MainForm";
            this.Text = "Cy-Bot Chat Console";
            this.ResumeLayout(false);
            this.PerformLayout();
        }



        private System.Windows.Forms.RichTextBox chatOutput;
        private System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button taskButton;
        private System.Windows.Forms.Button quizButton;
        private System.Windows.Forms.Button logButton;
    }
}