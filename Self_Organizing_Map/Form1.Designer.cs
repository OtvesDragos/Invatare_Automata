namespace Self_Organizing_Map
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTrain = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelCountEpochs = new System.Windows.Forms.Label();
            this.labelVecinatate = new System.Windows.Forms.Label();
            this.labelLearning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(626, 640);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(94, 29);
            this.btnTrain.TabIndex = 0;
            this.btnTrain.Text = "Train!";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(388, 644);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(98, 20);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "Time Elapsed";
            // 
            // labelCountEpochs
            // 
            this.labelCountEpochs.AutoSize = true;
            this.labelCountEpochs.Location = new System.Drawing.Point(12, 636);
            this.labelCountEpochs.Name = "labelCountEpochs";
            this.labelCountEpochs.Size = new System.Drawing.Size(50, 20);
            this.labelCountEpochs.TabIndex = 2;
            this.labelCountEpochs.Text = "Epoca";
            // 
            // labelVecinatate
            // 
            this.labelVecinatate.AutoSize = true;
            this.labelVecinatate.Location = new System.Drawing.Point(12, 674);
            this.labelVecinatate.Name = "labelVecinatate";
            this.labelVecinatate.Size = new System.Drawing.Size(78, 20);
            this.labelVecinatate.TabIndex = 3;
            this.labelVecinatate.Text = "Vecinatate";
            // 
            // labelLearning
            // 
            this.labelLearning.AutoSize = true;
            this.labelLearning.Location = new System.Drawing.Point(12, 606);
            this.labelLearning.Name = "labelLearning";
            this.labelLearning.Size = new System.Drawing.Size(154, 20);
            this.labelLearning.TabIndex = 4;
            this.labelLearning.Text = "Coeficient de invatare";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 703);
            this.Controls.Add(this.labelLearning);
            this.Controls.Add(this.labelVecinatate);
            this.Controls.Add(this.labelCountEpochs);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.btnTrain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnTrain;
        private Label labelTime;
        private Label labelCountEpochs;
        private Label labelVecinatate;
        private Label labelLearning;
    }
}