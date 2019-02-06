namespace restClient
{
    partial class ServicesForm
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
            this.Bill = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.productsButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Bill
            // 
            this.Bill.Location = new System.Drawing.Point(49, 108);
            this.Bill.Name = "Bill";
            this.Bill.Size = new System.Drawing.Size(75, 23);
            this.Bill.TabIndex = 0;
            this.Bill.Text = "bill";
            this.Bill.UseVisualStyleBackColor = true;
            this.Bill.Click += new System.EventHandler(this.Bill_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(158, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "client";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(274, 108);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "plan";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // productsButton
            // 
            this.productsButton.Location = new System.Drawing.Point(399, 108);
            this.productsButton.Name = "productsButton";
            this.productsButton.Size = new System.Drawing.Size(75, 23);
            this.productsButton.TabIndex = 3;
            this.productsButton.Text = "products";
            this.productsButton.UseVisualStyleBackColor = true;
            this.productsButton.Click += new System.EventHandler(this.productsButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(520, 108);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "user";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(274, 188);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "quitter";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // ServicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 270);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.productsButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Bill);
            this.Name = "ServicesForm";
            this.Text = "ServicesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Bill;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button productsButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}