
namespace boulder_dash
{
    partial class Level_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_level = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_level
            // 
            this.lb_level.AutoSize = true;
            this.lb_level.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_level.Location = new System.Drawing.Point(0, 0);
            this.lb_level.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lb_level.Name = "lb_level";
            this.lb_level.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lb_level.Size = new System.Drawing.Size(100, 41);
            this.lb_level.TabIndex = 0;
            this.lb_level.Text = "label1";
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score.Location = new System.Drawing.Point(158, 5);
            this.score.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(126, 36);
            this.score.TabIndex = 1;
            this.score.Text = "Score: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(0, 578);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Press Q to quit";
            // 
            // Level_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(904, 614);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.score);
            this.Controls.Add(this.lb_level);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Level_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Level";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Level_form_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_level;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label label2;
    }
}