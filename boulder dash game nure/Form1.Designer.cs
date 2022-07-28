
namespace boulder_dash
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.list_levels = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.list_records = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tb_playername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Consolas", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(973, 145);
            this.label1.TabIndex = 1;
            this.label1.Text = "BOULDER DASH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 20F);
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(528, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 53);
            this.label2.TabIndex = 2;
            this.label2.Text = "Highscore";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // list_levels
            // 
            this.list_levels.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.list_levels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list_levels.Font = new System.Drawing.Font("Consolas", 19F);
            this.list_levels.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.list_levels.FormattingEnabled = true;
            this.list_levels.ItemHeight = 45;
            this.list_levels.Location = new System.Drawing.Point(189, 371);
            this.list_levels.Name = "list_levels";
            this.list_levels.Size = new System.Drawing.Size(275, 182);
            this.list_levels.TabIndex = 4;
            this.list_levels.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_levels_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 20F);
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(189, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 53);
            this.label3.TabIndex = 5;
            this.label3.Text = "Levels:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // list_records
            // 
            this.list_records.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.list_records.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list_records.Cursor = System.Windows.Forms.Cursors.No;
            this.list_records.Font = new System.Drawing.Font("Consolas", 19F);
            this.list_records.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.list_records.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list_records.HideSelection = false;
            this.list_records.Location = new System.Drawing.Point(528, 371);
            this.list_records.MultiSelect = false;
            this.list_records.Name = "list_records";
            this.list_records.Scrollable = false;
            this.list_records.Size = new System.Drawing.Size(275, 156);
            this.list_records.TabIndex = 6;
            this.list_records.UseCompatibleStateImageBehavior = false;
            this.list_records.View = System.Windows.Forms.View.List;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 20F);
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(0, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(973, 53);
            this.label4.TabIndex = 7;
            this.label4.Text = "Enter your name:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_playername
            // 
            this.tb_playername.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tb_playername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_playername.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_playername.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tb_playername.Location = new System.Drawing.Point(0, 201);
            this.tb_playername.Name = "tb_playername";
            this.tb_playername.Size = new System.Drawing.Size(973, 45);
            this.tb_playername.TabIndex = 8;
            this.tb_playername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(973, 637);
            this.Controls.Add(this.tb_playername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.list_records);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.list_levels);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox list_levels;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView list_records;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_playername;
    }
}

