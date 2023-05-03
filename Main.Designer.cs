namespace dam_battleship;

partial class Main
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
        pictureBox1 = new PictureBox();
        BtnExit = new Button();
        BtnBegin = new Button();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(12, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(500, 150);
        pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // BtnExit
        // 
        BtnExit.Anchor = AnchorStyles.None;
        BtnExit.FlatAppearance.BorderSize = 0;
        BtnExit.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        BtnExit.Location = new Point(200, 225);
        BtnExit.Name = "BtnExit";
        BtnExit.Size = new Size(125, 35);
        BtnExit.TabIndex = 2;
        BtnExit.Text = "Exit";
        BtnExit.UseVisualStyleBackColor = true;
        BtnExit.Click += BtnExit_Click;
        // 
        // BtnBegin
        // 
        BtnBegin.Anchor = AnchorStyles.None;
        BtnBegin.FlatAppearance.BorderSize = 0;
        BtnBegin.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        BtnBegin.Location = new Point(200, 175);
        BtnBegin.Name = "BtnBegin";
        BtnBegin.Size = new Size(125, 35);
        BtnBegin.TabIndex = 1;
        BtnBegin.Text = "New game";
        BtnBegin.UseVisualStyleBackColor = true;
        BtnBegin.Click += BtnBegin_Click;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(29, 29, 29);
        ClientSize = new Size(524, 286);
        Controls.Add(BtnExit);
        Controls.Add(BtnBegin);
        Controls.Add(pictureBox1);
        ForeColor = Color.FromArgb(69, 90, 99);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Main";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Main Menu - Battleship";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private Button BtnExit;
    private Button BtnBegin;
}
