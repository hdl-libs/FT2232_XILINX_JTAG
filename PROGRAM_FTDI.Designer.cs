
namespace WindowsFormsApp1
{
    partial class PROGRAM_FTDI
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PROGRAM_FTDI));
            this.btn_write = new System.Windows.Forms.Button();
            this.tb_serial = new System.Windows.Forms.TextBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.tb_manufacturer = new System.Windows.Forms.TextBox();
            this.tb_product = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_device = new System.Windows.Forms.ComboBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.tb_vendor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_board = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_write
            // 
            resources.ApplyResources(this.btn_write, "btn_write");
            this.btn_write.Name = "btn_write";
            this.btn_write.UseVisualStyleBackColor = true;
            this.btn_write.Click += new System.EventHandler(this.Btn_Write_Click);
            // 
            // tb_serial
            // 
            resources.ApplyResources(this.tb_serial, "tb_serial");
            this.tb_serial.Name = "tb_serial";
            // 
            // btn_close
            // 
            resources.ApplyResources(this.btn_close, "btn_close");
            this.btn_close.Name = "btn_close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.Btn_Close_click);
            // 
            // tb_log
            // 
            resources.ApplyResources(this.tb_log, "tb_log");
            this.tb_log.Name = "tb_log";
            // 
            // btn_open
            // 
            resources.ApplyResources(this.btn_open, "btn_open");
            this.btn_open.Name = "btn_open";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.Btn_Open_click);
            // 
            // tb_manufacturer
            // 
            resources.ApplyResources(this.tb_manufacturer, "tb_manufacturer");
            this.tb_manufacturer.Name = "tb_manufacturer";
            // 
            // tb_product
            // 
            resources.ApplyResources(this.tb_product, "tb_product");
            this.tb_product.Name = "tb_product";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cbx_device
            // 
            resources.ApplyResources(this.cbx_device, "cbx_device");
            this.cbx_device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_device.FormattingEnabled = true;
            this.cbx_device.Items.AddRange(new object[] {
            resources.GetString("cbx_device.Items")});
            this.cbx_device.Name = "cbx_device";
            // 
            // btn_refresh
            // 
            resources.ApplyResources(this.btn_refresh, "btn_refresh");
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.Btn_Refresh_click);
            // 
            // tb_vendor
            // 
            resources.ApplyResources(this.tb_vendor, "tb_vendor");
            this.tb_vendor.Name = "tb_vendor";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tb_board
            // 
            resources.ApplyResources(this.tb_board, "tb_board");
            this.tb_board.Name = "tb_board";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // PROGRAM_FTDI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbx_device);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_product);
            this.Controls.Add(this.tb_board);
            this.Controls.Add(this.tb_vendor);
            this.Controls.Add(this.tb_manufacturer);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.tb_serial);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_write);
            this.Name = "PROGRAM_FTDI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_write;
        private System.Windows.Forms.TextBox tb_serial;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.TextBox tb_manufacturer;
        private System.Windows.Forms.TextBox tb_product;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_device;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.TextBox tb_vendor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_board;
        private System.Windows.Forms.Label label6;
    }
}
