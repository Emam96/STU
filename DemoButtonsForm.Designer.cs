namespace DemoButtons
{
  partial class DemoButtonsForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtPenDataCount = new System.Windows.Forms.TextBox();
            this.lblPenDataCount = new System.Windows.Forms.Label();
            this.chkUseEncryption = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sign";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPenDataCount
            // 
            this.txtPenDataCount.Location = new System.Drawing.Point(128, 91);
            this.txtPenDataCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPenDataCount.Name = "txtPenDataCount";
            this.txtPenDataCount.ReadOnly = true;
            this.txtPenDataCount.Size = new System.Drawing.Size(63, 22);
            this.txtPenDataCount.TabIndex = 1;
            // 
            // lblPenDataCount
            // 
            this.lblPenDataCount.AutoSize = true;
            this.lblPenDataCount.Location = new System.Drawing.Point(15, 95);
            this.lblPenDataCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPenDataCount.Name = "lblPenDataCount";
            this.lblPenDataCount.Size = new System.Drawing.Size(99, 16);
            this.lblPenDataCount.TabIndex = 2;
            this.lblPenDataCount.Text = "Pen data count:";
            // 
            // chkUseEncryption
            // 
            this.chkUseEncryption.AutoSize = true;
            this.chkUseEncryption.Location = new System.Drawing.Point(99, 8);
            this.chkUseEncryption.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkUseEncryption.Name = "chkUseEncryption";
            this.chkUseEncryption.Size = new System.Drawing.Size(126, 20);
            this.chkUseEncryption.TabIndex = 3;
            this.chkUseEncryption.Text = "Use encryption?";
            this.chkUseEncryption.UseVisualStyleBackColor = true;
            // 
            // DemoButtonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(355, 122);
            this.Controls.Add(this.chkUseEncryption);
            this.Controls.Add(this.lblPenDataCount);
            this.Controls.Add(this.txtPenDataCount);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DemoButtonsForm";
            this.Text = "DemoButtons (C#)";
            this.Load += new System.EventHandler(this.DemoButtonsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TextBox txtPenDataCount;
      private System.Windows.Forms.Label lblPenDataCount;
      private System.Windows.Forms.CheckBox chkUseEncryption;
   }
}

