namespace watchWall
{
    partial class frm_wallpaper
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbx_wallpaper = new System.Windows.Forms.PictureBox();
            this.tmr_wallpaper = new System.Windows.Forms.Timer(this.components);
            this.btn_run = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_wallpaper)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx_wallpaper
            // 
            this.pbx_wallpaper.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbx_wallpaper.Location = new System.Drawing.Point(0, 0);
            this.pbx_wallpaper.Name = "pbx_wallpaper";
            this.pbx_wallpaper.Size = new System.Drawing.Size(800, 402);
            this.pbx_wallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_wallpaper.TabIndex = 0;
            this.pbx_wallpaper.TabStop = false;
            // 
            // tmr_wallpaper
            // 
            this.tmr_wallpaper.Interval = 60000;
            this.tmr_wallpaper.Tick += new System.EventHandler(this.tmr_wallpaper_Tick);
            // 
            // btn_run
            // 
            this.btn_run.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_run.Location = new System.Drawing.Point(12, 412);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(776, 27);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "Çalıştır";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // frm_wallpaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.pbx_wallpaper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_wallpaper";
            this.Text = "Watch Wall";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_wallpaper_FormClosed);
            this.Load += new System.EventHandler(this.frm_wallpaper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_wallpaper)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_wallpaper;
        private System.Windows.Forms.Timer tmr_wallpaper;
        private System.Windows.Forms.Button btn_run;
    }
}

