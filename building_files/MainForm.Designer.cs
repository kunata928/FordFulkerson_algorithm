namespace FordFulkerson_algorithm
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.drawSheet = new System.Windows.Forms.PictureBox();
            this.newVertexButton = new System.Windows.Forms.Button();
            this.newEdgeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteAllButton = new System.Windows.Forms.Button();
            this.FordFulkersonRunButton = new System.Windows.Forms.Button();
            this.matrixBox = new System.Windows.Forms.RichTextBox();
            this.showAlgorithm = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.drawSheet)).BeginInit();
            this.SuspendLayout();
            // 
            // drawSheet
            // 
            this.drawSheet.Location = new System.Drawing.Point(347, 10);
            this.drawSheet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.drawSheet.Name = "drawSheet";
            this.drawSheet.Size = new System.Drawing.Size(588, 423);
            this.drawSheet.TabIndex = 0;
            this.drawSheet.TabStop = false;
            this.drawSheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawSheet_MouseClick);
            // 
            // newVertexButton
            // 
            this.newVertexButton.Location = new System.Drawing.Point(11, 265);
            this.newVertexButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newVertexButton.Name = "newVertexButton";
            this.newVertexButton.Size = new System.Drawing.Size(161, 26);
            this.newVertexButton.TabIndex = 2;
            this.newVertexButton.Text = "Добавить вершину";
            this.newVertexButton.UseVisualStyleBackColor = true;
            this.newVertexButton.Click += new System.EventHandler(this.newVertexButton_Click);
            // 
            // newEdgeButton
            // 
            this.newEdgeButton.Location = new System.Drawing.Point(176, 266);
            this.newEdgeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newEdgeButton.Name = "newEdgeButton";
            this.newEdgeButton.Size = new System.Drawing.Size(161, 25);
            this.newEdgeButton.TabIndex = 3;
            this.newEdgeButton.Text = "Провести дугу";
            this.newEdgeButton.UseVisualStyleBackColor = true;
            this.newEdgeButton.Click += new System.EventHandler(this.newEdgeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(11, 321);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(161, 21);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Удалить элемент";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deleteAllButton
            // 
            this.deleteAllButton.Location = new System.Drawing.Point(176, 321);
            this.deleteAllButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deleteAllButton.Name = "deleteAllButton";
            this.deleteAllButton.Size = new System.Drawing.Size(161, 21);
            this.deleteAllButton.TabIndex = 5;
            this.deleteAllButton.Text = "Удалить всё";
            this.deleteAllButton.UseVisualStyleBackColor = true;
            this.deleteAllButton.Click += new System.EventHandler(this.deleteAllButton_Click);
            // 
            // FordFulkersonRunButton
            // 
            this.FordFulkersonRunButton.Location = new System.Drawing.Point(11, 295);
            this.FordFulkersonRunButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FordFulkersonRunButton.Name = "FordFulkersonRunButton";
            this.FordFulkersonRunButton.Size = new System.Drawing.Size(161, 22);
            this.FordFulkersonRunButton.TabIndex = 7;
            this.FordFulkersonRunButton.Text = "Результат алгоритма Форда-Фалкерсона";
            this.FordFulkersonRunButton.UseVisualStyleBackColor = true;
            this.FordFulkersonRunButton.Click += new System.EventHandler(this.FordFulkersonRunButton_Click);
            // 
            // matrixBox
            // 
            this.matrixBox.Location = new System.Drawing.Point(11, 10);
            this.matrixBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.matrixBox.Name = "matrixBox";
            this.matrixBox.Size = new System.Drawing.Size(332, 251);
            this.matrixBox.TabIndex = 10;
            this.matrixBox.Text = "";
            // 
            // showAlgorithm
            // 
            this.showAlgorithm.Enabled = false;
            this.showAlgorithm.Location = new System.Drawing.Point(176, 295);
            this.showAlgorithm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.showAlgorithm.Name = "showAlgorithm";
            this.showAlgorithm.Size = new System.Drawing.Size(161, 22);
            this.showAlgorithm.TabIndex = 11;
            this.showAlgorithm.Text = "Визуализировать алгоритм";
            this.showAlgorithm.UseVisualStyleBackColor = true;
            this.showAlgorithm.Click += new System.EventHandler(this.showAlgorithm_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 445);
            this.Controls.Add(this.showAlgorithm);
            this.Controls.Add(this.matrixBox);
            this.Controls.Add(this.FordFulkersonRunButton);
            this.Controls.Add(this.deleteAllButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.newEdgeButton);
            this.Controls.Add(this.newVertexButton);
            this.Controls.Add(this.drawSheet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Алгоритм Форда-Фалкерсона";
            ((System.ComponentModel.ISupportInitialize)(this.drawSheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawSheet;
        private System.Windows.Forms.Button newVertexButton;
        private System.Windows.Forms.Button newEdgeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deleteAllButton;
        private System.Windows.Forms.Button FordFulkersonRunButton;
        private System.Windows.Forms.RichTextBox matrixBox;
        private System.Windows.Forms.Button showAlgorithm;
        private System.Windows.Forms.Timer Timer;
    }
}

