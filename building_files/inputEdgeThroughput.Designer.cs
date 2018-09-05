namespace FordFulkerson_algorithm
{
    partial class inputEdgeThroughput
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
            this.doneButton = new System.Windows.Forms.Button();
            this.valBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(12, 46);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(272, 39);
            this.doneButton.TabIndex = 0;
            this.doneButton.Text = "Готово";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // valBox
            // 
            this.valBox.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.valBox.Location = new System.Drawing.Point(213, 6);
            this.valBox.Name = "valBox";
            this.valBox.Size = new System.Drawing.Size(71, 34);
            this.valBox.TabIndex = 1;
            this.valBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Мощность дуги: ";
            // 
            // inputEdgeThroughput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 97);
            this.Controls.Add(this.valBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.doneButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "inputEdgeThroughput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.TextBox valBox;
        private System.Windows.Forms.Label label1;
    }
}