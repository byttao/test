namespace testform
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pBig = new System.Windows.Forms.PictureBox();
            this.pSmall = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSmall)).BeginInit();
            this.SuspendLayout();
            // 
            // pBig
            // 
            this.pBig.Image = ((System.Drawing.Image)(resources.GetObject("pBig.Image")));
            this.pBig.Location = new System.Drawing.Point(22, 34);
            this.pBig.Name = "pBig";
            this.pBig.Size = new System.Drawing.Size(628, 391);
            this.pBig.TabIndex = 0;
            this.pBig.TabStop = false;
            // 
            // pSmall
            // 
            this.pSmall.Image = ((System.Drawing.Image)(resources.GetObject("pSmall.Image")));
            this.pSmall.Location = new System.Drawing.Point(676, 34);
            this.pSmall.Name = "pSmall";
            this.pSmall.Size = new System.Drawing.Size(247, 473);
            this.pSmall.TabIndex = 0;
            this.pSmall.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(412, 458);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 48);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 535);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pSmall);
            this.Controls.Add(this.pBig);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pBig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSmall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBig;
        private System.Windows.Forms.PictureBox pSmall;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}