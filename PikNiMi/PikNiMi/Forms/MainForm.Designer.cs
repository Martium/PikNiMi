
namespace PikNiMi
{
    partial class MainForm
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
            this.tableUpperLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.productTypeComboBox = new System.Windows.Forms.ComboBox();
            this.addNewProductButton = new System.Windows.Forms.Button();
            this.updateProductButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.cancelSearchButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableBottomLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableUpperLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableUpperLayoutPanel
            // 
            this.tableUpperLayoutPanel.ColumnCount = 6;
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.Controls.Add(this.updateProductButton, 1, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.productTypeComboBox, 2, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.addNewProductButton, 0, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.searchTextBox, 3, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.cancelSearchButton, 5, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.searchButton, 4, 0);
            this.tableUpperLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableUpperLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableUpperLayoutPanel.Name = "tableUpperLayoutPanel";
            this.tableUpperLayoutPanel.RowCount = 2;
            this.tableUpperLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableUpperLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableUpperLayoutPanel.Size = new System.Drawing.Size(800, 100);
            this.tableUpperLayoutPanel.TabIndex = 0;
            // 
            // productTypeComboBox
            // 
            this.productTypeComboBox.FormattingEnabled = true;
            this.productTypeComboBox.Location = new System.Drawing.Point(195, 3);
            this.productTypeComboBox.Name = "productTypeComboBox";
            this.productTypeComboBox.Size = new System.Drawing.Size(314, 21);
            this.productTypeComboBox.TabIndex = 0;
            this.productTypeComboBox.TabStop = false;
            // 
            // addNewProductButton
            // 
            this.addNewProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewProductButton.Location = new System.Drawing.Point(3, 3);
            this.addNewProductButton.Name = "addNewProductButton";
            this.addNewProductButton.Size = new System.Drawing.Size(90, 44);
            this.addNewProductButton.TabIndex = 1;
            this.addNewProductButton.TabStop = false;
            this.addNewProductButton.Text = "Pridėti naują produktą";
            this.addNewProductButton.UseVisualStyleBackColor = true;
            // 
            // updateProductButton
            // 
            this.updateProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateProductButton.Location = new System.Drawing.Point(99, 3);
            this.updateProductButton.Name = "updateProductButton";
            this.updateProductButton.Size = new System.Drawing.Size(90, 44);
            this.updateProductButton.TabIndex = 2;
            this.updateProductButton.TabStop = false;
            this.updateProductButton.Text = "Atnaujinti produktą";
            this.updateProductButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(515, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(90, 20);
            this.searchTextBox.TabIndex = 3;
            this.searchTextBox.TabStop = false;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(611, 3);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(90, 44);
            this.searchButton.TabIndex = 4;
            this.searchButton.TabStop = false;
            this.searchButton.Text = "ieškoti";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // cancelSearchButton
            // 
            this.cancelSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelSearchButton.Location = new System.Drawing.Point(707, 3);
            this.cancelSearchButton.Name = "cancelSearchButton";
            this.cancelSearchButton.Size = new System.Drawing.Size(90, 44);
            this.cancelSearchButton.TabIndex = 5;
            this.cancelSearchButton.TabStop = false;
            this.cancelSearchButton.Text = "atšaukti";
            this.cancelSearchButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(794, 264);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.TabStop = false;
            // 
            // tableBottomLayoutPanel
            // 
            this.tableBottomLayoutPanel.ColumnCount = 6;
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableBottomLayoutPanel.Location = new System.Drawing.Point(0, 376);
            this.tableBottomLayoutPanel.Name = "tableBottomLayoutPanel";
            this.tableBottomLayoutPanel.RowCount = 2;
            this.tableBottomLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableBottomLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableBottomLayoutPanel.Size = new System.Drawing.Size(800, 74);
            this.tableBottomLayoutPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableBottomLayoutPanel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tableUpperLayoutPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tableUpperLayoutPanel.ResumeLayout(false);
            this.tableUpperLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableUpperLayoutPanel;
        private System.Windows.Forms.ComboBox productTypeComboBox;
        private System.Windows.Forms.Button addNewProductButton;
        private System.Windows.Forms.Button updateProductButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button cancelSearchButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableBottomLayoutPanel;
    }
}

